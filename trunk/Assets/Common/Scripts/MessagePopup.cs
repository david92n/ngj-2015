using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePopup : MonoBehaviour 
{
    [SerializeField]
    private string m_message;

    private Text m_text;

    void Awake()
    {
        m_text = GameObject.FindGameObjectWithTag("MessagePopup").GetComponent<Text>();
    }

    private void OnTriggerEnter2D()
    {
        m_text.text = m_message;
    }

    private void OnTriggerExit2D()
    {
        m_text.text = "";
    }
}
