using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    [Header("HealthBoost")]
    public PlayerScript player;
    private float healthToGive = 100f;
    private float radius = 2.5f;

    [Header("Sound Effects")]
    public AudioClip HealthBoostSound;
    public AudioSource audioSource;

    [Header("HealthBox Animation")]
    public Animator animator;


    private void Update() {
        if(Vector3.Distance(transform.position, player.transform.position)<radius){
            if(Input.GetKeyDown("f")){
                animator.SetBool("Open",true);
                player.presnetHealth = healthToGive;

                //Sound
                audioSource.PlayOneShot(HealthBoostSound);

                //Destory object
                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
