using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objective2 : MonoBehaviour
{
    [Header("Objective")]
    public Text object2;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){

            GetObjectiveDone(true);

            Destroy(gameObject ,2f);
        }
    }

    public void GetObjectiveDone(bool obj2){
        if(obj2 == true){
            object2.text = "02. Completed";
            object2.color = Color.green;
        }
        else{
            object2.text = "02. Locate the villagers";
            object2.color = Color.white;
        }
    }
}
