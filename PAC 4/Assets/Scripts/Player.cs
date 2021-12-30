using UnityEngine;

public class Player : MonoBehaviour
{
	private Animator _animator;
	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Die()
	{
		_animator.SetTrigger("Die");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Killer"))
		{
			Die();
		}

	}
}