using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDesTroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
