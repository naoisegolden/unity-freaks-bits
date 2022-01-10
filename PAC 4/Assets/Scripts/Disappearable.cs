using UnityEngine;

public class Disappearable : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private AudioSource sound;

	public void Disappear()
	{
		if (sound != null) sound.Play();

		if (prefab != null)
		{
			UnityEngine.Object disappear = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
			Destroy(disappear, 1.0f);
		}

		Destroy(gameObject);
	}
}