using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string m_sceneName = "Screen01";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Application.LoadLevelAsync(m_sceneName);
    }
}
