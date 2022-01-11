using System;
using UnityEngine;

[RequireComponent(typeof(Disappearable))]
public class Minion : MonoBehaviour, IDisappearable
{
	public Action OnFound;
	private Disappearable disappearable;

	private void Awake()
	{
		disappearable = GetComponent<Disappearable>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Found();
		}
	}

	private void Found()
	{
		OnFound?.Invoke();
	}

	public void Disappear()
	{
		disappearable.Disappear();
	}
}