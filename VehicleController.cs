using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Wheels Colliders")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider backLeftWheelCollider;

    [Header("Wheels Transforms")]
    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform vehicleDoor;


    [Header("Vehicle Engine")]
    public float accelerationForce = 100f;
    public float breakingForce = 200f;
    private float presentBreakingForce = 0f;
    public float presentAcceleration = 0f;


    [Header("Vehicle Steering")]
    public float wheelsTorque = 20f;
    private float presentTurnAngle = 0f;


    [Header("Vehicle Security")]
    public PlayerScript player;
    private float radius = 5f;
    private bool isOpened = false;



    [Header("Disable Things")]
    public GameObject AimCam;
    public GameObject AimCanvas;
    public GameObject ThirdPersonCam;
    public GameObject ThirdPersonCanvas;
    public GameObject PlayerCharacter;


    [Header("Vehicle Hit")]
    public Camera cam;
    public float hitRange=2f;
    private float giveDamageOf = 100f;
    //public ParticleSystem hitSpark;
    public GameObject goreEffect;
    public GameObject DestroyEffect;


    private void Update() {

        if(Vector3.Distance(transform.position, player.transform.position) < radius){
            if(Input.GetKey(KeyCode.F)){
                isOpened = true;
                radius = 5000f;

                ObjectivesComplete.occurrence.GetObjectiveDone(true,true,true,false);

            }
            else if(Input.GetKey(KeyCode.G)){
                player.transform.position = vehicleDoor.transform.position;
                isOpened = false;
                radius = 5f;
            }
        }


        if(isOpened == true){
            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(false);
            AimCanvas.SetActive(false);
            PlayerCharacter.SetActive(false);


            MoveVehicle();
            VehicleSteering();
            ApplyBreaks();
            HitZombies();
        }
        else if(isOpened == false){
            ThirdPersonCam.SetActive(true);
            ThirdPersonCanvas.SetActive(true);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
            PlayerCharacter.SetActive(true);
        }



        //MoveVehicle();
        //VehicleSteering();
        //ApplyBreaks();
    }


    void MoveVehicle(){
        frontRightWheelCollider.motorTorque = presentAcceleration;
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration =accelerationForce * - Input.GetAxis("Vertical");
    }


    void VehicleSteering(){
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontRightWheelCollider.steerAngle = presentTurnAngle;
        frontLeftWheelCollider.steerAngle = presentTurnAngle;


        SteeringWheels(frontRightWheelCollider,frontRightWheelTransform);
        SteeringWheels(frontLeftWheelCollider,frontLeftWheelTransform);
        SteeringWheels(backRightWheelCollider,backRightWheelTransform);
        SteeringWheels(backLeftWheelCollider,backLeftWheelTransform);

    }


    void SteeringWheels(WheelCollider WC,Transform WT){
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }

    void ApplyBreaks(){
        if(Input.GetKey(KeyCode.Space)){
            presentBreakingForce = breakingForce;
        }else{
            presentBreakingForce = 0f;
        }

        frontRightWheelCollider.brakeTorque = presentBreakingForce;
        frontLeftWheelCollider.brakeTorque = presentBreakingForce;
        backRightWheelCollider.brakeTorque = presentBreakingForce;
        backLeftWheelCollider.brakeTorque = presentBreakingForce;
    }

    void HitZombies(){

        RaycastHit hitInfo;

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo,hitRange)){
            Debug.Log(hitInfo.transform.name);

            Zombie1 zombie1=hitInfo.transform.GetComponent<Zombie1>();
            Zombie2 zombie2=hitInfo.transform.GetComponent<Zombie2>();
            ObjectToHit objectToHit=hitInfo.transform.GetComponent<ObjectToHit>();

            if(zombie1!=null){
                zombie1.zombieHitDamage(giveDamageOf);
                zombie1.GetComponent<CapsuleCollider>().enabled=false;
                GameObject goreEffectGo=Instantiate(goreEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo,1f);
            }
            else if(zombie2!=null){
                zombie2.zombieHitDamage(giveDamageOf);
                zombie2.GetComponent<CapsuleCollider>().enabled=false;
                GameObject goreEffectGo=Instantiate(goreEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo,1f);
            }
            else if(objectToHit!=null){
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject woodGo=Instantiate(DestroyEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(woodGo,1f);
            }
        }
    }
}
