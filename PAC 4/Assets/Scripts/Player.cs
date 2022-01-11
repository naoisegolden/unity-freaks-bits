using System;
using UnityEngine;

[RequireComponent(typeof(Disappearable))]
public class Player : MonoBehaviour, IDisappearable
{
	public Action OnDie;
	private Disappearable disappearable;
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		disappearable = GetComponent<Disappearable>();
	}

	private void Die()
	{
		animator.SetTrigger("Die");

		OnDie?.Invoke();
	}

	public void Disappear()
	{
		disappearable.Disappear();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Killer"))
		{
			Die();
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Killer"))
		{
			Die();
		}
	}
}