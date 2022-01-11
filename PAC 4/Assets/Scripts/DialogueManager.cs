using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] private Text dialogueText;
	[SerializeField] private Animator animator;

	public Action OnEnd;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();

		// StartDialogue();
	}

	// public void StartDialogue(Dialogue dialogue)
	public void StartDialogue()
	{
		animator.SetBool("IsOpen", true);

		string[] dialogue = new string[3] {
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor",
			"Sed ut perspiciatis unde omnis iste natus error",
			"Quis autem vel eum iure reprehenderit",
		};

		sentences.Clear();

		// foreach (string sentence in dialogue.sentences)
		foreach (string sentence in dialogue)
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

	private IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	private void EndDialogue()
	{
		OnEnd?.Invoke();

		animator.SetBool("IsOpen", false);
	}

}