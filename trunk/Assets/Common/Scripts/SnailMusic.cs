using UnityEngine;
using System.Collections;

public class SnailMusic : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_snailMusic;

	void Awake() 
    {
        StartCoroutine(FadeMusic());
	}

    private IEnumerator FadeMusic()
    {
        GameObject musicObject = GameObject.Find("Music");
        if(musicObject != null)
        {
            AudioSource audio = musicObject.GetComponent<AudioSource>();
            
            while (audio.volume > 0.0f)
            {
                audio.volume = Mathf.MoveTowards(audio.volume, 0.0f, Time.deltaTime);
                yield return null;
            }

            audio.clip = m_snailMusic;
            audio.loop = true;
            audio.Play();

            while(audio.volume < 1.0f)
            {
                audio.volume = Mathf.MoveTowards(audio.volume, 1.0f, Time.deltaTime);
                yield return null;
            }
        }
    }
}
