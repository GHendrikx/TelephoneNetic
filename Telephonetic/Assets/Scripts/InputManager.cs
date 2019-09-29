using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    //REMEMBER TO CHANGE NUMPAD BACK AFTER TESTINGs
    private KeyCode[] numpadKeys =
    new KeyCode[6]
    {
        KeyCode.Keypad0,
        KeyCode.Keypad1,
        KeyCode.Keypad2,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad5
    };

    public int answer;

    // Update is called once per frame
    void Update()
    {
        //Play a ring tone and check for Phone being picked up
        if(Input.GetKeyUp(KeyCode.Space) && !AudioManager.Instance.audioPlaying)
        {
            AudioManager.Instance.PlayQuestion();
        }
        for (int i = 0; i < numpadKeys.Length; i++)
            if (Input.GetKeyUp(numpadKeys[i]) && !AudioManager.Instance.audioPlaying && !AudioManager.Instance.phoneRinging)
            {
                Debug.Log(i);
                AudioManager.Instance.PlayAnswer(i);
            }
    }
}

