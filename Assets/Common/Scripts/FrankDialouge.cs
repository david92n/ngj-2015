using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrankDialouge : MonoBehaviour 
{
    [SerializeField]
    private Text m_textBox;

	[SerializeField] private GameObject m_pressFtoWin;

    [SerializeField]
    private string[] m_strings;

	private bool m_doneTalking = false;
	
	void Start () 
    {
        StartCoroutine(StartDialouge());
	}

	void Update()
	{

		if (Input.GetKey(KeyCode.F) && m_doneTalking)
		{
			Application.LoadLevelAsync( "FinalEnding" );
		}
	}

    private IEnumerator StartDialouge()
    {
        int index = 0;
        while(index < m_strings.Length)
        {
            m_textBox.text = m_strings[index++];
            yield return new WaitForSeconds(4.0f);
        }
		m_doneTalking = true;
		//yield return new WaitForSeconds( 5.0f);
	    
    }
}
