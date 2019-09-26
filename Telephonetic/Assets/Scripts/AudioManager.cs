using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioConversation;
    [SerializeField]
    private IncomingCall[] calls;
    private int index = 0;
    public void PlaySound(int index, int answer)
    {
        if (index == answer)
            audioSource.clip = calls[index].audio;
        else
            Debug.Log("Wrong buddy");
    }

    public void PlaySound()
    {
        audioSource.clip = audioConversation[index];
        index++;
        GameManager.Instance.Conversation();
        //InputManager.Instance.answer = ;
    }

    public IEnumerator CheckIfSoundIsOver(Call call)
    {
        if (call == Call.Answer)
            yield return new WaitForSeconds(audioConversation[index].length);
        else
            yield return new WaitForSeconds(calls[index].audio.length);
        yield return null;

    }

}
public enum Call
{
    Answer,
    IncomingCall
}

[System.Serializable]
public struct IncomingCall
{
    public int index;
    public AudioClip audio;
}
