using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompletedActivations : MonoBehaviour
{

    // please write what it does

    public static void ActivateQuestCompletionAction(string id)
    {
        switch (id)
        {
            case "Slay the Gators":
                {
                    UIEventHandler.MoneyAdded(100);
                    PlayerLevel.ExpAdded(50);
                    TutorialArea.questComplete = true; TutorialArea.OpenHometownWarp(); break;
                } // finsh tutorial quest to open up hometown portal
        }
    }
}
