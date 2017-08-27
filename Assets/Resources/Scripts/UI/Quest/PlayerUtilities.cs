using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities : MonoBehaviour {

    static Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public static void AddCash(int amount)
    {
        player.AddCash(amount);
        print(player.Cash);
    }

    
	
}
