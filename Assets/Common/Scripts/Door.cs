using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    [SerializeField]
    private GameObject m_normalObject;

    [SerializeField]
    private GameObject m_debrisObject;

    [SerializeField]
    private AudioClip m_openDoor;

    [SerializeField]
    private AudioClip m_blowDoor;

    private bool m_used = false;

    private void OpenDoor()
    {
        if (m_normalObject == null) return;

        Animator animator = m_normalObject.GetComponent<Animator>();
        if (animator != null && !m_used)
        {
            m_used = true;
            animator.SetTrigger("Open");

            if(m_openDoor != null) AudioSource.PlayClipAtPoint(m_openDoor, Vector3.zero);
        }
    }

    private void BlowDoor()
    {
        if (m_debrisObject != null && m_normalObject != null && !m_used)
        {
            m_used = true;

            m_debrisObject.SetActive(true);
            m_normalObject.SetActive(false);

            if(m_blowDoor != null) AudioSource.PlayClipAtPoint(m_blowDoor, Vector3.zero);
        }
    }

    private void OnTriggerEnter2D()
    {
        BlowDoor();
    }
}
