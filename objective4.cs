using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class objective4 : MonoBehaviour
{
    [Header("Objective")]
    public Text object4;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Vehicle"){

            GetObjectiveDone(true);
        }
    }

    
    public void GetObjectiveDone(bool obj4){
        if(obj4 == true){
            object4.text = "04. Completed";
            object4.color = Color.green;
        }
        else{
            object4.text = "04. Get all the villagers into villagers";
            object4.color = Color.white;
        }
    }
}
