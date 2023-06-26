using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerashake : MonoBehaviour
{
    public CinemachineImpulseSource CinemachineImpulseSource;
    private void Start()
    {
        InvokeRepeating("ShakeCamera", 2f, 2f);
    }
    void ShakeCamera()
    {
        CinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
    }
}
