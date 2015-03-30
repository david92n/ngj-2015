using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrankDialouge : MonoBehaviour 
{
    [SerializeField]
    private Text m_textBox;

    [SerializeField]
    private string[] m_strings;

    [SerializeField]
    private GameObject m_pressFObject = null;

	private bool m_doneTalking = false;
	
	void Start () 
    {
        StartCoroutine(StartDialouge());
	}

	void Update()
	{

		if (Input.GetKey(KeyCode.F) && m_doneTalking)
		{
			GameObject[] objects = GameObject.FindGameObjectsWithTag( "DontDestroyOnLoad" );
			for( int i = 0; i < objects.Length; ++i )
				Destroy( objects[i] );

			Application.LoadLevelAsync( "FinalEnding" );
		}
	}

    private IEnumerator StartDialouge()
    {
        int index = 0;
        m_textBox.text = m_strings[index++];
        do
        {
            yield return new WaitForSeconds(6.0f);
            m_textBox.text = m_strings[index++];
        }
        while (index < m_strings.Length);
		m_doneTalking = true;

        if (m_pressFObject != null) Destroy(m_pressFObject);
    }
}
