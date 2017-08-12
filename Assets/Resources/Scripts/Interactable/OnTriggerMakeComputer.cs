using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerMakeComputer : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        SoundDatabase.PlaySound(21);
        ComputerScreen.computer.gameObject.SetActive(true);
        GameManager.cantMove = true;
    }
}
