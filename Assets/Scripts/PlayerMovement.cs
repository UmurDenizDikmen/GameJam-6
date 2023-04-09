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

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > range)
        {
            range = Time.time + range2;
            anim.Play("hit");
            isHit = true;
        }
        if (transform.root.GetComponent<FirstPersonController>().m_Input.magnitude > 0)
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
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Level1End"))
        {
            UIController.instance.Panel1.SetActive(false);
            UIController.instance.Panel2.SetActive(true);
            GameManager.instance.StopCoroutine("IncreaseFillAmount");

        }
        if(other.gameObject.CompareTag("Level2End"))
        {
             UIController.instance.Panel2.SetActive(false);
             UIController.instance.Panel3.SetActive(true);
               GameManager.instance.StopCoroutine("IncreaseFillAmount2");
        }
         if(other.gameObject.CompareTag("Level3End"))
        {
             UIController.instance.Panel3.SetActive(false);
              GameManager.instance.StopAllCoroutines();

        }
    }

}
