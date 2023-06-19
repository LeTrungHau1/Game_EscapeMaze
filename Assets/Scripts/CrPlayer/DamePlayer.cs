using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class DamePlayer : MonoBehaviour
{
    public static DamePlayer instance;
    
    [SerializeField] public DameEnemy dameEnemy;
    [SerializeField] public float maxHealthPlayer = 100;
    [SerializeField] public float currentHealthPlayer;
    [SerializeField] public float damePlayer;
    [SerializeField] public Image image;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       dameEnemy = GetComponent<DameEnemy>();
       currentHealthPlayer = maxHealthPlayer;
       image.fillAmount = currentHealthPlayer/maxHealthPlayer;
    }
    public void TakeDamePlayer(float damaEnemy)
    {
        currentHealthPlayer -= damaEnemy; 
        image.fillAmount = currentHealthPlayer / maxHealthPlayer;      
        //CharacterEvents.PlayerDamaged.Invoke(gameObject, damageplayer);//hiện lượng hb giảm
        if (currentHealthPlayer <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        // Xử lý logic khi Enemy bị tiêu diệt
        Debug.Log("player die.");
        gameObject.SetActive(false);
    }



}
