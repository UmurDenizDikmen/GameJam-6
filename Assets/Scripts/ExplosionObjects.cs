using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExplosionObjects : MonoBehaviour
{

    public float cubeSize = 1f;
    public float cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    Rigidbody rb;

    public float explosionForce = 50f;
    public float explosionRadius = 0.5f;
    public float explosionUpward = 0.4f;
    [SerializeField] private Material material;


    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bat")&& PlayerMovement.isHit == true)
        {
            Explode();

        }
    }

    private void Explode()
    {
        gameObject.SetActive(false);
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


        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);


        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);


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
               piece.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
        GameManager.instance.newPieces.Add(piece);


    }

}