using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class move : MonoBehaviour
{
    public Rigidbody2D RB;

    float playerinput;
    public float jumpforce;
    public int speed;

    int health = 100;

    public string hero;

    private bool isgrounded;
    public Transform feetpos;
    public float checkradius;
    public LayerMask whatisground;

    public AudioSource src;

    public int score;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {


        RB = GetComponent<Rigidbody2D>();
        print(health);
        damaged();
        print(health);
        boost();
        print(health);
    }



    void FixedUpdate()
    {
        playerinput = Input.GetAxisRaw("Horizontal");
        RB.velocity = new Vector2(playerinput * speed, RB.velocity.y);



    }

    private bool is_on_floor()
    {
        throw new NotImplementedException();
    }

    void damaged()
    {
        health -= 50;
        print("no why");

    }
    void boost()
    {
        health += 10;
        print("yaeh i am powerfull now");

    }
    void Update()
    {
        isgrounded = Physics2D.OverlapCircle(feetpos.position, checkradius, whatisground);

        if (isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {

            RB.velocity = Vector2.up * jumpforce;
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Invoke("Restart", 1f);
            src.Play();
        }

    }
}