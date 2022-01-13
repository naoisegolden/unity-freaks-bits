using System.Collections;
using UnityEngine;

interface IDisappearable
{
	void Disappear();
}

public class Disappearable : MonoBehaviour
{
	[SerializeField] private GameObject prefab;

	public void Disappear()
	{
		if (prefab != null)
		{
			UnityEngine.Object disappear = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
			Destroy(disappear, 1.0f);
		}

		Destroy(gameObject);
	}
}