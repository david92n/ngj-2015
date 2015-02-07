using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private float m_speed = 50.0f;

    [SerializeField]
    private float m_jumpForce = 100.0f;

    [SerializeField]
    private Transform m_groundCheck = null;
    [SerializeField]
    private LayerMask m_groundLayers;

    private bool m_grounded = false;
	
	void Start ()
    {

	}
	
	void FixedUpdate ()
    {
        m_grounded = Physics2D.OverlapCircle(m_groundCheck.position, 0.2f, m_groundLayers);

        float move = Input.GetAxis("Horizontal");
        //rigidbody2D.AddForce(new Vector2(move * m_speed, 0.0f) * Time.deltaTime, ForceMode2D.Force);
        rigidbody2D.velocity = new Vector2(move * m_speed, rigidbody2D.velocity.y);
	}

    void Update()
    {
        if (m_grounded && Input.GetButtonDown("Jump"))
        {
            rigidbody2D.AddForce(new Vector2(0.0f, m_jumpForce));
        }
    }
}
