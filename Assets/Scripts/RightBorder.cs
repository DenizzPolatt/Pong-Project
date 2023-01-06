using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightBorder : MonoBehaviour
{

    public Text score2;
    private int _score2 = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score2.text = _score2.ToString();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            StartCoroutine(Wait(ball));
            ball.gameObject.SetActive(false);
            _score2 += 1;
        }
    }
    
    private IEnumerator Wait(Ball ball)
    {  
        yield return new WaitForSeconds(3);
        ball.ResetBall();
        ball.gameObject.SetActive(true);
    }
}
