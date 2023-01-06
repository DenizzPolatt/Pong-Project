using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftBorder : MonoBehaviour
{
    public Text score1;
    private int _score1 = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = _score1.ToString();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            ball.gameObject.SetActive(false);
            StartCoroutine(Wait(ball));
            _score1 += 1;
        }
    }
    private IEnumerator Wait(Ball ball)
    {  
        yield return new WaitForSeconds(3);
        ball.ResetBall();
        ball.gameObject.SetActive(true);
    }
}
