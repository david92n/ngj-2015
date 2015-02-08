using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_pickup;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && transform.parent != other.transform)
        {
            transform.parent = other.transform;
            transform.localPosition = new Vector2(0.5f, 3.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            this.enabled = false;

            AudioSource.PlayClipAtPoint(m_pickup, Vector3.zero);
        }
    }
}
