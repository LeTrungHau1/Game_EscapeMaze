using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2.5f;

    private void Update()
    {
        // Di chuyển qua trái dựa trên tốc độ và thời gian giữa các khung hình
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        //StartCoroutine(WaitAndContinue());
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
        }

    }
}
