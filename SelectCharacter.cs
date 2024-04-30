using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public void OnAdria(){
        SceneManager.LoadScene("ZombieLand");
    }

    public void OnAlax(){
        SceneManager.LoadScene("ZombieLand1");
    }

    public void OnCooper(){
        SceneManager.LoadScene("ZombieLand2");
    }

    public void OnBack(){
        SceneManager.LoadScene("MainMenu");
    }
}
