using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canJump;
    private Animator anim;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            anim.SetBool("Jump",true);
            anim.SetBool("InGround", false);
            rigidbody.AddForce(Vector2.up * 700);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Down", true);
            if(anim.GetBool("Jump") == true)
                rigidbody.AddForce(Vector2.down * 50);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("Down", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
            anim.SetBool("Jump", false);
            anim.SetBool("InGround", true);
        }else if(collision.gameObject.tag == "Obstacle")
        {
            //发表结算事件
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
