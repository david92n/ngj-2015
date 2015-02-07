using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public enum InputDirection
	{
		IDLE = 0, LEFT = -1, RIGHT = 1
	}

    [SerializeField]
    private float m_speed = 50.0f;

    [SerializeField]
    private float m_jumpForce = 100.0f;

    [SerializeField]
    private Transform m_groundCheck = null;
    [SerializeField]
    private LayerMask m_groundLayers;

	private Animator m_animator;

	private InputDirection m_inputDirection = InputDirection.IDLE;

	private bool m_grounded = false;
	private bool m_jumped = false;

	public bool P_Jumped
	{
		get { return m_jumped; }
	}

	public InputDirection P_InputDirection
	{
		get { return m_inputDirection; }
	}

	public bool P_Grounded
	{
		get { return m_grounded; }
	}

	void Start ()
	{
		m_animator = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
    {
		SetGrounded(Physics2D.OverlapCircle( m_groundCheck.position, 0.2f, m_groundLayers ));

		float move = GetHorizontalInput();

        //rigidbody2D.AddForce(new Vector2(move * m_speed, 0.0f) * Time.deltaTime, ForceMode2D.Force);
        rigidbody2D.velocity = new Vector2(move * m_speed, rigidbody2D.velocity.y);
	}

	float GetHorizontalInput()
	{
		float move = Input.GetAxis("Horizontal");
		m_animator.SetFloat("Horizontal_Input", move);
		m_animator.SetFloat( "Abs_Horizontal_Input", Mathf.Abs( move ));
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			m_animator.SetBool("Horizontal_Input_Given", false);
		}
		else
		{
			m_animator.SetBool("Horizontal_Input_Given", true);
		}
		SetDirection(move);
		return move;
	}


	void SetGrounded(bool grounded)
	{
//		print("Grounded " + grounded);
		if (m_grounded != grounded && grounded == true)
		{
			m_jumped = false;
			m_animator.SetBool( "Jumped", m_jumped );
		}

		m_grounded = grounded;
		m_animator.SetBool( "Grounded", m_grounded);
	}

	void SetDirection(float input)
	{
		if (input > 0.1)
		{
			m_inputDirection = InputDirection.RIGHT;
			Vector2 scale = transform.localScale;
            scale.x = -1.0f;
            transform.localScale = scale;
		}
		else if(input < -0.1)
		{
            m_inputDirection = InputDirection.LEFT;
			Vector2 scale = transform.localScale;
            scale.x = 1.0f;
            transform.localScale = scale;
		}
		else
		{
			m_inputDirection = InputDirection.IDLE;
		}
	}

	void Jump()
	{
		rigidbody2D.AddForce( new Vector2( -0.0f, m_jumpForce ) );
		m_jumped = true;
		m_animator.SetBool( "Jumped", m_jumped );
	}

    void Update()
    {
        if (m_grounded && Input.GetButtonDown("Jump"))
        {
	        Jump();
        }
		UpdateAnimationVariables();
    }

	void UpdateAnimationVariables()
	{
		m_animator.SetFloat( "Velocity_Horizontal", rigidbody2D.velocity.x );
		m_animator.SetFloat( "Velocity_Vertical", m_grounded ? 0.0f : rigidbody2D.velocity.y);
	}
}
