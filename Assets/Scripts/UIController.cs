using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject losePanel;
    public GameObject cluePanel1;
    public GameObject cluePanel2;
    public GameObject cluePanel3;
    public GameObject startGamePanel;
    public GameObject Win;
    public static UIController instance;
    private void Start()
    {
        GameManager.OnStateChanged += OnStateChanged;
        instance = this;
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
                Panel1.SetActive(true);
                cluePanel1.SetActive(true);
                startGamePanel.SetActive(true);
                losePanel.SetActive(false);
                 Win.SetActive(false);
                break;

            case GameState.InGame:
                startGamePanel.SetActive(false);
                losePanel.SetActive(false);
                Win.SetActive(false);
                break;

            case GameState.Success:
                startGamePanel.SetActive(false);
                losePanel.SetActive(false);
                cluePanel1.SetActive(false);
                cluePanel2.SetActive(false);
                cluePanel3.SetActive(false);
                Win.SetActive(true);
                break;

            case GameState.Fail:
                losePanel.SetActive(true);
                Panel1.SetActive(false);
                Panel2.SetActive(false);
                Panel3.SetActive(false);
                cluePanel1.SetActive(false);
                cluePanel2.SetActive(false);
                cluePanel3.SetActive(false);
                startGamePanel.SetActive(false);
                Win.SetActive(false);
                break;
        }
    }
}
