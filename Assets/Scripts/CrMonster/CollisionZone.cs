using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionZone : MonoBehaviour
{
    [SerializeField] private bool isChasing = false;
    [SerializeField] public bool IsChasing => isChasing;
    public bool IIschasing;

    public bool kt()
    {
        return IIschasing = isChasing;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
           //Debug.Log("va chạm");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
            //Debug.Log("out");
        }
    }
}
