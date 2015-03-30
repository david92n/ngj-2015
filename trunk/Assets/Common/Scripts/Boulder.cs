using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour 
{
	void Start()
	{
		print("Start");
		GetComponent<Rigidbody2D>().AddForce(new Vector2(-120000, -100));
	}
}
