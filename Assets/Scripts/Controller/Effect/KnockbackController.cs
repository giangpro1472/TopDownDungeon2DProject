using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    public float thurst;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<EnemyController>())
        {
            Rigidbody2D rb = coll.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 difference = rb.transform.position - transform.position;
                difference = difference.normalized * thurst;
                rb.AddForce(difference, ForceMode2D.Impulse);
                Debug.Log("Knockback");
            }
        }
    }
   
    
}
