using UnityEngine;
using System.Collections;

public class PixelPerfect : MonoBehaviour
{
	public float Width;
	public float Height;
	public float PixelRatio;
	void Update ()
	{
		Camera.main.orthographicSize = Width/(((Width/Height)*2)*PixelRatio);
	}
}
