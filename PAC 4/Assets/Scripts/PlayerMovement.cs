using UnityEngine;
using UnityEngine.UI;

/* Script snippets from
 * https://medium.com/nerd-for-tech/player-movement-in-unity-2d-using-rigidbody2d-4f6f1693d730
 */
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 4.0f;
	[SerializeField] private float jumpPower = 7.0f;
	[SerializeField] private FixedJoystick joystick;
	[SerializeField] private Button action;
	[SerializeField] private ParticleSystem dust;
	[SerializeField] private AudioSource jumpSound1;
	[SerializeField] private AudioSource doubleJumpSound;

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

		action.onClick.AddListener(JumpHandler);
	}
	private void Update()
	{
		Move();

		if (Input.GetButtonDown("Jump"))
		{
			JumpHandler();
		}

		UpdateAnimation();
	}
	private void Move()
	{
		dirX = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
		_rb.velocity = new Vector2(dirX * playerSpeed, _rb.velocity.y);
	}

	public void Stop()
	{
		_rb.velocity = new Vector2(0, _rb.velocity.y);
		_animator.SetFloat("Speed", 0);
		_animator.SetTrigger("Stop");

		this.enabled = false;
	}

	private void Jump()
	{
		_rb.velocity = new Vector2(0, jumpPower);
		isGrounded = false;

		CreateDust();
	}

	private void JumpHandler()
	{
		if (isGrounded)
		{
			Jump();
			jumpSound1.Play();
			canDoubleJump = true;
		}
		else if (canDoubleJump)
		{
			Jump();
			doubleJumpSound.Play();
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

			CreateDust();
		}
	}

	private void CreateDust()
	{
		dust?.Play();
	}
}