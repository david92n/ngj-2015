using UnityEngine;
using System.Collections;

public class SewerAnimation : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_startClip;
 
    [SerializeField]
    private AudioClip m_landClip;

    [SerializeField]
    private GameObject m_loadLevel;

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        animation.Play();
    }

    public void PlayStartSound()
    {
        AudioSource.PlayClipAtPoint(m_startClip, Vector3.zero);
    }

    public void PlayLandSound()
    {
        AudioSource.PlayClipAtPoint(m_landClip, Vector3.zero);
    }

    public void LoadLevel()
    {
        m_loadLevel.SetActive(true);
    }
}
