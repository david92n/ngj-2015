using UnityEngine;
using System.Collections;

public class EndingCredits : MonoBehaviour
{

	[SerializeField]
	private AudioClip clip;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(clip, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
			Application.LoadLevelAsync(0);
	}
}
