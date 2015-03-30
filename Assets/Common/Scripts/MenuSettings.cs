using UnityEngine;
using System.Collections;

public class MenuSettings : MonoBehaviour 
{
	public void LoadLevel()
    {
        Application.LoadLevelAsync(3);
    }

    public void QuitGame()
    {
#if UNITY_WEBGL
        Screen.fullScreen = false;
#else
        Application.Quit();
#endif
    }
}
