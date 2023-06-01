using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotion : MonoBehaviour
{
    [SerializeField] private float rotatespeed = 1f;




    void Update()
    {
        transform.Rotate(0, 0, 360 * rotatespeed * Time.deltaTime);
    }
}
