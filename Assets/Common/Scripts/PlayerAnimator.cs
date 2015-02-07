using System;
using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{
	private Animator m_animator;
	private PlayerController m_playerController;
	private Rigidbody2D m_rigidBody;

	// Use this for initialization
	void Start ()
	{
		m_animator = GetComponent<Animator>();
		if(m_animator == null)
			print("Animator is null");
		m_playerController = GetComponent<PlayerController>();
		m_rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateAnimatorVars();
		//FlipSpriteByDirection();
	}

	void UpdateAnimatorVars()
	{
		//m_animator.SetFloat( "Velocity_Horizontal", m_rigidBody.velocity.x );
		//m_animator.SetFloat( "Velocity_Vertical", m_rigidBody.velocity.y);
		//m_animator.SetFloat("Abs_Horizontal_Velocity", Mathf.Abs( m_rigidBody.velocity.x ));
		//m_animator.SetBool( "Grounded", m_playerController.P_Grounded );
		//m_animator.SetBool( "Jumped", m_playerController.P_Jumped );
	}

	void FlipSpriteByDirection()
	{
		switch (m_playerController.P_InputDirection)
		{
			case PlayerController.InputDirection.IDLE:
				break;
			case PlayerController.InputDirection.LEFT:
				transform.localScale.Set( -1, 1, 1);
				break;
			case PlayerController.InputDirection.RIGHT:
				transform.localScale.Set( 1, 1, 1 );
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
