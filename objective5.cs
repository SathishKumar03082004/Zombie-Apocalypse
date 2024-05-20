using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class objective5 : MonoBehaviour
{
    [Header("Objective")]
    // public Text object1;
    // public Text object2;
    // public Text object3;
    // public Text object4;
    public Text object5;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Vehicle"){

            GetObjectiveDone(true);

            SceneManager.LoadScene("MainMenu");
        }
    }

    public void GetObjectiveDone(bool obj5){
        if(obj5 == true){
            object5.text = "05. Completed";
            object5.color = Color.green;
            //SceneManager.LoadScene("MainMenu");
        }
        else{
            object5.text = "05. Goto The Drop Zone";
            object5.color = Color.white;
        }
    }
}
