using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float speed = 60;
    private float zRange = 26.5f;
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }

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
            float speed1 = ball.BallSpeed;
            speed1 += 5;
            ball.Rigidbody.velocity = ball.transform.position - transform.position + Vector3.left;
            ball.Rigidbody.velocity = new Vector3(ball.Rigidbody.velocity.x, 0, ball.Rigidbody.velocity.z);
            ball.Rigidbody.velocity = ball.Rigidbody.velocity.normalized * ball.BallSpeed;
        }
    }
}