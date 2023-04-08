using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public List<GameObject> newPieces1 = new List<GameObject>();
    public List<GameObject> newPieces2 = new List<GameObject>();
    public List<GameObject> newPieces3 = new List<GameObject>();
    public List<GameObject> newPieces4 = new List<GameObject>();
    public List<GameObject> newPieces5 = new List<GameObject>();
    public List<GameObject> newPieces6 = new List<GameObject>();
    public List<GameObject> newPieces7 = new List<GameObject>();
    public List<GameObject> newPieces8 = new List<GameObject>();
    public List<GameObject> newPieces9 = new List<GameObject>();
    public List<GameObject> newPieces10 = new List<GameObject>();
    public List<GameObject> newPieces11 = new List<GameObject>();
    public List<GameObject> newPieces12 = new List<GameObject>();
    public List<GameObject> newPieces13 = new List<GameObject>();


    [SerializeField] private GameObject key;
    [SerializeField] private GameObject doorRoom1;

    public static event Action<GameState> OnStateChanged;
    public static GameManager instance;

    public Transform[] spawnPoints;
    public float[] timers;
    public GameState State { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


        timers = new float[14] { .5f, .5f, .5f, .5f, .5f ,.5f, .5f, .5f, .5f, .5f,.5f,.5f,.5f,.5f};
    }
    void Start()
    {
        ChangeGameState(GameState.Start);
    }


    private void Update()
    {
        for (int i = 0; i < 13; i++)
        {
            if (GetListForIndex(i).Count > 0)
            {
                timers[i] -= Time.deltaTime;

                if (timers[i] <= 0)
                {
                    SpawnPiece(i);
                    timers[i] = 1f;
                }
            }
        }

    }
    private void SpawnPiece(int index)
    {
        GameObject pieceToSpawn = GetListForIndex(index)[0];

        Instantiate(pieceToSpawn, spawnPoints[index].position, Quaternion.identity);
        Instantiate(pieceToSpawn, spawnPoints[index].position, Quaternion.identity);

        GetListForIndex(index).RemoveAt(0);
    }

    private List<GameObject> GetListForIndex(int index)
    {
        switch (index)
        {
            case 0: return newPieces1;
            case 1: return newPieces2;
            case 2: return newPieces3;
            case 3: return newPieces4;
            case 4:
                SpawnKeyLevel1();
                ExplosionObjects.isKey = false;
                return newPieces5;
            case 5: return newPieces6;
            case 6: return newPieces7;
            case 7: return newPieces8;
            case 8: return newPieces9;
            case 9: return newPieces10;
            case 10: return newPieces11;
            case 11: return newPieces12;
            case 12: return newPieces13;
            default: return null;
        }
    }
    public void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                key.gameObject.SetActive(false);
                break;
        }
        OnStateChanged?.Invoke(newState);
        State = newState;
    }
    public void SpawnKeyLevel1()
    {
        if (ExplosionObjects.isKey == true)
        {
            key.gameObject.SetActive(true);
            doorRoom1.transform.DORotate(new Vector3(0, -90, 0), 1f).SetEase(Ease.Linear);
        }
    }
}
