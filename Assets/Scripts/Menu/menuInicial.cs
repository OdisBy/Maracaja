using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
    public AudioClip click;

    void Start(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = click;
    }

    public void goToGame(){
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("CutScene-Inicial");
    }
    public void openConfiguration(){
        //TODO
        GetComponent<AudioSource>().Play();
    }
    public void quitGame(){
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void clickSound(){
        GetComponent<AudioSource>().clip = click;
        GetComponent<AudioSource>().Play();
    }
}
