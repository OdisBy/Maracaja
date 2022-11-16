using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public Image imagem;
    public Texture2D[] inicialArray;
    public int id = 0;

    void Update(){
        if(Input.GetButtonDown("Jump")){
            playCutsceneInicial();
        }
    }

    public void playCutsceneInicial(){
        if(id == (inicialArray.Length - 1)){
            goToGame();
            Debug.Log("Acabou");
        }
        imagem.sprite = Sprite.Create (inicialArray[id], new Rect (0, 0, 280, 180), new Vector2 ());//set the Rect with position and dimensions as you need
        id++;
    }

    void goToGame(){
        SceneManager.LoadScene("Game");
    }
}
