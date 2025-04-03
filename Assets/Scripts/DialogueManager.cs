using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text dialogText;
    public Animator animator;
    private Queue<string> sentences;
    private Stack<string> previousSentences;

    private void Start()
    {
        sentences = new Queue<string>();
        previousSentences = new Stack<string>();
    }

    public void StartDialogue(Dialog dialogue)
    {
        animator.SetBool("isOpen", false);
        nameText.text = dialogue.name;
        sentences.Clear();
        previousSentences.Clear();

        foreach (string sentence in dialogue.sentences)
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
        previousSentences.Push(sentence); // Добавляем текущее предложение в стек
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayPreviousSentence()
    {
        if (previousSentences.Count > 0)
        {
            string previousSentence = previousSentences.Pop(); // Получаем предыдущее предложение из стека
            sentences.Enqueue(dialogText.text); // Добавляем текущее предложение обратно в очередь
            StopAllCoroutines();
            StartCoroutine(TypeSentence(previousSentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", true);
        Debug.Log("End of conversation");
    }
}
