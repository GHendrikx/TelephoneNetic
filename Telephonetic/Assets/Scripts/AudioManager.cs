using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip phoneRing;
    public AudioClip pickUpSound;
    public AudioClip transferCallSound;
    public AudioClip intro;
    public AudioClip winState;
    public AudioClip lossState;
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
    private int myUserInput = 0;
    //added audioPlaying to prevent spamming keys
    public bool audioPlaying = false;
    bool gameOver = false;

    public void PlayQuestion()
    {
        //reset loop for Ring
        phoneRinging = false;
        audioSource.loop = false;
        //audioSource.clip = pickUpSound;
        //audioSource.Play();
        //audioPlaying = true;
        //StartCoroutine(interfaceSounds(pickUpSound));
        //audioSource.clip = incomingCallAudio[IncomingCallIndex];
        //audioSource.Play();
        
        StartCoroutine(CheckIfSoundIsOver(incomingCallAudio[IncomingCallIndex], CallType.IncomingCall));
        //IncomingCallIndex++;


    }

    public void PlayAnswer(int userInput)
    {
        phoneRinging = false;
        audioPlaying = true;
        
        //if user input matches the room number of the current call (saved in index), it will play correct response
        if (userInput == correctResponses[responsesIndex].index)
        {
            Debug.Log("Correct Response");
            //audioPlaying = true;
            //audioSource.clip = correctResponses[responsesIndex].audio;
            //audioSource.Play();
            //audioPlaying = true;
            StartCoroutine(CheckIfSoundIsOver(correctResponses[responsesIndex].audio, CallType.Answer));
            //responsesIndex++;
        }

        //if the response doesnt match, it will play an error sound corresponding to that room (user input)
        else
        {
            Debug.Log("Wrong response");
            //phoneRinging = false;
            //GameManager.Instance.fuckedUp++;
            //audioSource.clip = wrongResponses[userInput].audio;
            //audioSource.Play();
            //audioPlaying = true;
            myUserInput = userInput;
            StartCoroutine(CheckIfSoundIsOver(wrongResponses[userInput].audio, CallType.WrongResponse));
            
            
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

    public IEnumerator CheckIfSoundIsOver(AudioClip clip, CallType call)
    {
        //play correct interface sounds
        audioPlaying = true;
        if (call == CallType.IncomingCall)
        {
            audioSource.clip = pickUpSound;
            audioSource.Play();
        } else if (call == CallType.Answer)
        {
            audioSource.clip = transferCallSound;
            audioSource.Play();
        }
        else if (call == CallType.WrongResponse)
        {
            audioSource.clip = transferCallSound;
            audioSource.Play();
        }

        yield return new WaitForSeconds(pickUpSound.length);

        // play correct audio 
        if(call == CallType.IncomingCall)
        {
            audioSource.clip = incomingCallAudio[IncomingCallIndex];
            audioSource.Play();
            audioPlaying = true;
            IncomingCallIndex++;
        } else if( call== CallType.Answer)
        {
            audioSource.clip = correctResponses[responsesIndex].audio;
            audioSource.Play();
            audioPlaying = true;
            responsesIndex++;
        }
        else if (call == CallType.WrongResponse)
        {
            
            GameManager.Instance.fuckedUp++;
            audioSource.clip = wrongResponses[myUserInput].audio;
            audioSource.Play();
            audioPlaying = true;
        }


        yield return new WaitForSeconds(clip.length);
        audioPlaying = false;
        // add indexes of pranks

        if (call != CallType.IncomingCall || (call == CallType.IncomingCall && (IncomingCallIndex == 1 || IncomingCallIndex == 7 || IncomingCallIndex == 11)))
        {
            if (call == CallType.IncomingCall || call == CallType.WrongResponse)
            {
                responsesIndex++;
            }
            yield return new WaitForSeconds(2);
            if (GameManager.Instance.fuckedUp >= 3 && !gameOver)
            {
                incomingCallAudio[IncomingCallIndex] = lossState;
                PlaySound();
                gameOver = true;
                
            }
            else
            {
                if(!gameOver)
                PlaySound();
            }
                
            

      
        }

        

    }

  

    
}
public enum CallType
{
    Answer,
    IncomingCall,
    WrongResponse,
    PrankCalls,
    PhoneSounds
}

[System.Serializable]
public struct IncomingCall
{
    public int index;
    public AudioClip audio;
}
