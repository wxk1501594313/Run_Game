using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BgController : MonoBehaviour
{
    public float speed = 7.5f;
    void FixedUpdate()
    {
        if (transform.position.x > -25.95)
            transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
        else
        {
            GameManager.addBG();
            Destroy(gameObject);
        }
    }
}
