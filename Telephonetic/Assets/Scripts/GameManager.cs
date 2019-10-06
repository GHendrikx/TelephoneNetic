
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public uint fuckedUp;
   

    // Start is called before the first frame update
    private void Start()
    {

        //begin the conversation
        StartGame();
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySound();
    }
    public void EndGame()
    {
        //ending the game
    }
}
