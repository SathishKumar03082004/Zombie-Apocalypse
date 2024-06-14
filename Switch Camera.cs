using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [Header("Camera to Assign")]
    public GameObject AimCam;
    public GameObject AimCanvas;
    public GameObject ThirdPersonCam;
    public GameObject ThirdPersonCanvas;

    [Header("Camera Animator")]
    public Animator animator;

    [Header("Player Reference")]
    public Transform playerTransform;

    private void Update(){
        bool isAiming = Input.GetButton("Fire2");

        if (isAiming && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))){

            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("RifleWalk", true);
            animator.SetBool("Walk", true);

            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
        }
        else if (isAiming){

            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("RifleWalk", false);
            animator.SetBool("Walk", false);

            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
        }
        else{
            animator.SetBool("Idle", true);
            animator.SetBool("IdleAim", false);
            animator.SetBool("RifleWalk", false);

            ThirdPersonCam.SetActive(true);
            ThirdPersonCanvas.SetActive(true);
            AimCam.SetActive(false);
            AimCanvas.SetActive(false);
        }

        if (isAiming){
            AlignPlayerWithAim();
        }
    }

    // Method to align the player with the aim camera's direction
    private void AlignPlayerWithAim(){
        Vector3 aimDirection = AimCam.transform.forward;
        aimDirection.y = 0; // Keep the player aligned horizontally
        if (aimDirection != Vector3.zero) {
            playerTransform.rotation = Quaternion.LookRotation(aimDirection);
        }
    }
}
