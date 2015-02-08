using UnityEngine;
using System.Collections;

public class Phrank : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;
    [SerializeField]
    private Sprite m_sprite0;
    [SerializeField]
    private Sprite m_sprite1;

    [SerializeField]
    private AudioClip[] m_talkClips;
	
	void Start() 
    {
        StartCoroutine(Talk());
	}

    private IEnumerator Talk()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            m_spriteRenderer.sprite = m_sprite1;
            AudioSource.PlayClipAtPoint(m_talkClips[Random.Range(0, m_talkClips.Length)], Vector3.zero);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            m_spriteRenderer.sprite = m_sprite0;
        }
    }
}
