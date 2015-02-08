using UnityEngine;
using System.Collections;

public class SwordPickup : MonoBehaviour
{
	private bool _attached = false;
	void Update()
	{
		if (_attached)
		{
			if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
			{
				rigidbody2D.isKinematic = false;
				collider2D.isTrigger = false;
				transform.parent = null;
				rigidbody2D.active = true;
				rigidbody2D.AddForce(new Vector3(10,10,0));
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag != "Player")
		{
			rigidbody2D.isKinematic = true;
			collider2D.isTrigger = true;
			return;
		}

		rigidbody2D.isKinematic  = true;
		transform.parent = collider.transform;
		if(collider.transform.localScale.x > 0)
			transform.position = collider.transform.position + new Vector3(-3, 2, 0);
		else
			transform.position = collider.transform.position + new Vector3(3, 2, 0);
		_attached = true;
	}
}
