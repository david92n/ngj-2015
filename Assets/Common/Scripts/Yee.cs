using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Yee : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer m_sprite;

    [SerializeField]
    private Sprite m_yee;

	public void PlaySound()
    {
        audio.Play();
        Sprite old = m_sprite.sprite;
        m_sprite.sprite = m_yee;
        
        StartCoroutine(ResetSprite(old));
    }

    private IEnumerator ResetSprite(Sprite old)
    {
        yield return new WaitForSeconds(0.5f);
        m_sprite.sprite = old;
    }
}
