using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl2 : MonoBehaviour
{
    public float Xforce;
    public float Yforce;
    private Rigidbody2D Ball;
    public float Speed;
    private Vector2 currentvelocity;
    public GameManager GM;
    private Vector2 trajectoryOrigin;

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    void Start()
    {
        Ball = GetComponent<Rigidbody2D>();
        Invoke("GameStart", 1);
        trajectoryOrigin = transform.position;
    }

    void GameStart()
    {
        float rand = Random.Range(0, 2);
        if (rand == 1)
        {
            Yforce *= -1;
        }
        else
        {
            Yforce *= 1;
        }
        float rand2 = Random.Range(0, 2);
        if (rand2 == 1)
        {
            Xforce *= -1;
        }
        else
        {
            Xforce *= 1;
        }
        Ball.AddForce(new Vector2(Xforce, Yforce));
        Invoke("checkvelocity", 1f);
    }

    void checkvelocity()
    {
        currentvelocity.x = Ball.velocity.x;
        currentvelocity.y = Ball.velocity.y;
    }

    public void ResetGame()
    {
        transform.position = new Vector2(0, 0);
        Ball.velocity = new Vector2(0, 0);
        Invoke("GameStart", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        /*
        if (coll.collider.tag == "Racket")
        {
            Ball.velocity = currentvelocity;
        }
       */
    }
    private void OnCollisionExit(Collision collision)
    {
        trajectoryOrigin = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            GM.AddscoreLeft();
            Invoke("ResetGame", 0.5f);
        }
        if (collision.gameObject.name == "RightWall")
        {
            GM.AddscoreRight();
            Invoke("ResetGame", 0.5f);
        }
 
    }

}
