using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;
    private string targetMsg;
    Text msgText;
    AudioSource audioSource;

    int textIndex;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
        
    }
    public bool isAnim;
    float interval;
    void EffectStart()
    {
        msgText.text = "";
        textIndex = 0;
        EndCursor.SetActive(false);
        interval = 1.0f / CharPerSeconds;

        isAnim = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[textIndex];
        if(targetMsg[textIndex] != ' ' || targetMsg[textIndex] != '.')
        {
            audioSource.Play();
        }
        textIndex++;
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }


}
