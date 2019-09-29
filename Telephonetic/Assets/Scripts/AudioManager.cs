using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip phoneRing;
    public bool phoneRinging = true;
    [SerializeField]
    private AudioSource audioSource;
    //incoming Call audio has the intro and incoming calls
    [SerializeField]
    private AudioClip[] incomingCallAudio;
    //Calls have correct responses 
    [SerializeField]
    private IncomingCall[] correctResponses;
    [SerializeField]
    private IncomingCall[] wrongResponses;
    private int IncomingCallIndex = 0;
    private int responsesIndex = 0;
    //added audioPlaying to prevent spamming keys
    public bool audioPlaying = false;

    public void PlayQuestion()
    {
        //reset loop for Ring
        phoneRinging = false;
        audioSource.loop = false;
        audioSource.clip = incomingCallAudio[IncomingCallIndex];
        audioSource.Play();
        audioPlaying = true;
        StartCoroutine(CheckIfSoundIsOver(incomingCallAudio[IncomingCallIndex], Call.IncomingCall));
        IncomingCallIndex++;
        

    }

    public void PlayAnswer(int userInput)
    {
        phoneRinging = false;
        audioPlaying = true;
        //if user input matches the room number of the current call (saved in index), it will play correct response
        if (userInput == correctResponses[responsesIndex].index)
        {
            audioSource.clip = correctResponses[responsesIndex].audio;
            audioSource.Play();
            audioPlaying = true;
            StartCoroutine(CheckIfSoundIsOver(correctResponses[responsesIndex].audio, Call.Answer));
            responsesIndex++;
        }

        //if the response doesnt match, it will play an error sound corresponding to that room (user input)
        else
        {
            phoneRinging = false;
            Debug.Log("Wrong buddy");
            audioSource.clip = wrongResponses[userInput].audio;
            audioSource.Play();
            audioPlaying = true;
            StartCoroutine(CheckIfSoundIsOver(wrongResponses[userInput].audio, Call.WrongResponse));
            responsesIndex++;
        }
            
    }

    //Play the ring sound
    public void PlaySound()
    {
        phoneRinging = true;
        audioSource.clip = phoneRing;
        audioSource.loop = true;
        audioSource.Play();
       
        //InputManager.Instance.answer = ;
    }

    public IEnumerator CheckIfSoundIsOver(AudioClip clip, Call call)
    {
        
        yield return new WaitForSeconds(clip.length);
        audioPlaying = false;
        if (call != Call.IncomingCall)
        {
            yield return new WaitForSeconds(3);
            PlaySound();
        }
 
    }

}
public enum Call
{
    Answer,
    IncomingCall,
    WrongResponse
}

[System.Serializable]
public struct IncomingCall
{
    public int index;
    public AudioClip audio;
}
