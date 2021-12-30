using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
	private Text text;
	private const float interval = 0.5f;

	void Start()
	{
		text = GetComponent<Text>();

		StartCoroutine(BlinkEffect());
	}

	private IEnumerator BlinkEffect()
	{
		while (true)
		{
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a == 0 ? 1 : 0);
			yield return new WaitForSeconds(interval);
		}
 	}
}
