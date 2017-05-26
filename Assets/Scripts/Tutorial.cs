using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public static int instructionIndex = 0;
    public static List<string> instructions;
    public static Text desc;
    public static Text battleDesc;
    public static Button gotIt;
    public static Button skip;
    //public bool pressedMove;
    public static bool equippedItem = false;
    public static bool pressedLearnedSkills = false;

    void Awake()
    {
        skip = gameObject.transform.FindChild("Skip").GetComponent<Button>();
        skip.onClick.AddListener(FinishTutorial);
        gotIt = gameObject.transform.FindChild("Panel").FindChild("Got It").GetComponent<Button>();
        gotIt.onClick.AddListener(GotItButtonPress);
        gotIt.onClick.AddListener(() => SoundDatabase.PlaySound(32));
        desc = gameObject.transform.FindChild("Panel").FindChild("Desc").GetComponent<Text>();
        battleDesc = gameObject.transform.FindChild("Battle Panel").FindChild("Desc").GetComponent<Text>();
        instructions = new List<string>();
        instructions.Add("Use the WASD Keys\nor\nUse the Arrow Keys to move"); //1
        instructions.Add("Press [I] to open and close your Inventory (you can also use the Escape Key to close)"); // 2
        instructions.Add("You equip items from your Inventory. Click the Wand that has just been put in your inventory and put it in the Weapon Slot"); // 3
        instructions.Add("Press [K] to open and close your Skills Page"); // 4
        instructions.Add("In the Skill Page, you can learn and rank up Skills using 1 SP."); // 5
        instructions.Add("Learned Skills will be placed in the Learned Skills Tab. Press the Learned Skills Button in the bottom left of the Skill Page.\nWe can see we have 2 learned Basic Attack Skills"); // 6
        instructions.Add("Now lets get ready for a battle and defeat an enemy!"); // 7
        instructions.Add("Now lets see how to use the Quick Skills Button.\nIn the Learned Skills Tab there will be a yellow button called Quick Skills"); // 8
        instructions.Add("After Pressing this button, we are now allowed to add Skills to our Quick Skills.\nPress the Quick Skills button and add the 2 Skills we have.\nYou can remove Quick Skills by pressing them in the bottom right.\nThen lets battle again!"); //9
        instructions.Add("You now know all the basics! Explore the World of Booga for more experience.");
        GotItButtonPress();
        GameManager.inTutorial = true;
    }
    void Update()
    {
        switch (instructionIndex)
        {
            case 1:
                {
                    if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
                    {
                        gotIt.interactable = true;
                    }
                    break;
                }
            case 2:
                {
                    if (Input.GetButtonDown("Inventory"))
                    {
                        gotIt.interactable = true;
                    }
                    break;
                }
            case 3:
                {
                    if (equippedItem)
                    {
                        gotIt.interactable = true;
                    }
                    break;
                }
            case 4:
                {
                    if (Input.GetButtonDown("Skill"))
                    {
                        gotIt.interactable = true;
                    }
                    break;
                }
            case 5:
                {
                    gotIt.interactable = true;
                    break;
                }
            case 6:
                {
                    if (pressedLearnedSkills)
                    {
                        gotIt.interactable = true;
                    }
                    break;
                }
            case 7:
                {
                    gotIt.interactable = true;
                    break;
                }
            case 8:
                {
                    gotIt.interactable = true;
                    break;
                }
            case 9:
                {
                    if (QuickSkills.quickSkillGameObject.childCount == 2)
                    {
                        gotIt.interactable = true;
                    }
                    else
                    {
                        gotIt.interactable = false;
                    }
                    break;
                }
            case 10:
                {
                    gotIt.interactable = true;
                    break;
                }
        }
    }

    public static void FinishTutorial()
    {
        GameManager.player.skillPoints = 1; // so player cant rank them during tutorial
        GameManager.inTutorial = false;
        if (!Inventory.HasItem(1000))
        {
            Inventory.AddItem(1000);
        }
        foreach (GameObject tutorial in GameObject.FindGameObjectsWithTag("Tutorial"))
        {
            Destroy(tutorial);
        }
        GameManager.player.HealFullHP();
        GameManager.player.HealFullMP();
        SoundDatabase.PauseMusic();
        if (!GameManager.inIntro)
        {
            SoundDatabase.PlaySound(36);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Hometown").transform.FindChild("After Tutorial Position").position.x, GameObject.FindGameObjectWithTag("Hometown").transform.FindChild("After Tutorial Position").position.y);
            Camera.main.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    public static void GotItButtonPress()
    {
        if (instructions.Count == instructionIndex)
        {
            desc.text = "Alright! You have completed\nthe tutorial! Bye!";
            gotIt.onClick.RemoveAllListeners();
            gotIt.onClick.AddListener(FinishTutorial);
            gotIt.gameObject.GetComponentInChildren<Text>().text = "Finish";
        }
        else
        {
            desc.text = instructions[instructionIndex];
            instructionIndex += 1;
            gotIt.interactable = false;
            switch (instructionIndex)
            {
                case 3:
                    {
                        Inventory.AddItem(1000);
                        break;
                    }
                case 7:
                    {

                        gotIt.gameObject.GetComponentInChildren<Text>().text = "Battle!";
                        gotIt.onClick.AddListener(() => Battle.SetupBattle(EnemyDatabase.GetEnemy(4)));
                        break;
                    }
                case 8:
                    {
                        battleDesc.text = "Press the Skills Button below or press [K] to open the Skills Page.\nPress a Skill to use it.";
                        battleDesc.gameObject.transform.parent.gameObject.SetActive(true);
                        skip.gameObject.SetActive(false);
                        gotIt.gameObject.transform.parent.gameObject.SetActive(false);
                        gotIt.onClick.RemoveAllListeners();
                        gotIt.onClick.AddListener(GotItButtonPress);
                        gotIt.onClick.AddListener(() => SoundDatabase.PlaySound(32));
                        gotIt.gameObject.GetComponentInChildren<Text>().text = "Got it!";
                        break;
                    }
                case 9:
                    {
                        gotIt.onClick.AddListener(() => Battle.SetupBattle(EnemyDatabase.GetEnemy(4)));
                        gotIt.gameObject.GetComponentInChildren<Text>().text = "Battle!";
                        break;
                    }
                case 10:
                    {
                        gotIt.onClick.RemoveAllListeners();
                        gotIt.onClick.AddListener(GotItButtonPress);
                        gotIt.onClick.AddListener(() => SoundDatabase.PlaySound(32));
                        battleDesc.text = "You can see to the left of the Skills Button we have the 2 Quick Skills.\nInstead of using them from the Skills Page, we can use them from here.";
                        battleDesc.gameObject.transform.parent.gameObject.SetActive(true);
                        skip.gameObject.SetActive(false);
                        gotIt.gameObject.transform.parent.gameObject.SetActive(false);
                        gotIt.gameObject.GetComponentInChildren<Text>().text = "Got it!";
                        break;
                    }
            }
        }
    }

}