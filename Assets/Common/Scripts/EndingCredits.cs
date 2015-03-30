using UnityEngine;
using System.Collections;

public class EndingCredits : MonoBehaviour
{

	[SerializeField] private AudioSource m_audioSource;

	[SerializeField]
	private AudioClip clip;

	private int timesPlayed = 0;
	private float delay = 0.17f;

	// Use this for initialization
	void Start () {
		m_audioSource.clip = clip;
		//m_audioSource.Play();
		StartCoroutine(PlayWow());
		//AudioSource.PlayClipAtPoint(clip, Vector3.zero);
	}

	IEnumerator PlayWow()
	{
		if (timesPlayed == 0)
			yield return new WaitForSeconds(delay * 0.5f);

		m_audioSource.Stop();
		m_audioSource.Play();
		yield return new WaitForSeconds(delay);

		timesPlayed++;
		if (timesPlayed < 4)
			StartCoroutine(PlayWow());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape))
			Application.LoadLevelAsync(0);
	}
}
