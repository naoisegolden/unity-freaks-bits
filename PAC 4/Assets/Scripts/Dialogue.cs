using UnityEngine;

[System.Serializable]
public struct Sentence
{
	[TextArea(3, 10)]
	public string Text;
	public Sprite Face;

	public void Deconstruct(out string text, out Sprite face)
	{
		text = Text;
		face = Face;
	}
}

/* Script snippets from
 * https://github.com/Brackeys/Dialogue-System
 */
[System.Serializable]
public class Dialogue
{
	public Sentence[] sentences;
}