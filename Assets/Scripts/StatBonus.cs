﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus  {
    public int BonusValue { get; set; }

    public StatBonus(int bonus)
    {
        this.BonusValue = bonus;
        Debug.Log("New stat bonus init");
    }

}
