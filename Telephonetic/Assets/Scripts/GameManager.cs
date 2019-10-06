
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private uint fuckedUp;
    public uint FuckedUp
    {
        get
        {
            return fuckedUp;
        }
        set
        {
            FuckedUp = value;
        }
    }

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
