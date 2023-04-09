using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public GameObject Panel1;
      public GameObject Panel2;
        public GameObject Panel3;
    public static UIController instance;
    void Start()
    {
        GameManager.OnStateChanged += OnStateChanged;
        instance = this;
    }
    void OnStateChanged(GameState state)
    {
           switch(state)
           {
               case GameState.Start :
               Panel1.SetActive(true);
               break;

               case GameState.InGame :

               break;

               case GameState.Success :

               break;

               case GameState.Fail :

               break;
           }
    }
}
