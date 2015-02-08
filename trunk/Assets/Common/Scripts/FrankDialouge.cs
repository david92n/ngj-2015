using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrankDialouge : MonoBehaviour 
{
    [SerializeField]
    private Text m_textBox;

    [SerializeField]
    private string[] m_strings;
	
	void Start () 
    {
        StartCoroutine(StartDialouge());
	}
	
    private IEnumerator StartDialouge()
    {
        int index = 0;
        while(index < m_strings.Length)
        {
            m_textBox.text = m_strings[index++];
            yield return new WaitForSeconds(4.0f);
        }

		yield return new WaitForSeconds( 5.0f);
	    Application.LoadLevelAsync("FinalEnding");
    }
}
