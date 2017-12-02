using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NPCInfo {

    public string npcName;
    public int npcID;

    public int[][] npcDialogueOptionsText;
    public List<DialogueOption> dialogueOptions;
    public List<string> defaultText;


    [JsonConstructor]
    public NPCInfo(string name, int npcid, int[][] option, List<string> defualt)
    {
        npcName = name;
        npcID = npcid;
        npcDialogueOptionsText = option;    
        defaultText = defualt;

    }


}

public class DialogueOption {

    public OptionType optionType;
    public int optionID;

	public enum OptionType{
		Talk, 
		Shop,
		Quest
	}

    public DialogueOption(int type, int id)
    {
        optionType = (OptionType)type;
        optionID = id;
    }
}
