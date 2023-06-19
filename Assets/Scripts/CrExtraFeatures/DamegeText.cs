using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamegeText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3 (0, 1, 0);
    public float timeToFade = 1f;
    public float timeElapsed = 0f;
    private Color startColor;
    public RectTransform textTransform;
    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        startColor = textMeshProUGUI.color;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;
        if(timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a * (1 - (timeElapsed / timeToFade));
            textMeshProUGUI.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
