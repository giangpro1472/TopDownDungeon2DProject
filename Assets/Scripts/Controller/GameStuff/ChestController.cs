using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : Collectable
{
    Animator anim;
    public int gold = 50;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (collected)
        {
            if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.3f)
            {
                anim.Play("EmptyChestClose");
            }
            else
            {
                anim.Play("EmptyChestOpen");
            }
        }
        else
        {
            if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.3f)
            {
                anim.Play("ChestClose");
            }
            else
            {
                anim.Play("ChestOpen");
            }
        }
        
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            TextManager.Instance.Show(gold.ToString() +" GOLD!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            GameManager.instance.Gold += gold;
            GameManager.instance.goldText.text = GameManager.instance.Gold.ToString();
            FindObjectOfType<AudioController>().PlaySFX("Collect");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
