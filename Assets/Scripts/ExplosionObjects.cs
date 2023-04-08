using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExplosionObjects : MonoBehaviour
{
    public enum typeOfObjecst
    {
        pc,
        tv,
        lamb,
        sifon,
        glass,
        flowers,
        tv2,
        gitar1,
        gitar2,
        gitar3,
        amfi,
        lambader,
        sandik,
        vazo2,
    }
    [SerializeField] private typeOfObjecst type_;
    public float cubeSize = 1f;
    public float cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    Rigidbody rb;

    public float explosionForce = 50f;
    public float explosionRadius = 0.5f;
    public float explosionUpward = 0.4f;
    [SerializeField] private Material material;

    public static bool isKey = false;


    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bat") && PlayerMovement.isHit == true)
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
        if (type_ == typeOfObjecst.tv)
        {
            GameManager.instance.newPieces1.Add(piece);
        }
        if (type_ == typeOfObjecst.flowers)
        {
            GameManager.instance.newPieces2.Add(piece);
        }
        if (type_ == typeOfObjecst.glass)
        {
            GameManager.instance.newPieces3.Add(piece);
        }
        if (type_ == typeOfObjecst.lamb)
        {
            GameManager.instance.newPieces4.Add(piece);
        }
        if (type_ == typeOfObjecst.pc)
        {
            GameManager.instance.newPieces5.Add(piece);
            isKey = true;
        }
        if (type_ == typeOfObjecst.amfi)
        {
            GameManager.instance.newPieces6.Add(piece);
        }
        if (type_ == typeOfObjecst.gitar1)
        {
            GameManager.instance.newPieces7.Add(piece);
        }
        if (type_ == typeOfObjecst.gitar2)
        {
            GameManager.instance.newPieces8.Add(piece);
        }
        if (type_ == typeOfObjecst.gitar3)
        {
            GameManager.instance.newPieces9.Add(piece);
        }
        if (type_ == typeOfObjecst.lambader)
        {
            GameManager.instance.newPieces10.Add(piece);

        }
         if (type_ == typeOfObjecst.tv2)
        {
            GameManager.instance.newPieces11.Add(piece);

        }
        if (type_ == typeOfObjecst.sandik)
        {
            GameManager.instance.newPieces12.Add(piece);

        }


    }
}