using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private GameObject startGameText;

    [SerializeField] private Text deathText;

    public void ActivateText(bool activate)
    {
        deathText.enabled = activate;
        startGameText.SetActive(activate);
    }
}
