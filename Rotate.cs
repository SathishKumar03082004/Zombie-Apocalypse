using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    public GameObject rotatearound;
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(rotatearound.transform.position, Vector3.up, speed*Time.deltaTime);
    }
}
