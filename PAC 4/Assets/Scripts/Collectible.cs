using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	public Action OnCollected;
	private new AudioSource audio;

	private void Awake()
	{
		// audio = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			OnCollected?.Invoke();

			audio?.Play();

			UnityEngine.Object collected = Instantiate(Resources.Load("Prefabs/Collected"), gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
			Destroy(collected, 1.0f);
		}
	}
}
