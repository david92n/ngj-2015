using UnityEngine;
using System.Collections;

public class SnailMusic : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_snailMusic;

	void Awake() 
    {
        print("HEJ");
        GameObject musicObject = GameObject.Find("Music");
        if(musicObject != null)
            musicObject.GetComponent<AudioSource>().clip = m_snailMusic;
	}
}
