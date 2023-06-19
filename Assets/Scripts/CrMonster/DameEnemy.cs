﻿using System;
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
    [SerializeField] private float timeDamePlayer = 0.5f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {     
        damePlayer = GetComponent<DamePlayer>();
        currentHealth = maxHealth; 
        image.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDameEnemy(float damaPlayer)
    {
        currentHealth -= damaPlayer; // Giảm máu dựa trên damageAmount
        image.fillAmount = currentHealth / maxHealth;

        //CharacterEvents.characterDamaged.Invoke(gameObject, damaPlayer);//hiện lượng hb giảm

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }
    private void Die()
    {
        // Xử lý logic khi Enemy bị tiêu diệt
        Debug.Log("Enemy die.");
       gameObject.SetActive(false);
    }
   
}
