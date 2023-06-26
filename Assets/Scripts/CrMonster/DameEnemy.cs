using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DameEnemy : MonoBehaviour
{
    public static DameEnemy Instance;
    [SerializeField] public DamePlayer damePlayer;
    [SerializeField] public MonsterCtroller monsterCtroller;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth; 
    [SerializeField] public float currenDameEnemy = 10f; 
    [SerializeField] public Image image;
    [SerializeField] public bool isDamePlayer=false;

    //sống dậy
    public bool initialEnabled=false;
    public bool OnRevival=false;

    public float Revival = 0f;
    //[SerializeField] private float timeDamePlayer = 0.5f;

    //bình hb
    //public GameObject healingHB;


    protected void Awake()
    {
        Instance = this;
        Debug.Log(gameObject.name);
    }
    protected void Start()
    {     
        damePlayer = GetComponent<DamePlayer>();
        currentHealth = maxHealth; 
        image.fillAmount = currentHealth / maxHealth;
        initialEnabled = gameObject.activeSelf;
    }
    public void TakeDameEnemy(float damaPlayer)
    {
        currentHealth -= damaPlayer; // Giảm máu dựa trên damageAmount
        image.fillAmount = currentHealth / maxHealth;

        //CharacterEvents.characterDamaged.Invoke(gameObject, damaPlayer);//hiện lượng hb giảm

        if (currentHealth <= 0)
        {
            Die();
            if(OnRevival==true)
            {
                 Invoke("hoi", Revival);
            }
           
        }
    }
    protected virtual  void Die()
    {
        // Xử lý logic khi Enemy bị tiêu diệt
        Debug.Log("Enemy die.");
       gameObject.SetActive(false);
       
    }
    protected void hoi()
    {
        Debug.Log("hồi");
        gameObject.SetActive(true);
        gameObject.SetActive(DameEnemy.Instance.initialEnabled);
       
        currentHealth =maxHealth;
       image.fillAmount =currentHealth /maxHealth;
    }
}


