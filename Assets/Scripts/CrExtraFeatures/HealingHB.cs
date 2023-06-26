using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHB : MonoBehaviour
{
    [SerializeField] public float HB = 50f;
    [SerializeField] public float addForceUp = 5;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * addForceUp, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("vào triger hồi hb");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hồi hb");
            DamePlayer damePlayer = collision.gameObject.GetComponent<DamePlayer>();
            DamePlayer.instance.HealingHB(HB);
            Destroy(gameObject);
        }

    }
}
