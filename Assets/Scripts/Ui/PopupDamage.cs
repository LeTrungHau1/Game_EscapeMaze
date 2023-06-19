using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDamage : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public GameObject target;

    public void EnemyTookDanage(float damageReceived)
    {
        TMP_Text tmpText = Instantiate(damageTextPrefab, target.transform.position, Quaternion.identity, target.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();
    }
    public void PlayerTookDanage(float damageReceived)
    {
        TMP_Text tmpText = Instantiate(damageTextPrefab, target.transform.position, Quaternion.identity, target.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();
    }
}
