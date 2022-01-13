using System;
using UnityEngine;

[RequireComponent(typeof(Disappearable))]
public class Player : MonoBehaviour, IDisappearable
{
	[SerializeField] private AudioSource dieSound;

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
		dieSound.Play();

		OnDie?.Invoke();
	}

	public void Stop()
	{
		PlayerMovement movement = GetComponent<PlayerMovement>();
		if (movement != null)
		{
			movement.Stop();
		}
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