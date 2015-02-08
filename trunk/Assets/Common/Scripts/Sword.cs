using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_pickup;

	private SwordAnimator m_sw;

	private Animator m_animator;


	void Awake()
	{
		m_animator = GetComponent<Animator>();
		m_sw = GetComponent<SwordAnimator>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && transform.parent != other.transform)
        {
	        other.gameObject.GetComponentInChildren<Animator>().SetBool("SwordPickup", true);
			
            transform.parent = other.transform;
            transform.localPosition = new Vector2(0.5f, 3.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	        m_sw.enabled = true;
	        m_animator.enabled = true;
			this.enabled = false;

            AudioSource.PlayClipAtPoint(m_pickup, Vector3.zero);
        }
    }
}
