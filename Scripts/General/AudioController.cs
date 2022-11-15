using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    int actualPlayer;
    public AudioSource Foto;
    public AudioSource passo;
    public AudioSource escalando;
    public AudioSource CairChao;
    public AudioSource Caindo;
    public AudioSource pulando;
    public AudioSource Zoom;
    public AudioClip[] ararajuba;
    public AudioClip[] gatoMiado;

    public void foto(){
        Foto.Play();
    }
    public void Passo(){
        passo.Play();
    }
    public void Escalando(){
        escalando.Play();
    }
    public void CairNoChao(){
        CairChao.Play();
    }
    public void caindo(){
        Caindo.Play();
    }
    public void Pulando(){
        pulando.Play();
    }
    public void zoom(){
        Zoom.Play();
    }

    public void ararajubaSom(){
        
        actualPlayer = Random.Range(0, 2);
        audioSource.clip = ararajuba[actualPlayer]; 
        audioSource.Play();
    }

    public void miadoGato(){
        actualPlayer = Random.Range(0, 2);
        audioSource.clip = gatoMiado[actualPlayer]; 
        audioSource.Play();
    }

}
