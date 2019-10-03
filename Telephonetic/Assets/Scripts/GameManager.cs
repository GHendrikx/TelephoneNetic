 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    //begin the conversation
    private void Start() =>    
        StartGame();
    

    public void StartGame() =>
        AudioManager.Instance.PlaySound();
    
}
