using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScr : MonoBehaviour
{
    public GameObject stopMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stopMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
