using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class cutSceneDiaNoite : MonoBehaviour
{
    public GameObject imagemGO;
    public Image imagem;
    public Texture2D[] diaParaNoiteArray;
    public Texture2D[] noiteParaDiaArray;
    public Texture2D[] final;
    public TextMeshProUGUI textfinal;
    public string[] textoproFinal;
    public AudioController audioController;
    public PlayerScript player;

    public void diaParaNoite(){
        imagemGO.SetActive(true);
        StartCoroutine(cutsceneND());
    }
    public void noiteParaDia(){
        imagemGO.SetActive(true);
        StartCoroutine(cutsceneDN());
    }


    public void finalJogo(){
        imagemGO.SetActive(true);
        StartCoroutine(cutsceneFIM());
    }
    IEnumerator cutsceneDN(){
        player.canMove = false;
        imagem.sprite = Sprite.Create (diaParaNoiteArray[0], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (diaParaNoiteArray[1], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (diaParaNoiteArray[2], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (diaParaNoiteArray[3], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (diaParaNoiteArray[4], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        audioController.diaNoite();

        imagem.sprite = Sprite.Create (diaParaNoiteArray[5], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (diaParaNoiteArray[6], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (diaParaNoiteArray[7], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (diaParaNoiteArray[8], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (diaParaNoiteArray[9], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.5f);
        player.canMove = true;
        imagemGO.SetActive(false);
    }

    IEnumerator cutsceneND(){
        player.canMove = false;
        imagem.sprite = Sprite.Create (noiteParaDiaArray[0], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (noiteParaDiaArray[1], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (noiteParaDiaArray[2], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (noiteParaDiaArray[3], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (noiteParaDiaArray[4], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        audioController.diaNoite();

        imagem.sprite = Sprite.Create (noiteParaDiaArray[5], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);

        imagem.sprite = Sprite.Create (noiteParaDiaArray[6], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (noiteParaDiaArray[7], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (noiteParaDiaArray[8], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.2f);
        imagem.sprite = Sprite.Create (noiteParaDiaArray[9], new Rect (0, 0, 280, 180), new Vector2 ());
        yield return new WaitForSecondsRealtime(0.5f);
        player.canMove = true;
        imagemGO.SetActive(false);
    }

    IEnumerator cutsceneFIM(){
        player.canMove = false;
        imagem.sprite = Sprite.Create (final[0], new Rect (0, 0, 280, 180), new Vector2 ());
        textfinal.text = textoproFinal[0];
        yield return new WaitForSecondsRealtime(5f);

        imagem.sprite = Sprite.Create (final[1], new Rect (0, 0, 280, 180), new Vector2 ());
        textfinal.text = textoproFinal[1];
        yield return new WaitForSecondsRealtime(4f);

        imagem.sprite = Sprite.Create (final[2], new Rect (0, 0, 280, 180), new Vector2 ());
        textfinal.text = textoproFinal[2];
        yield return new WaitForSecondsRealtime(6f);

        imagem.sprite = Sprite.Create (final[3], new Rect (0, 0, 280, 180), new Vector2 ());
        textfinal.text = textoproFinal[3];
        yield return new WaitForSecondsRealtime(5f);

        imagem.sprite = Sprite.Create (final[4], new Rect (0, 0, 280, 180), new Vector2 ());
        textfinal.text = textoproFinal[4];
        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene("Fim");
    }
}
