using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject launcher;
    [SerializeField] private GameObject dynamicBullets;
    [SerializeField] private float fireDelay;

    private Transform bulletStartPosition;
    private bool canShoot = true;

    private void Start()
    {
        bulletStartPosition = launcher.GetComponent<Transform>();
        GetComponentInParent<WeaponLauncher>().FireWeapons += OnFireWeapon;
    }

    private void OnFireWeapon()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, bulletStartPosition.position, bulletStartPosition.rotation,
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