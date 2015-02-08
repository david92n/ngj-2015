using UnityEngine;
using System.Collections;

public class SwordAnimator : MonoBehaviour {

	// Use this for initialization
	private bool m_slash;

	private Animator m_animator;
	
	[SerializeField]
	private GameObject m_splatter;
	
	[SerializeField]
	private AudioClip m_swishClip;

	private bool m_isSlashing = false;

	private void Awake()
	{
		m_animator = GetComponent<Animator>();
	}

	void Update()
	{
		SetSlash(Input.GetKey(KeyCode.G));
	}

	private void SetSlash(bool value)
	{
		m_slash = value;
		m_animator.SetBool( "Slash", m_slash );
	}

	public void SetIsSlashingTrue()
	{
		print("IsSlashing");
		m_slash = true;
		m_animator.SetBool("Slash", m_slash);
	}

	public void SetIsSlashingFalse()
	{
		m_slash = false;
		m_animator.SetBool( "Slash", m_slash );
	}


	public void PlayStartSound()
	{
		AudioSource.PlayClipAtPoint( m_swishClip, Vector3.zero );
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		CheckCollision(other);
	}

	private void CheckCollision(Collider2D other)
	{
		if (other.gameObject.CompareTag("Snail") && m_isSlashing)
		{
			print("HIT SNAIL");
			GameObject.Instantiate(m_splatter);
			//Spawn blood
			StartCoroutine(WinGame());
		}
	}

	private void OnTriggerStay2D( Collider2D other )
	{
		CheckCollision( other );
	}

	private IEnumerator WinGame()
	{
		yield return new WaitForSeconds( 0.5f );

		GameObject[] objects = GameObject.FindGameObjectsWithTag( "DontDestroyOnLoad" );
		for( int i = 0; i < objects.Length; ++i )
			Destroy( objects[i] );

		Application.LoadLevelAsync( 2 );
	}
}
