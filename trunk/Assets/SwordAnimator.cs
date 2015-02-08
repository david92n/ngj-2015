using UnityEngine;
using System.Collections;

public class SwordAnimator : MonoBehaviour {

	// Use this for initialization
	private bool m_slash;

	private Animator m_animator;
	
	[SerializeField]
	private AudioClip m_swishClip;
	
	private void Awake()
	{
		m_animator = GetComponent<Animator>();
	}

	void Update()
	{
		m_slash = Input.GetKey( KeyCode.G );
		m_animator.SetBool( "Slash", m_slash );
	}


	public void PlayStartSound()
	{
		AudioSource.PlayClipAtPoint( m_swishClip, Vector3.zero );
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Snail"))
		{
			print("HIT SNAIL");
			//Spawn blood
			StartCoroutine( WinGame() );
		}
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
