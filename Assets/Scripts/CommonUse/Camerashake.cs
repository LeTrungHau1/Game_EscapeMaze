using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerashake : MonoBehaviour
{
    public CinemachineImpulseSource CinemachineImpulseSource;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
        }
    }
}
