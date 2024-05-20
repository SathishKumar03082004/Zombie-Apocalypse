using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiflePickup : MonoBehaviour
{
    [Header("Rifle's")]
    public GameObject PlayerRifle;
    public GameObject PickUpRifie;
    public PlayerPunch playerPunch;
    public GameObject rifleUI;


    [Header("Rifie Assign Things")]
    public PlayerScript player;
    private float radius=2.5f;
    public Animator animator;
    private float nextTimeToPunch=0f;
    public float punchCharge=15f;


    [Header("Objective")]
    public Text objective1;

    private void Awake() {
        PlayerRifle.SetActive(false);
        rifleUI.SetActive(false);
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1") && Time.time>=nextTimeToPunch){
            animator.SetBool("Punch",true);
            animator.SetBool("Idle",false);
            nextTimeToPunch=Time.time+1f/punchCharge;
            playerPunch.Punch();
        }else{
            animator.SetBool("Punch",false);
            animator.SetBool("Idle",true);
        }


        if(Vector3.Distance(transform.position,player.transform.position)<radius){
            if(Input.GetKeyDown("f")){
                PlayerRifle.SetActive(true);
                PickUpRifie.SetActive(false);
                //ObjectivesComplete.occurrence.GetObjectiveDone(true,false,false,false);
                GetObjectiveDone(true);
            }
        }
    }

    public void GetObjectiveDone(bool obj1){
        if(obj1 == true){
            objective1.text = "01. Completed";
            objective1.color = Color.green;
        }
        else{
            objective1.text = "01. Find The Rifle";
            objective1.color = Color.white;
        }
    }
}
