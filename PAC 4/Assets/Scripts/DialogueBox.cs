using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
	[SerializeField] private AudioSource speechSound;

	private Text dialogueText;
	private Image faceImage;

	private void Awake()
	{
		dialogueText = GetComponentInChildren<Text>();
		faceImage = gameObject.transform.Find("Face").GetComponent<Image>();
	}
	public void Display(string sentence, Sprite face)
	{
		faceImage.sprite = face;

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			if (Random.Range(0, 3) == 2) speechSound.Play();
			yield return null;
		}
	}
}