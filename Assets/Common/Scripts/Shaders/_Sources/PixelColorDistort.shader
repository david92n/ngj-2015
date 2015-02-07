Shader "ImageEffect/PixelColorDistort" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "" {}
		_TintTex ("Base (RGB)", 2D) = "" {}
	}
	// Shader code pasted into all further CGPROGRAM blocks
	CGINCLUDE
		
	#include "UnityCG.cginc"
	
	struct v2f 
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		float2 uv2 : TEXCOORD1;
	};
	
	sampler2D _MainTex;
	sampler2D _TintTex;

	v2f vert( appdata_img v ) 
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv.xy =  v.texcoord.xy;
		//o.uv.xy = TRANSFORM_TEX(v.texcoord, _TintTex);
		//o.uv.xy =  v.texcoord.xy * _ScreenParams.xy;  
		return o; 
	}
	


	half4 frag(v2f i) : SV_Target 
	{
		half4 color = tex2D(_MainTex, i.uv.xy);
		
		float n = 3.0;
		float x = (1.0/n) * ((_ScreenParams.x * i.uv.x) % n);
		float y = (1.0/n) * ((_ScreenParams.y * i.uv.y) % n);
		
		//x = clamp(x, 0.1, 1);
		//y = clamp(y, 0.1, 1);
		

		float2 uv3 = float2(x,y);
		//float2 uv2 = float2((_ScreenParams.x * i.uv.x)%3, (_ScreenParams.y * i.uv.y)%3;
		
		half4 color3 = half4(x,y,0,0);
		half4 color2 = tex2D(_TintTex, uv3);
		//half4 color2 = tex2D(_TintTex, float2(0.3,0));
		
		//return color2;
		return color - color2 * 0.01;
		//return color - ((color2 * cos(_Time * 30)) * 0.3);
		//return half4(uv3.x,uv3.y,0,0);
	}

	ENDCG
	
Subshader 
{
 Blend One Zero
 Pass {
	  ZTest Always Cull Off ZWrite Off
	  Fog { Mode off }      

      CGPROGRAM
      #pragma fragmentoption ARB_precision_hint_fastest
      #pragma vertex vert
      #pragma fragment frag
      
      ENDCG
  } // Pass
} // Subshader

Fallback off

} // shader