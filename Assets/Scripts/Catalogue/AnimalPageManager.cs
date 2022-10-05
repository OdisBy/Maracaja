using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalPageManager : MonoBehaviour
{
    public TextMeshProUGUI info1;
    public TextMeshProUGUI info2;
    [SerializeField]
    [TextArea(3, 30)]
    private string defaultInfo1;
    [SerializeField]
    [TextArea(3, 30)]
    private string defaultInfo2;
    [SerializeField]
    private Sprite unlockedSprite;
    public Image foto;
    public int actualId;
    public AnimalPageTemplate[] allAnimals;
    public GameObject itemGO;
    public Image itemImage;

    void Start()
    {
        Debug.Log("Startando animalpagemanager");
        PlayerPrefs.SetInt("animalPageId", 0);
        actualId = PlayerPrefs.GetInt("animalPageId", 0);
        updateInfos();
    }

    public void updateInfos()
    {
        actualId = PlayerPrefs.GetInt("animalPageId", 0);
        if(allAnimals[actualId].isUnlocked)
        {
            foto.sprite = allAnimals[actualId].foto;
            info1.text = allAnimals[actualId].infos_1;
            info2.text = allAnimals[actualId].infos_2;

            if(allAnimals[actualId].questFineshed)
            {
                itemGO.SetActive(true);
                itemImage.sprite = allAnimals[actualId].fotoItem;
            }
        }else{
            foto.sprite	= allAnimals[actualId].fotoBloqueada;
            info1.text = defaultInfo1;
            info2.text = defaultInfo2;
            itemGO.SetActive(false);
        }
    }
}
