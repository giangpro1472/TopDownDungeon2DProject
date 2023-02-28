using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour, IHit
{
    bool hitCrate;
    [SerializeField]
    GameObject[] items;
    private void Update()
    {
        if (hitCrate)
        {
            Create.Instance.CreateHitExplosion(transform.position);
            Destroy(gameObject);
            GameObject item = items[Random.Range(0, items.Length)];
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(float damage)
    {
        hitCrate = true;
    }
}
