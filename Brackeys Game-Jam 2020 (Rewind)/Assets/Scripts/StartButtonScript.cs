using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{

    public PlayerController playerController;
    public void GetStartet()
    {
        playerController.startGame = true;
    }
}
