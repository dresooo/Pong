using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D Player1;
    private Rigidbody2D Player2;
    public float Speed = 10f;
    public float Yboundary = 9f;
    public int Score;
    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    void Start()
    {

        Player1 = GameObject.Find("racket_left").GetComponent<Rigidbody2D>();
        Player2 = GameObject.Find("racket_right").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        Player1.velocity = new Vector2(Player1.velocity.x, Speed * Time.deltaTime * move);
        float move2 = Input.GetAxis("Vertical2");
        Player2.velocity = new Vector2(Player2.velocity.x, Speed * Time.deltaTime * move2);
    }
        
    void Update()
    {
        if (transform.position.y > Yboundary)
        {
            gameObject.transform.position = new Vector2(transform.position.x, Yboundary);
        }
        else if (transform.position.y < -Yboundary)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -Yboundary);
        }
        
    }
}
