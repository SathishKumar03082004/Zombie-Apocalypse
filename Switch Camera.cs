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


    private void SwitchToAimCamera(){
        ThirdPersonCam.SetActive(false);
        ThirdPersonCanvas.SetActive(false);
        AimCam.SetActive(true);
        AimCanvas.SetActive(true);
    }


    private void SwitchToThirdPersonCamera(){
        ThirdPersonCam.SetActive(true);
        ThirdPersonCanvas.SetActive(true);
        AimCam.SetActive(false);
        AimCanvas.SetActive(false);
    }

    private void SetAnimatorState(bool idle, bool idleAim, bool rifleWalk, bool walk){
        animator.SetBool("Idle", idle);
        animator.SetBool("IdleAim", idleAim);
        animator.SetBool("RifleWalk", rifleWalk);
        animator.SetBool("Walk", walk);
    }


    private void AlignPlayerWithCamera(){
        Transform activeCamera = AimCam.activeSelf ? AimCam.transform : ThirdPersonCam.transform;
        Vector3 cameraDirection = activeCamera.forward;
        cameraDirection.y = 0; 
        if (cameraDirection != Vector3.zero) {
            playerTransform.rotation = Quaternion.LookRotation(cameraDirection);
        }
    }
}
