using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] bgArray;
    public static Action addBG;
    public static Action gameOver;
    public static Action resetGame;
    Animation anim;
    void Start()
    {
        bgArray = Resources.LoadAll<GameObject>("BG");
        addBG = () => {
            print(111);
            int randomSite = UnityEngine.Random.Range(0, bgArray.Length);
            GameObject bg = Instantiate(bgArray[randomSite], new Vector2(25.61f, 0), Quaternion.identity);
            if (bg.GetComponent<BgController>() == null)
                bg.AddComponent<BgController>();
        };
        GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                Time.timeScale = 1;//开启时间流动
                SceneManager.LoadScene(0);//重复加载场景
            }
        );
        GameObject.Find("Canvas").transform.GetChild(2).GetChild(0).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                Time.timeScale = 1;//开启时间流动
                GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
                GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
            }
        );
        Time.timeScale = 0;//开启处于暂停状态
        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
    }
}
