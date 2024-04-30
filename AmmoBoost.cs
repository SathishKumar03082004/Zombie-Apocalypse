using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoost : MonoBehaviour
{
    [Header("AmmoBoost")]
    public Rifle rifle;
    private int MagToGive = 10;
    private float radius = 2.5f;

    [Header("Sound Effects")]
    public AudioClip AmmoBoostSound;
    public AudioSource audioSource;

    [Header("AmmoBox Animation")]
    public Animator animator;


    private void Update() {
        if(Vector3.Distance(transform.position, rifle.transform.position)<radius){
            if(Input.GetKeyDown("f")){
                animator.SetBool("Open",true);
                rifle.mag = MagToGive;

                //Sound
                audioSource.PlayOneShot(AmmoBoostSound);

                //Destory object
                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
