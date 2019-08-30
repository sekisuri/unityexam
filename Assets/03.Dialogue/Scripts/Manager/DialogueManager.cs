using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    [SerializeField] GameObject interEvent;
    Dialogue[] dialogues;

    bool isDialogue = false; // 대화중일 경우 true.
    bool isNext = false; // 특정 키 입력 대기.

    int lineCount = 0;
    int contextCount = 0;

    private void Start()
    {
        ShowDialogue(interEvent.transform.GetComponent<InteractionEvent>().GetDialogue());
        
    }
    private void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    
                    contextCount++;
                    if(contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;
                        lineCount++;
                        if(lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else
                        {
                            EndDialogue();
                        }
                    }

#if true
                    Debug.Log("Space ");
#endif

                    
                    
                }
            }
        }
    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUI(false);
    }
    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;
        //SettingUI(true);
        StartCoroutine(TypeWriter());
    }

    IEnumerator TypeWriter()
    {
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("`", ",");

#if true
        Debug.Log("대화 : " + t_ReplaceText);
#endif

        txt_Dialogue.text = t_ReplaceText;
        txt_Name.text = dialogues[lineCount].name;
        isNext = true;
        yield return null;
    }
    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
