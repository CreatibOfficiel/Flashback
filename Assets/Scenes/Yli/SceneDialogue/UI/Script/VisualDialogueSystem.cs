using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualDialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static VisualDialogueSystem instance;

    public GameObject speechPannel;
    public Text speechText;
    public AudioSource blip;
    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;
    public bool stop = false;


    void SoundPlay(AudioSource sound) { if (!sound.isPlaying) { sound.Play(); } }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine speaking = null;

    string targetSpeech = "";
    public void Say(string speech, bool additive = false)
    {
        StopSpeaking();
        speechText.text = targetSpeech;
        speaking =  StartCoroutine(Speaking(speech,additive));

    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }

IEnumerator Speaking(string speech, bool additive)
    {
        speechPannel.SetActive(true);
        targetSpeech = speech;
        if (!additive)
        {
            speechText.text = "";
        }
        else
        {
            targetSpeech = speechText.text + targetSpeech;
        }
        
        isWaitingForUserInput = false;

        while(speechText.text != targetSpeech)
        {
            stop = false;
            speechText.text += targetSpeech[speechText.text.Length];
            SoundPlay(blip);
            yield return new WaitForSeconds(0.035f);
        }
        isWaitingForUserInput = true;
        while (isWaitingForUserInput)
        {
            yield return new WaitForEndOfFrame();
            StopSpeaking();
            stop = true;
        }
    }

  

}
