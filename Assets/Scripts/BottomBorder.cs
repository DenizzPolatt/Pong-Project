using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorder : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        var ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            
            ball.Rigidbody.velocity = Vector3.Reflect(ball.Rigidbody.velocity, Vector3.forward);
            ball.Rigidbody.velocity = ball.Rigidbody.velocity.normalized * ball.BallSpeed;
        }
    }
}
