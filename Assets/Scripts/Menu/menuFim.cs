using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuFim : MonoBehaviour
{
    public void openMenu(){
        SceneManager.LoadScene("Menu");
    }


    public void sairJogo(){
        Application.Quit();
    }
}
