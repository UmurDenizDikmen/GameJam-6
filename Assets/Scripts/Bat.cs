using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bat : MonoBehaviour
{
   [SerializeField]private AudioSource hitSound;
   private void OnCollisionEnter(Collision collisionInfo)
    {
        var touch = collisionInfo.gameObject.GetComponent<ExplosionObjects>();
        if(touch != null)
        {
            hitSound.Play();
        }
    }
}
