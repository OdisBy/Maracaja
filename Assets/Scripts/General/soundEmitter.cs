using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEmitter : MonoBehaviour
{
    public AudioController AudioController;
    public FMODUnity.EventReference eventoAnimal;
    public FMOD.Studio.EventInstance instanceFMOD;

    public float somAnimais;

    void Start(){
        instanceFMOD = FMODUnity.RuntimeManager.CreateInstance(eventoAnimal);
        instanceFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            getActualVolume();
            instanceFMOD.setVolume(somAnimais - 50);
            instanceFMOD.start();
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
    }

    public void getActualVolume(){
        somAnimais = PlayerPrefs.GetFloat("somAnimais", 100);
    }
}
