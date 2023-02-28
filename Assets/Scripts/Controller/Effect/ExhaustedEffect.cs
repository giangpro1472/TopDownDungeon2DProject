using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustedEffect : FreezeController
{
    GameCharacterController character;
    private void Start()
    {
        effectStart = effectTimer;
        character = transform.parent.GetComponent<GameCharacterController>();
        character.speed -= 0.2f;
        character.damage -= 10;
    }

    private void OnDestroy()
    {
        character.speed += 0.2f;
        character.damage += 10;
    }
    void Update()
    {
        effectStart -= Time.deltaTime;
        if (effectStart <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
