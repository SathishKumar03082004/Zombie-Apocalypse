using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Footstep Source")]
    public AudioClip[] footStepSound;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomFootStep(){
        return footStepSound[UnityEngine.Random.Range(0, footStepSound.Length)];
    }

    private void Step(){
        AudioClip clip = GetRandomFootStep();
        audioSource.PlayOneShot(clip);
    }
}
