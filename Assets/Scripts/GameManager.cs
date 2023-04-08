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

    [SerializeField] private GameObject key;

    public static event Action<GameState> OnStateChanged;
    public static GameManager instance;

    public Transform[] spawnPoints;
    public float[] timers;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize timers array with default values
        timers = new float[5] { .5f, .5f, .5f, .5f, .5f };
    }
    void Start()
    {
        State = GameState.Start;
    }
    public GameState State { get; private set; }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
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
            case 4: return newPieces5;
            default: return null;
        }
    }
    public void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                key.SetActive(false);
                break;
        }
        OnStateChanged?.Invoke(newState);
        State = newState;
    }
    public void SpawnKeyLevel1()
    {

    }
}
