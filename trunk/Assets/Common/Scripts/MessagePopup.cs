using UnityEngine;
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

    public Text m_text;
    private bool m_insideTrigger = false;

    private float m_timer;

    void Awake()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("MessagePopup");
        if(textObject != null) m_text = textObject.GetComponentInChildren<Text>();

        m_timer = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        EnterTrigger();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        EnterTrigger();

        if (Time.time - m_timer > 1.0f)
            ExitTrigger();

        m_timer = Time.time;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        ExitTrigger();
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

    private void EnterTrigger()
    {
        if (m_text != null)
        {
            //m_text.transform.parent.gameObject.SetActive(true);
            m_text.text = m_message;
        }
            
        m_insideTrigger = true;
    }

    private void ExitTrigger()
    {
        if (m_text != null)
        {
            //m_text.transform.parent.gameObject.SetActive(false);
            m_text.text = "";
        }
            
        m_insideTrigger = false;
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        for (int i = 0; i < objects.Length; ++i)
            Destroy(objects[i]);

        Application.LoadLevelAsync(2);
    }

    void OnDestroy()
    {
        ExitTrigger();
    }
}
