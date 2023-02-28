using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    protected float effectStart;
    protected float effectTimer = 2.0f;
    protected float burnTime = 0.2f;

    GameCharacterController character;

    protected virtual void Start()
    {
        effectStart = effectTimer;
        character = transform.parent.GetComponent<GameCharacterController>();
    }

    protected virtual void Update()
    {
        effectStart -= Time.deltaTime;
        burnTime -= Time.deltaTime;
        if (burnTime <= 0)
        {
            character.hpController.TakeDame(2);
            TextManager.Instance.Show("2", 15, Color.red, character.transform.position, Vector3.up * 25, 1.5f);
            burnTime = 0.5f;
        }
        if (effectStart <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
