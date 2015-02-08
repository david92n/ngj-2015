using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class Citizen : MonoBehaviour
{

	private Transform m_player;

	// Use this for initialization
	void Start ()
	{
		m_player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float myX = transform.position.x;
		float pX = m_player.position.x;

		if (myX > pX)
		{
			transform.localScale = new Vector2(1, 1);
		}
		else if(myX < pX)
		{
			transform.localScale = new Vector2(-1, 1);
		}
	}
}
