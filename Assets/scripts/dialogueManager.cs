using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{

    public Animator animator;

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
        animator.SetBool("isopen", true);
        
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        Content.text = " ";

        foreach(char letter in sentence.ToCharArray())
        {
            Content.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
        {
        animator.SetBool("isopen", false);
        Debug.Log("end convo");
        }
}
