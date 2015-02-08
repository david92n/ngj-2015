using UnityEngine;
using System.Collections;

public class CanvasUpdate : MonoBehaviour 
{
    private Canvas m_canvas;

    void Awake()
    {
        m_canvas = GetComponent<Canvas>();
    }

	void Update () 
    {
        if (m_canvas.worldCamera == null)
            m_canvas.worldCamera = Camera.main;
	}
}
