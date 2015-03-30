using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent( typeof( Camera ) )]
[AddComponentMenu( "NGJ15/PixelColorDistortion" )]

public class PixelColorDistortion :PostEffectsBase
{
	public float m_zoomInOutAmount = 0f;
	public Shader m_pixelColorDistortionShader;
	private Material m_pixelColorDistortionMat;

	// Use this for initialization
	public override bool CheckResources()
	{
		CheckSupport( false );

		m_pixelColorDistortionMat = CheckShaderAndCreateMaterial( m_pixelColorDistortionShader, m_pixelColorDistortionMat );

		if( !isSupported )
			ReportAutoDisable();
		return
			isSupported;
	}

	void OnRenderImage( RenderTexture source, RenderTexture destination )
	{
		if( CheckResources() == false )
		{
			Graphics.Blit( source, destination );
			return;
		}

		//m_pixelColorDistortionMat.SetTexture("_TintText", m_tintTexture);
		//m_pixelColorDistortionMat.SetFloat( "_Intensity", intensity );
		m_pixelColorDistortionMat.SetFloat("_Zoom", m_zoomInOutAmount);
		Graphics.Blit( source, destination, m_pixelColorDistortionMat );
	}
}