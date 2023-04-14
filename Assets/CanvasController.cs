using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().gameOver.AddListener(
            () =>
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
        );
        //¶¯Ì¬°ó¶¨
        transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).GetComponent<Text>().text = "0";
            }    
        );
    }
}
