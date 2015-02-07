using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private float m_speed;
	
	void Start () 
    {
	
	}
	
	void FixedUpdate () 
    {

        rigidbody2D.AddForce(new Vector2(Input.GetAxis("Horizontal") * m_speed, 0.0f) * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(new Vector2(0.0f, 5.0f), ForceMode2D.Impulse);
        }
	}
}
