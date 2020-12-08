using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    [Header("Light")]
    public Light torchLight;
    
    [Header("Intensity")]
    public int maxIntensity = 100;
    public float baseIntensity = 5f;

    [Header("Decrease")]
    public float timerDecrease = 2f;
    public int intensityDecrease = 1;
    private float lastTimeDecrease;

    [Header("Recharge")]
    public float timerRecharge = .1f;
    public int intensityRecharge = 2;

    public int Intensity { get; private set; }

    private bool _activated = true;
    private bool _refilling = false;
    
    private void Start()
    {
        Intensity = maxIntensity;
        torchLight.intensity = CurrentIntensity();
        lastTimeDecrease = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleTorch();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRefill();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRefill();
        }

        if (_activated && Time.time - lastTimeDecrease > timerDecrease)
        {
            lastTimeDecrease = Time.time;
            DecreaseIntensity();
        }
    }

    private void ToggleTorch()
    {
        ActivateTorch(!_activated);
    }

    private void ActivateTorch(bool activate)
    {
        _activated = activate;
        torchLight.gameObject.SetActive(activate);
        if (activate)
        {
            lastTimeDecrease = Time.time;
            torchLight.intensity = CurrentIntensity();
        }
    }

    private float CurrentIntensity()
    {
        return (Intensity * baseIntensity) / maxIntensity;
    }

    private void DecreaseIntensity()
    {
        Intensity -= intensityDecrease;
        if (Intensity < 0) Intensity = 0;
        torchLight.intensity = CurrentIntensity();
    }

    private void StartRefill()
    {
        _refilling = true;
        ActivateTorch(false);
        StartCoroutine(RefillCoroutine());
    }

    private IEnumerator RefillCoroutine()
    {
        while (_refilling)
        {
            Intensity += intensityRecharge;
            if (Intensity > maxIntensity) Intensity = maxIntensity;
            yield return new WaitForSeconds(timerRecharge);
        }
    }

    private void StopRefill()
    {
        _refilling = false;
        ActivateTorch(true);
    }
}
