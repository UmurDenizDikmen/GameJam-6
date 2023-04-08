using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExplosionObjects : MonoBehaviour
{

    public float cubeSize =  1f;
    public int cubesInRow = 2;


    float cubesPivotDistance;
    Vector3 cubesPivot;
    Rigidbody rb;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    [SerializeField] private Material material;


    // Use this for initialization
    void Start()
    {


        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        rb = GetComponent<Rigidbody>();


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bat"))
        {
            Explode();

        }

    }

    private void Explode()
    {

        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);

                }
            }
        }
    }
    private void CreatePiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<Renderer>().material = material;
        piece.tag = "ExplosionsObjecst";
        Vector3 explosionPos = piece.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit != null && hit.transform.gameObject.CompareTag("ExplosionsObjecst"))
            {
                Instantiate(hit.gameObject, hit.transform.position, Quaternion.identity);
            }
        }
    }

}