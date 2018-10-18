using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject launcher;
    [SerializeField] private GameObject dynamicBullets;
    [SerializeField] private float fireDelay;
    
    private bool canShoot = true;

    private void Start()
    {
        GetComponentInParent<WeaponLauncher>().FireAllWeapons += OnFireAllWeapons;
    }

    private void OnFireAllWeapons()
    {
        if (canShoot)
        {
            Debug.Log(launcher.transform.position);
            Instantiate(bulletPrefab, launcher.transform.position, Quaternion.identity,
                dynamicBullets.transform);
            canShoot = false;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
