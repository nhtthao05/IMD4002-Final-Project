using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public GameObject textzone;
    public Text title;
    public Text Content;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new Queue<string>();
    }

    public void StartDialogue(object_dialoge dialologue)
    {
        
        Debug.Log("Starting conversation with " + dialologue.name);
        sentences.Clear();

        title.text = dialologue.name;

        foreach (string sentence in dialologue.sentences)
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
        string sentence = sentences.Dequeue();
        Content.text = sentence;
    }
    void EndDialogue()
        {
        Debug.Log("end convo");
        }
}
