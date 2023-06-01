using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))//va chạm với người chơi
        {
            collision.gameObject.transform.SetParent(transform);//tranform của người chơi thành con 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.transform.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);//cho người chơi thoát ra khỏi và trở lại thành1  gameoject
        }
    }
}
