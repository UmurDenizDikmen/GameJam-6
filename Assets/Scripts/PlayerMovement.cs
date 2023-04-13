using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    private float range;
    public float range2;
    public static bool isHit = false;
    [SerializeField] private AudioSource hitNot;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > range && GameManager.instance.State == GameState.InGame)
        {
            range = Time.time + range2;
            anim.Play("hit");
            isHit = true;
        }
        if (transform.root.GetComponent<FirstPersonController>().m_Input.magnitude > 0 && GameManager.instance.State == GameState.InGame)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }
    public void PlayWoosh()
    {
        hitNot.Play();
    }
}