using UnityEngine;
using System.Collections;

public class Hovering : MonoBehaviour 
{
    private float m_pos;

    void Awake()
    {
        m_pos = transform.localPosition.y;
    }

	void Update () 
    {
        Vector2 pos = transform.localPosition;
        pos.y = m_pos + Mathf.Cos(Time.time);
        transform.localPosition = pos;
	}
}
