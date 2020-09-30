using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    // public Transform patrolPointA;
    // public Transform patrolPointB;

    public bool facingRight = true;
    
    void Update()
    {
        if (facingRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }


    private void Flip()
    {
        // facingRight = !facingRight;
        Vector2 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PatrolPointB"))
        {
            Flip();
            facingRight = false;
        }
        else if (coll.CompareTag("PatrolPointA"))
        {
            Flip();
            facingRight = true;
        }
    }

}
