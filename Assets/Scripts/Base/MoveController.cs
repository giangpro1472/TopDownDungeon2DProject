using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    protected Rigidbody2D rb;
   
    public float speed;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Move(Vector3 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    protected void ProjectTileMove(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }


}

