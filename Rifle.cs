using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamageOf =10f;
    public float shootRange=100f;
    public float fireCharge=15f;
    private float nextTimeToShoot=0f;
    public Animator animator;
    public PlayerScript player;
    public Transform hand;
    public GameObject rifleUI;


    [Header("Rifle Ammunition and Shooting")]
    private int maximumAmmunition=32;
    public int mag=10;
    public int presentAmmunition;
    public float reloadingTime=1.3f;
    private bool setReloading=false;


    [Header("Rifile Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject WoodedEffect;
    public GameObject goreEffect;


    [Header("Sound and UI")]
    public GameObject AmmoOutUI;
    public AudioClip shootingSound;
    public AudioClip reloadingSound;
    public AudioSource audioSource;


    [Header("Rifile Light")]
    public Light spotLight;


    private void Awake() {
        transform.SetParent(hand);
        rifleUI.SetActive(true);
        presentAmmunition=maximumAmmunition;
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update(){
        if(setReloading){
            return;
        }

        if(presentAmmunition<=0){
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time>=nextTimeToShoot){
            animator.SetBool("Fire",true);
            animator.SetBool("Idle",false);

            nextTimeToShoot=Time.time+1f/fireCharge;
            Shoot();
        }else if(Input.GetButton("Fire1")&& Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            animator.SetBool("Idle",false);
            animator.SetBool("FireWalk",true);
        }else if(Input.GetButton("Fire2") && Input.GetButton("Fire1")){
            animator.SetBool("Idle",false);
            animator.SetBool("IdleAim",true);
            animator.SetBool("FireWalk",true);
            animator.SetBool("Walk",true);
            animator.SetBool("Reloading",false);
        }else{
            animator.SetBool("Fire",false);
            animator.SetBool("Idle",true);
            animator.SetBool("FireWalk",false);//True
        }




        if(Input.GetKeyDown("z")){
            ToggleSpotLight(true);
        }

        if(Input.GetKeyDown("x")){
            ToggleSpotLight(false);
        }


    }

        public void ToggleSpotLight(bool state){
            if (spotLight != null){
                spotLight.enabled = state;
            }
        }

    private void Shoot(){
        if(mag==0){
            StartCoroutine(showAmmoOut());
            return;
        }

        presentAmmunition--;

        if(presentAmmunition==0){
            mag--;
        }


        AmmoCount.occurrence.UpdateAmmoText(presentAmmunition);
        AmmoCount.occurrence.UpdateMagText(mag);

        muzzleSpark.Play();
        audioSource.PlayOneShot(shootingSound);
        RaycastHit hitInfo;

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo,shootRange)){
            Debug.Log(hitInfo.transform.name);

            ObjectToHit objectToHit=hitInfo.transform.GetComponent<ObjectToHit>();
            Zombie1 zombie1=hitInfo.transform.GetComponent<Zombie1>();
            Zombie2 zombie2=hitInfo.transform.GetComponent<Zombie2>();

            if(objectToHit!=null){
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject woodGo=Instantiate(WoodedEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(woodGo,1f);
            }
            else if(zombie1!=null){
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo=Instantiate(goreEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo,1f);
            }
            else if(zombie2!=null){
                zombie2.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo=Instantiate(goreEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo,1f);
            }
        }
    }

    IEnumerator Reload(){
        player.playerSpeed=0f;
        player.playerSprint=0f;
        setReloading=true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading",true);
        audioSource.PlayOneShot(reloadingSound);
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("Reloading",false);
        presentAmmunition=maximumAmmunition;
        player.playerSpeed=1.9f;
        player.playerSprint=3;
        setReloading=false;
    }


    IEnumerator showAmmoOut(){
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
}
