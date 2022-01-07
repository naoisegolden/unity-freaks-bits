using UnityEngine;
using UnityEngine.UI;

/* Script snippets from
 * https://medium.com/nerd-for-tech/player-movement-in-unity-2d-using-rigidbody2d-4f6f1693d730
 */
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 5.0f;
	[SerializeField] private float jumpPower = 5.0f;
	[SerializeField] private FixedJoystick joystick;
	[SerializeField] private Button action;

	private Rigidbody2D _rb;
	private Animator _animator;
	private SpriteRenderer _renderer;
	private BoxCollider2D _collider;

	private float dirX;
	private bool isGrounded = false;
	private bool canDoubleJump = false;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_renderer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<BoxCollider2D>();

		action.onClick.AddListener(ActionHandler);
	}
	private void Update()
	{
		MovePlayer();

		if (Input.GetButtonDown("Jump"))
		{
			ActionHandler();
		}

		UpdateAnimation();
	}
	private void MovePlayer()
	{
		dirX = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
		_rb.velocity = new Vector2(dirX * playerSpeed, _rb.velocity.y);
	}
	private void Jump()
	{
		_rb.velocity = new Vector2(0, jumpPower);
		isGrounded = false;
	}

	private void ActionHandler()
	{
		if (isGrounded)
		{
			Jump();
			canDoubleJump = true;
		}
		else if (canDoubleJump)
		{
			Jump();
			canDoubleJump = false;
			_animator.SetTrigger("DoubleJump");
		}
	}

	private void UpdateAnimation()
	{
		// Run animation
		_animator.SetFloat("Speed", Mathf.Abs(dirX));

		// Facing direction
		if (dirX > 0)
		{
			_renderer.flipX = false;
		}
		else if (dirX < 0)
		{
			_renderer.flipX = true;
		}

		// Jump animations
		if (_rb.velocity.y > 0.1f)
		{
			_animator.SetBool("IsJumping", true);
		}
		else if (_rb.velocity.y < -0.1f)
		{
			_animator.SetBool("IsJumping", false);
			_animator.SetBool("IsFalling", true);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			// End jump
			isGrounded = true;
			_animator.SetBool("IsFalling", false);
		}
	}
}