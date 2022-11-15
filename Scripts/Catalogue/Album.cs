using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Album : MonoBehaviour
{
    public TextMeshProUGUI nomeAnimal;
    public Image tamanduaFoto;
    public Image ararajubaFoto;
    public Image macacoFoto;
    public Image oncaFoto;

    public AnimalPageTemplate[] allAnimals;  

    void Start()
    {
        updateInfos();
    }

    public void updateInfos()
    {
        if(allAnimals[0].isUnlocked)
        {
            tamanduaFoto.sprite = allAnimals[0].FotoReal;
        }
        if(allAnimals[1].isUnlocked)
        {
            ararajubaFoto.sprite = allAnimals[1].FotoReal;
        }
        if(allAnimals[2].isUnlocked)
        {
            macacoFoto.sprite = allAnimals[2].FotoReal;
        }
        if(allAnimals[3].isUnlocked)
        {
            oncaFoto.sprite = allAnimals[3].FotoReal;
        }
    }
}
