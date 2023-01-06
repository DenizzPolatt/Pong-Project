using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private readonly float ballSpeed = 80.0f;

    public Rigidbody Rigidbody => _rigidbody;
    public float BallSpeed => ballSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = new Vector3(0, 10, 0);
        float x = Random.Range(0.5f, 1);
        bool right = Random.Range(0f, 1f) > 0.5f;
        x *= right ? 1 : -1;
        float z = Random.Range(-0.25f, 0.25f);
        Vector3 direction = new Vector3(x, 0, z);
        direction = direction.normalized;
        _rigidbody.velocity = direction * ballSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
    }
    
}
