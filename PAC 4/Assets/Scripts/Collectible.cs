using System;
using UnityEngine;

public class Collectible : MonoBehaviour, IDisappearable
{
	public Action OnCollected;
	private Disappearable disappearable;

	private void Awake()
	{
		disappearable = GetComponent<Disappearable>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Disappear();
		}
	}

	public void Disappear()
	{
		OnCollected?.Invoke();

		disappearable.Disappear();
	}
}
