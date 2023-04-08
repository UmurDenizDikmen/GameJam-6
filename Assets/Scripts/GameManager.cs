using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> newPieces = new List<GameObject>();
    public static GameManager instance;

    public Transform spawnPoints;
    public float timer = 4f;
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        if(newPieces.Count > 0)
        {
         timer -= Time.deltaTime;
        if (timer <= 0)
        {

            Instantiate(newPieces[0], spawnPoints.position, Quaternion.identity);
            timer = 4f;
        }
        }

    }
}
