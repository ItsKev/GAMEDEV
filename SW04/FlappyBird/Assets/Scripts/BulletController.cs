using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] private float bulletSpeed = 5;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0) * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
