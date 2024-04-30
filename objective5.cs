using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objective5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Vehicle"){

            ObjectivesComplete.occurrence.GetObjectiveDone(true,true,true,true,true);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
