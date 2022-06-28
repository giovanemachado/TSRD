using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueSpace;
    public TMPro.TextMeshProUGUI dialogueText;
    public Dialogue intro;

    bool notStarted = false;

    Queue<string> sentences;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (!dialogueSpace.activeSelf)
        {
            return;
        }

        if (!notStarted)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        notStarted = true;
        sentences.Clear();

        foreach(string sentence in intro.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = sentences.Dequeue();
    }

    void EndDialogue()
    {
        dialogueSpace.SetActive(false);
    }
}
