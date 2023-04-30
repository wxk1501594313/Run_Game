using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private bool canJump;
    private Animator anim;
    private Rigidbody2D rigidbody;
    public UnityEngine.Events.UnityEvent gameOver;
    AudioSource audioSource;
    public AudioClip dead, jump;
    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        GameObject.Find("Canvas").transform.GetChild(3).GetChild(0).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                if (canJump)
                {
                    canJump = false;
                    anim.SetBool("Jump", true);
                    anim.SetBool("InGround", false);
                    rigidbody.AddForce(Vector2.up * 700);
                    audioSource.clip = jump;//更换至跳跃音频
                    audioSource.loop = false;//不开启循环播放
                    audioSource.Play();//播放音频
                }
            }
        );
        GameObject.Find("Canvas").transform.GetChild(3).GetChild(1).GetComponent<Button>().GetComponent<ButtonController>().buttonDown.AddListener(
            () =>
            {
                anim.SetBool("Down", true);
                if (anim.GetBool("Jump") == true)
                    rigidbody.AddForce(Vector2.down * 500);
            }
        );
        GameObject.Find("Canvas").transform.GetChild(3).GetChild(1).GetComponent<Button>().GetComponent<ButtonController>().buttonUp.AddListener(
            () =>
            {
                anim.SetBool("Down", false);
            }
        );
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
            audioSource.clip = jump;//更换至跳跃音频
            audioSource.loop = false;//不开启循环播放
            audioSource.Play();//播放音频
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
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            //发表结算事件
            audioSource.clip = dead;//更换至跳跃音频
            audioSource.loop = false;//不开启循环播放
            audioSource.Play();//播放音频
            gameOver.Invoke();
            anim.SetBool("GameOver", true);
            Invoke("StopGame", 0.2f);
            int First = PlayerPrefs.GetInt("First");
            int Second = PlayerPrefs.GetInt("Second");
            int Third = PlayerPrefs.GetInt("Third");
            int cur = (int)BgController.distance + 3;
            if (cur > First)
            {
                Third = Second;
                Second = First;
                First = cur;
            }
            else if (cur > Second)
            {
                Third = Second;
                Second = cur;
            }
            else if (cur > Third)
            {
                Third = cur;
            }
            PlayerPrefs.SetInt("Third", Third);
            PlayerPrefs.SetInt("Second", Second);
            PlayerPrefs.SetInt("First", First);

            GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "Toppers This Week:" + '\n' + "top1 " + First + '\n' + "top2 " + Second + '\n' + "top3 " + Third;
        }

    }

    void StopGame()
    {
        Time.timeScale = 0;
    }
}
