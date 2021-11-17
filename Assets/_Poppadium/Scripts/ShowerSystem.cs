using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerSystem : MonoBehaviour
{
    public ParticleSystem rainParticle;
    public float showerDurationInSecond;
    
    private void OnTriggerEnter(Collider other)
    {
        CancelInvoke();
        StartShower();
        Invoke(nameof(StopShower), showerDurationInSecond);
    }

    private void StartShower()
    {
        rainParticle.Play();
    }
    
    private void StopShower()
    {
        rainParticle.Stop();
    }
    
}
