using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	const float GroundedRadius = .2f; 
	const float CeilingRadius = .2f; 

	[SerializeField] private float _jumpForce = 400f;							
	[Range(0, 1)] [SerializeField] private float _crouchSpeed = .36f;			
	[Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;	
	[SerializeField] private bool _hasAirControl = false;							
	[SerializeField] private LayerMask _whatIsGround;							
	[SerializeField] private Transform _groundCheck;							
	[SerializeField] private Transform _ceilingCheck;							
	[SerializeField] private Collider2D _crouchDisableCollider;				

	private bool _isGrounded;          
	private Rigidbody2D _rigidbody2D;
	private bool _isFacingRight = true; 
	private Vector3 _velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool _wasCrouching = false;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void Update()
	{
		bool wasGrounded = _isGrounded;
		_isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius, _whatIsGround);

        foreach (var collider in colliders)
			if (collider.gameObject != gameObject)
				Landing(wasGrounded);
	}

	public void Move(float move, bool crouch, bool jump)
	{
		if (crouch == false)
			if (CanStandUp())
				crouch = true;

		if (CanControl())
		{
			if (crouch)
				Crounch(ref move);
			else
				Rise();

			MovePlayer(move);

			if (IsNeedFlip(move))
				Flip();
		}

		if (ShouldJump(jump))
			Jump();
	}

	private void Landing(bool wasGrounded)
	{
		_isGrounded = true;
		if (!wasGrounded)
			OnLandEvent.Invoke();
	}

	private void MovePlayer(float move)
	{
		Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
		_rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);
	}

	private bool CanControl() => _isGrounded || _hasAirControl;

	private bool CanStandUp() => Physics2D.OverlapCircle(_ceilingCheck.position, CeilingRadius, _whatIsGround);

	private void Rise()
	{
		_crouchDisableCollider.enabled = true;

		if (_wasCrouching)
			StopCrouching();
	}

	private void Crounch(ref float move)
	{
		if (_wasCrouching == false)
			StartCrouching();

		move *= _crouchSpeed;
	}

	private void StartCrouching() 
	{
		_wasCrouching = true;
		OnCrouchEvent.Invoke(true);
		_crouchDisableCollider.enabled = false;
	}

	private void StopCrouching() 
	{
		_wasCrouching = false;
		OnCrouchEvent.Invoke(false);
	}

	private bool IsNeedFlip(float move) => move > 0 && !_isFacingRight || move < 0 && _isFacingRight;

    private bool ShouldJump(bool jump) => _isGrounded && jump;

    private void Jump()
	{
		_isGrounded = false;
		_rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
	}

	private void Flip()
	{
		_isFacingRight = !_isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
