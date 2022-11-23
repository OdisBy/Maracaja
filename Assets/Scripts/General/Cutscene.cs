using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene : MonoBehaviour
{
    public Image imagem;
    public Texture2D[] inicialArray;
    public TextMeshProUGUI caixaDialogo;
    public int id = 0;
    public string[] textos;

    void Start(){
        StartCoroutine(cutsceneInicial());
    }
    void Update(){
        if (id >=  7){
            if(id == 7){
                caixaDialogo.text = "Pressione espaço para continuar...";
            }
            if(Input.GetButtonDown("Jump")){
                playCutsceneInicial();
            }
        }
    }

    public void playCutsceneInicial(){
        if(id == (inicialArray.Length )){
            goToGame();
            return;
        }
        imagem.sprite = Sprite.Create (inicialArray[id], new Rect (0, 0, 280, 180), new Vector2 ());//set the Rect with position and dimensions as you need
        caixaDialogo.text = textos[id-1];
        id++;
    }

    void goToGame(){
        SceneManager.LoadScene("Game");
    }

    void startCutscene(){
        imagem.sprite = Sprite.Create (inicialArray[id], new Rect (0, 0, 280, 180), new Vector2 ());//set the Rect with position and dimensions as you need
        id++;

        if(id <= 7){

        }
    }

    IEnumerator cutsceneInicial(){
        imagem.sprite = Sprite.Create (inicialArray[0], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[1], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[2], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[3], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[4], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[5], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (inicialArray[6], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        id = 7;
    }
}
