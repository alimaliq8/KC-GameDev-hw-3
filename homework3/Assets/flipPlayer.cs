using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipPlayer : MonoBehaviour
{
    bool faceRight = false;
    SpriteRenderer sprite;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        playeranimations();
    }
    void flip()
    {
        if (Input.GetKey(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKey(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }
    void playeranimations()
    {
        float speed = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
}
