using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour 
{
	void Start()
	{
		print("Start");
		rigidbody2D.AddForce(new Vector2(-200000, -100));
	}
}
