using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script snippets from
 * https://github.com/Brackeys/Dialogue-System
 */
public class DialogueManager : MonoBehaviour
{
	[SerializeField] private DialogueBox dialogueBox;
	[SerializeField] private Animator animator;
	[SerializeField] private Dialogue dialogue;

	public Action OnEnd;

	private Queue<Sentence> sentences;
	private bool isOpen;

	void Start()
	{
		sentences = new Queue<Sentence>();
	}

	void Update()
	{
		if (isOpen && (Input.GetKeyDown("space") || Input.GetKeyDown("right") || Input.GetKeyDown("down")))
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue()
	{
		isOpen = true;
		animator.SetBool("IsOpen", true);

		sentences.Clear();

		foreach (Sentence sentence in dialogue.sentences)
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

		(string sentence, Sprite face) = sentences.Dequeue();

		dialogueBox.Display(sentence, face);
	}

	private void EndDialogue()
	{
		OnEnd?.Invoke();

		isOpen = false;
		animator.SetBool("IsOpen", false);
	}

}