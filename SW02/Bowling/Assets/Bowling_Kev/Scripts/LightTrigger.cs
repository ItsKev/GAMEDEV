using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private Light triggerLight;

    public void DisableLight()
    {
        triggerLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerLight.enabled = true;
    }
}