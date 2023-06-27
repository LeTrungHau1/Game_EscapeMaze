using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDamage : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public GameObject target;
    TMP_Text tmpText;

    public void EnemyTookDanage(float damageReceived)
    {
        tmpText = Instantiate(damageTextPrefab, target.transform.position, Quaternion.identity, target.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();
    }
    public void PlayerTookDanage(float damageReceived)
    {
        tmpText = Instantiate(damageTextPrefab, target.transform.position, Quaternion.identity, target.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();
    }
    private void Update()
    {
        if (tmpText != null)
        {

            tmpText.fontSize += Time.deltaTime * 0.2f;
        }
    }
}
