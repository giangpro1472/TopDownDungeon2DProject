using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public abstract class EnemyController : GameCharacterController
{
    public float triggerLenght = 0.1f;

    public Transform attackPoint;
    public float attackRange;

    protected bool playerDitected;
    protected Vector3 startingPosition;
    public bool isDead = false;

    protected Animator animator;

    [SerializeField] protected float exp;
    [SerializeField] protected int gold;

    protected override void Start()
    {
        base.Start();
        startingPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (isDazed)
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
            if (dazedTime <= 0)
            {
                speed = tempSpeed;
                isDazed = false;
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if (Vector3.Distance(Player.Instance.transform.position, startingPosition) < triggerLenght)
        {
            playerDitected = true;
        }

        if (playerDitected)
        {
            EnemyAI();
        }

        if (Player.Instance.transform.position.x < transform.position.x && facingRight)
        {
            flip();
        }
        else if (Player.Instance.transform.position.x > transform.position.x && !facingRight)
        {
            flip();
        }
        
    }

    protected abstract void EnemyAI();

    protected virtual void EnemyDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].name == "Player")
            {
                IHit onHit = hits[i].transform.gameObject.GetComponent<IHit>();
                if (onHit != null)
                {
                    onHit.TakeDamage(damage);
                    return;
                }
            }
        }
    }

    protected override void Die() 
    {
        Observer.Instance.Notify(TOPICNAME.ENEMYDIED);
        isDead = true;
        Player.Instance.expController.GetEXP(exp);
        GameManager.instance.Gold += gold;
        GameManager.instance.goldText.text = GameManager.instance.Gold.ToString();
        Destroy(gameObject);
    }
}
