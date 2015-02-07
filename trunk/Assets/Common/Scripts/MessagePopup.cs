﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePopup : MonoBehaviour 
{
    [SerializeField]
    private string m_message;

    [SerializeField]
    private GameObject m_receiver = null;

    [SerializeField]
    private string m_function;

    private Text m_text;
    private bool m_insideTrigger = false;

    void Awake()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("MessagePopup");
        if(textObject != null) m_text = textObject.GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if(m_text != null) m_text.text = m_message;
        m_insideTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (m_text != null) m_text.text = "";
        m_insideTrigger = false;
    }

    private void Update()
    {
        if(!m_insideTrigger) return;

        if( Input.GetKeyDown(KeyCode.F))
        {
            if(m_receiver != null)
            {
                m_receiver.SendMessage(m_function, null, SendMessageOptions.DontRequireReceiver);
            }

            StartCoroutine(WinGame());
        }
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        for (int i = 0; i < objects.Length; ++i)
            Destroy(objects[i]);

        Application.LoadLevelAsync(2);
    }
}
