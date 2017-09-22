using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemOptionSelectController : MonoBehaviour {

    GameObject optionSelectPanel;

    int CurrentOptionIndex { get; set; }

    void Start()
    {
        optionSelectPanel = DialogueSystem.Instance.optionSelectPanel;
    }

    void Update()
    {
        if (optionSelectPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {
                DialogueSystem.Instance.CurrentDialogue = optionSelectPanel.transform.GetChild(CurrentOptionIndex).GetComponent<DialogueSystemOptionObject>().option;
                SoundDatabase.PlaySound(21);
                optionSelectPanel.transform.GetChild(CurrentOptionIndex).GetComponent<DialogueSystemOptionObject>().optionButton.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (CurrentOptionIndex + 1 < optionSelectPanel.transform.childCount)
                {
                    AddCurrentOptionIndex(1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (CurrentOptionIndex - 1 >= 0)
                {
                    AddCurrentOptionIndex(-1);
                }
                else
                {
                    SetCurrentOptionIndex(0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                if (CurrentOptionIndex + 3 < optionSelectPanel.transform.childCount)
                {
                    AddCurrentOptionIndex(3);
                }
                else
                {
                    SetCurrentOptionIndex(optionSelectPanel.transform.childCount - 1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                if (CurrentOptionIndex - 3 >= 0)
                {
                    AddCurrentOptionIndex(-3);
                }
                else
                {
                    SetCurrentOptionIndex(0);
                }
            }
        }
    }

    void SetCurrentOptionIndex(int amount)
    {
        LeavingCurrentOption();
        CurrentOptionIndex = amount;
        PointAtCurrentOption();
        SoundDatabase.PlaySound(34);
    }

    void AddCurrentOptionIndex(int amount)
    {
        LeavingCurrentOption();
        CurrentOptionIndex += amount;
        PointAtCurrentOption();
        SoundDatabase.PlaySound(34);
    }

    public void StartOptionSelect()
    {
        CurrentOptionIndex = 0;
    }


    void LeavingCurrentOption()
    {
        Transform option = optionSelectPanel.transform.GetChild(CurrentOptionIndex);
        option.GetComponent<Image>().enabled = false;
    }

    void PointAtCurrentOption()
    {
        Transform option = optionSelectPanel.transform.GetChild(CurrentOptionIndex);
        option.GetComponent<Image>().enabled = true;
    }




}
