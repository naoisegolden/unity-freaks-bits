using UnityEngine;

/* Script snippets from
 * https://github.com/Brackeys/Dialogue-System
 */
[System.Serializable]
public class Dialogue
{
	public Sprite face;

	[TextArea(3, 10)]
	public string[] sentences;
}