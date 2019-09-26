using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private KeyCode[] numpadKeys =
    new KeyCode[6]
    {
        KeyCode.Keypad0,
        KeyCode.Keypad1,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad6,
        KeyCode.Keypad8
    };

    public int answer;

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < numpadKeys.Length; i++)
            if (Input.GetKeyUp(numpadKeys[i]))
                AudioManager.Instance.PlaySound(i,answer);
    }
}

