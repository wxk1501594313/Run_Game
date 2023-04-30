using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    public float speed = 7.5f;
    public static float distance = 0f;
    private void Start()
    {
        GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                distance = 0f;
            }
        );
    }
    void FixedUpdate()
    {
        if (transform.position.x > -25.95)
        {
            transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
            distance += (Time.fixedDeltaTime * speed);
            Text text = (Text)GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
            text.text = "" + (int)distance;
        }
        else
        {
            GameManager.addBG();
            Destroy(gameObject);
        }
    }
}
