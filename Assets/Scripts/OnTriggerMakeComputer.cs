using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerMakeComputer : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        ComputerScreen.computer.gameObject.SetActive(true);
    }
}
