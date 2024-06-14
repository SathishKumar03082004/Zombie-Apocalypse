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
    public Transform playerTransform; // Reference to the player object to update its rotation

    private void Update(){
        bool isAiming = Input.GetButton("Fire2");

        if (isAiming && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))){
            SetAnimatorState(idle: false, idleAim: true, rifleWalk: true, walk: true);
            SwitchToAimCamera();
        }
        else if (isAiming){
            SetAnimatorState(idle: false, idleAim: true, rifleWalk: false, walk: false);
            SwitchToAimCamera();
        }
        else{
            SetAnimatorState(idle: true, idleAim: false, rifleWalk: false, walk: false);
            SwitchToThirdPersonCamera();
        }

        AlignPlayerWithCamera();
    }

    // Method to switch to the aim camera
    private void SwitchToAimCamera(){
        ThirdPersonCam.SetActive(false);
        ThirdPersonCanvas.SetActive(false);
        AimCam.SetActive(true);
        AimCanvas.SetActive(true);
    }

    // Method to switch to the third-person camera
    private void SwitchToThirdPersonCamera(){
        ThirdPersonCam.SetActive(true);
        ThirdPersonCanvas.SetActive(true);
        AimCam.SetActive(false);
        AimCanvas.SetActive(false);
    }

    // Method to set the animator state
    private void SetAnimatorState(bool idle, bool idleAim, bool rifleWalk, bool walk){
        animator.SetBool("Idle", idle);
        animator.SetBool("IdleAim", idleAim);
        animator.SetBool("RifleWalk", rifleWalk);
        animator.SetBool("Walk", walk);
    }

    // Method to align the player with the active camera's direction
    private void AlignPlayerWithCamera(){
        Transform activeCamera = AimCam.activeSelf ? AimCam.transform : ThirdPersonCam.transform;
        Vector3 cameraDirection = activeCamera.forward;
        cameraDirection.y = 0; // Keep the player aligned horizontally
        if (cameraDirection != Vector3.zero) {
            playerTransform.rotation = Quaternion.LookRotation(cameraDirection);
        }
    }
}
