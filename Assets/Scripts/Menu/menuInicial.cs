using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToGame(){
        SceneManager.LoadScene("Game");
    }
    public void openConfiguration(){
        //TODO
    }
    public void quitGame(){
        Application.Quit();
    }
}
