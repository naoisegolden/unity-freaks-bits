using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Action OnDie;

	private Animator _animator;
	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Die()
	{
		_animator.SetTrigger("Die");

		OnDie?.Invoke();
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