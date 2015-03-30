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
				GetComponent<Rigidbody2D>().isKinematic = false;
				GetComponent<Collider2D>().isTrigger = false;
				transform.parent = null;
				GetComponent<Rigidbody2D>().gameObject.SetActive(true);
				GetComponent<Rigidbody2D>().AddForce(new Vector3(10,10,0));
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag != "Player")
		{
			GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<Collider2D>().isTrigger = true;
			return;
		}

		GetComponent<Rigidbody2D>().isKinematic  = true;
		transform.parent = collider.transform;
		if(collider.transform.localScale.x > 0)
			transform.position = collider.transform.position + new Vector3(-3, 2, 0);
		else
			transform.position = collider.transform.position + new Vector3(3, 2, 0);
		_attached = true;
	}
}
