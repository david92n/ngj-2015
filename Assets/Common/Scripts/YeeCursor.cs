using UnityEngine;
using System.Collections;

public class YeeCursor : MonoBehaviour 
{
    private Transform m_transform = null;
    /*private SpriteRenderer m_spriteRenderer = null;

    private Vector3 m_lastMousePos;
    private float m_timeOut = 0.0f;*/

	void Awake () 
    {
        m_transform = transform;
        //m_spriteRenderer = GetComponent<SpriteRenderer>();

        //GameObject.DontDestroyOnLoad(gameObject);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*m_timeOut += Time.deltaTime;

        if((Input.mousePosition - m_lastMousePos).sqrMagnitude > 0.01f)
        {
            m_timeOut = 0.0f;
        }

        if (m_timeOut > 5.0f)
        {
            m_spriteRenderer.enabled = false;
            return;
        }
        else
        {
            m_spriteRenderer.enabled = true;
        }

        m_lastMousePos = Input.mousePosition;*/

        Cursor.visible = false;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;
        transform.position = pos;
	}
}
