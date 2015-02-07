using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
    private int m_points = 0;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

}
