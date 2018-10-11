using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSkittle : MonoBehaviour
{
    public event EventHandler SkittleFallenEvent;

    private bool collidedAlready;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Skittle"))
        {
            if (!collidedAlready)
            {
                collidedAlready = true;
                StartCoroutine(CheckIfSkittleStillStanding());
            }
        }
    }

    private IEnumerator CheckIfSkittleStillStanding()
    {
        yield return new WaitForSeconds(4);
        if (Math.Abs(transform.rotation.x) > 0.1 || Math.Abs(transform.rotation.z) > 0.1)
        {
            Destroy(gameObject);
            var handler = SkittleFallenEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        else
        {
            collidedAlready = false;
        }
    }
}