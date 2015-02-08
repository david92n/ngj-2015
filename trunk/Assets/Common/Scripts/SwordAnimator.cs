using UnityEngine;
using System.Collections;

public class SwordAnimator : MonoBehaviour {

	// Use this for initialization
	private bool m_slash;

	private Animator m_animator;

	
	private void Awake()
	{
		m_animator = GetComponent<Animator>();
	}

	void Update()
	{
		m_slash = Input.GetKey( KeyCode.G );
		m_animator.SetBool( "Slash", m_slash );
	}
}
