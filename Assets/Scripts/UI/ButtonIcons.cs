using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildingIndex;

    public void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.endManager.lvlUnlock, firstLevelBuildingIndex);
        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + firstLevelBuildingIndex <= unlockedLvl)
            {
                lvlButton[i].enabled = true;
                lvlButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else 
            { 
                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite= lockedIcon;
                lvlButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
