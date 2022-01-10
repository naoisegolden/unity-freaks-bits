using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	public Action OnCollected;
	public Disappearable disappearable;

	private void Awake()
	{
		disappearable = GetComponent<Disappearable>();

		if (disappearable == null)
		{
			disappearable = gameObject.AddComponent<Disappearable>() as Disappearable;
			Debug.LogWarning("A game object with Collectible should also have Disappearable.");
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Collected();
		}
	}

	public virtual void Collected()
	{
		OnCollected?.Invoke();

		disappearable.Disappear();
	}
}
