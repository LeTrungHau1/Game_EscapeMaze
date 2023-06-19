using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameTrap : MonoBehaviour
{
    [SerializeField] private float dameTrap;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
           DamePlayer damePlayer = collision.gameObject.GetComponent<DamePlayer>();
            damePlayer.currentHealthPlayer-=dameTrap;
            damePlayer.image.fillAmount = damePlayer.currentHealthPlayer / damePlayer.maxHealthPlayer;
            //Debug.Log("trap chạm player");
        }

    }
}
