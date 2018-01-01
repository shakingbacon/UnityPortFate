using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBooga : NPC
{
    public override void GiveLife()
    {
        base.GiveLife();
        Name = "Clean Booga";

        TalkText.Add("Welcome to Booga's Welcome of Fate");

        Quests.Add(new Quest(Quest.QuestType.Slay, "Slay the Gators", "Clean Booga",
        new List<string>()
        {
            "Hey, I need you to kill those Gators.", "There should be a lot on the right side.", "Compelete this quest and I'll reward you."
        },
        new List<string>()
        {
            "Alright then, let me teach you some basics.", "Press the I key to open your inventory. You can equip items from here.",
            "You should equip the weapon in your inventory.", "While holding a weapon, press the X key to perform a basic attack", "Tap repeatedly to combo!"
        },
        new List<string>()
        {
            "You are a fucking retard.", "Do you not want to progress in this game?"
        },
        new List<string>()
        {
            "Go kill the Gators then come back to me."
        },
        new List<string>()
        {
            "Nice job!", "Here's your reward", "I have opened a new portal to the north",
            "Once you go in, you can never come back here", "Make sure you are prepared for the real world"
        },
        "100 Gold / 50 Exp",
        "Clean Booga wants me to slay the Gators around here.",
        new List<QuestGoal>()
        {
            new QuestGoal(QuestGoal.ObjectiveType.Monster, 0, 5, "Slay 5 Gators")
        }));
    }
}
