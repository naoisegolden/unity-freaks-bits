using UnityEngine;

public class Patrol : MonoBehaviour
{
	[SerializeField] private float speed = 1f;
	private Animator animator;
	private Rigidbody2D rb;
	private float horizontalDirection;
	private float dirX;
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		horizontalDirection = -Mathf.Sign(transform.localScale.x);
	}

	private void Update()
	{
		Move();
		UpdateAnimation();
	}

	void Move()
	{
		dirX = horizontalDirection;
		rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

	}

	private void Flip()
	{
		horizontalDirection *= -1;

		// Flip game object in x
		transform.Rotate(0f, 180f, 0f);
	}

	private void UpdateAnimation()
	{
		// Run animation
		animator.SetFloat("Speed", Mathf.Abs(dirX));
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		// NOTE: I could change this to only collide with certain layer elements

		// Detect direction of contact
		ContactPoint2D contact = other.GetContact(0);
		float collisionDirectionX = contact.normal.x > 0 ? -1 : 1;

		// Flip when colliding on x
		if (Mathf.Sign(horizontalDirection * collisionDirectionX) > 0)
		{
			Flip();
		}
	}
}