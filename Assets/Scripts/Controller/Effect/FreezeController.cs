using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeController : MonoBehaviour
{
    protected float effectStart;
    protected float effectTimer = 3.0f;

    private void Start()
    {
        effectStart = effectTimer;
        MoveController move = transform.parent.GetComponent<MoveController>();
        move.speed -= 0.5f;
    }

    private void OnDestroy()
    {
        MoveController move = transform.parent.GetComponent<MoveController>();
        move.speed += 0.5f;
    }

    private void Update()
    {
        effectStart -= Time.deltaTime;
        if (effectStart <= 0)
        {
           Destroy(this.gameObject);
        }
    }
}
