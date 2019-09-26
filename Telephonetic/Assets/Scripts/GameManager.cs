
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    private void Start()
    {
        //begin the conversation
        Conversation();
    }

    public void Conversation()
    {
        AudioManager.Instance.PlaySound();
    }
}
