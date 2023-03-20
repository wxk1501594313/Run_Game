using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] bgArray;
    public static Action addBG;
    public static Action gameOver;
    public static Action resetGame;
    void Start()
    {
        bgArray = Resources.LoadAll<GameObject>("BG");
        addBG = ()=> {
            print(111);
            int randomSite = UnityEngine.Random.Range(0, bgArray.Length);
            GameObject bg = Instantiate(bgArray[randomSite], new Vector2(25.61f, 0), Quaternion.identity);
            if (bg.GetComponent<BgController>() == null)
                bg.AddComponent<BgController>();
        };
    }
}
