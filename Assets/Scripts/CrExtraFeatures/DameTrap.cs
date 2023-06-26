using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameTrap : MonoBehaviour
{
    [SerializeField] public float dameTrap;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("OnTriggerEnter2D");
            DamePlayer damePlayer = collision.gameObject.GetComponent<DamePlayer>();
            DamePlayer.instance.TakeDamePlayer(dameTrap);

        }

    }


}
