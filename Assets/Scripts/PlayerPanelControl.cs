using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerPanelControl : MonoBehaviour
{
    private void Start()
    {
        GameManager.OnStateChanged += OnStateChanged;
        transform.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Level1End"))
        {
            UIController.instance.Panel1.SetActive(false);
            UIController.instance.Panel2.SetActive(true);
            GameManager.instance.StopCoroutine("IncreaseFillAmount");
            UIController.instance.cluePanel1.SetActive(false);
            UIController.instance.cluePanel2.SetActive(true);

        }
        if (other.gameObject.CompareTag("Level2End"))
        {
            UIController.instance.Panel2.SetActive(false);
            UIController.instance.Panel3.SetActive(true);
            GameManager.instance.StopCoroutine("IncreaseFillAmount2");
            UIController.instance.cluePanel2.SetActive(false);
            UIController.instance.cluePanel3.SetActive(true);
        }
        if (other.gameObject.CompareTag("Level3End"))
        {
            UIController.instance.Panel3.SetActive(false);
            GameManager.instance.StopAllCoroutines();
            UIController.instance.cluePanel3.SetActive(false);

        }
        if(other.gameObject.CompareTag("GameEnd"))
        {
            GameManager.instance.ChangeGameState(GameState.Success);
        }
    }
    private void OnDisable()
    {
        GameManager.OnStateChanged -= OnStateChanged;
    }
    private void OnStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                transform.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0f;
                break;

            case GameState.InGame:
               transform.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 5f;
                break;

            case GameState.Success:
             transform.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0f;
                break;

            case GameState.Fail:
            transform.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0f;
                break;
        }
    }
}
