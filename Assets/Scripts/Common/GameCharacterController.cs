using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash;

public abstract class GameCharacterController : MoveController, IHit
{
    public HealthController hpController;
 
    public float timeInvincible = 1f;
    public bool isInvincible;
    float invincibleTimer;

    protected float dazedTime;
    public float startDazedTime;
    protected bool isDazed;

    protected float tempSpeed;

    public float damage;

    protected bool facingRight = true;

    [SerializeField]
    private SimpleFlash flashEffect;

    protected virtual void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    protected virtual void Awake()
    {
        tempSpeed = speed;
        hpController.die = Die;
    }

    public void CharacterMove(Vector3 direction)
    {
        Move(direction);
        if (direction.x < 0 && facingRight)
        {
            flip();
        }
        else if (direction.x > 0 && !facingRight)
        {
            flip();
        }
    }

    protected void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    protected abstract void Die();

    public virtual void TakeDamage(float damage)
    {
        if (isInvincible)
        {
         return;
        }

        dazedTime = startDazedTime;
        isDazed = true;
    
        isInvincible = true;
        invincibleTimer = timeInvincible;

        TextManager.Instance.Show(damage.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
        flashEffect.Flash();
        hpController.TakeDame(damage);
        
    }

}
