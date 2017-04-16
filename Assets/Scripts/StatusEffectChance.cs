using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffects {
    public Status burn;
    public Status paralyze;
    public Status bleed;
    public Status poison;
    public Status cripple;
    public Status blind;
    public Status confuse;
    public Status curse;
    public List<Status> statusEffList = new List<Status>();
    
    public StatusEffects()
    {
        burn = new Status("Burn" ,0);
        paralyze = new Status("Paralyze", 1);
        bleed = new Status("Bleed", 2);
        poison = new Status("Poison", 3);
        cripple = new Status("Cripple", 4);
        blind = new Status("Blind", 5);
        confuse = new Status("Confuse", 6);
        curse = new Status("Curse", 7);
        statusEffList.Add(burn);
        statusEffList.Add(paralyze);
        statusEffList.Add(bleed);
        statusEffList.Add(poison);
        statusEffList.Add(cripple);
        statusEffList.Add(blind);
        statusEffList.Add(confuse);
        statusEffList.Add(curse);
    }
    

}
