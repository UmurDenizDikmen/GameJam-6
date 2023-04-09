using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Level1End"))
        {
            UIController.instance.Panel1.SetActive(false);
            UIController.instance.Panel2.SetActive(true);
            GameManager.instance.StopCoroutine("IncreaseFillAmount");

        }
        if (other.gameObject.CompareTag("Level2End"))
        {
            UIController.instance.Panel2.SetActive(false);
            UIController.instance.Panel3.SetActive(true);
            GameManager.instance.StopCoroutine("IncreaseFillAmount2");
        }
        if (other.gameObject.CompareTag("Level3End"))
        {
            UIController.instance.Panel3.SetActive(false);
            GameManager.instance.StopAllCoroutines();

        }
    }
}
