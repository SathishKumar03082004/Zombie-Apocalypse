using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){

            ObjectivesComplete.occurrence.GetObjectiveDone(true,true,false,false,false);

            Destroy(gameObject ,2f);
        }
    }
}
