using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    private float speed = 60;
    private float zRange = 26.5f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
            transform.Translate(Vector3.forward * Time.deltaTime * speed );
        if(Input.GetKey(KeyCode.S)) 
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed );

        if (transform.position.z >= zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        
        if (transform.position.z <= -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        var ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            ball.Rigidbody.velocity = ball.transform.position - transform.position + Vector3.right;
            ball.Rigidbody.velocity = new Vector3(ball.Rigidbody.velocity.x, 0, ball.Rigidbody.velocity.z);
            ball.Rigidbody.velocity = ball.Rigidbody.velocity.normalized * ball.BallSpeed;
        }
    }
}
