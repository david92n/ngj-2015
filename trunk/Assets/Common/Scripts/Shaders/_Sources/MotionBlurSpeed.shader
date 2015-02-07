Shader "Petter/Motion Blur Speed Effect" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_AccumOrig("AccumOrig", Float) = 0.65
	_SpeedTexture("sdf", 2D) = "white" {}
	
}

    SubShader { 
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
		    BindChannels { 
				Bind "vertex", vertex 
				Bind "texcoord", texcoord
			}
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0

			#include "UnityCG.cginc"
	
			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD;
			};
	
			struct v2f {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD;
			};
			
			float4 _MainTex_ST;
			
			float _AccumOrig;
			float _PlayEffect;
			sampler2D _MainTex;
			float4 _SpeedTexture;
			sampler2D _SpeedTex;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
	
			half ScreenCircle(half x, half center, half speed, half width)
			{
				return pow(-( (x - center) * speed), 2.0) * width + 0.0;
			}

			half2 ScreenCircleVec(half2 xy, half center, half speed, half width)
			{
			    xy.x = ScreenCircle(xy.x, center, speed, width);
				xy.y = ScreenCircle(xy.y, center, speed, width);
				return xy;
			}

			half4 frag (v2f i) : COLOR
			{
			    half center = 0.5;
				half speed = 1.8;
				half width = 1.0;

				half2 circle = ScreenCircleVec(i.texcoord, center, speed, width);
				half circleF = saturate(circle.x + circle.y);

				float k;

				//k = lerp(0.08, _AccumOrig, circleF * (_PlayEffect) );
				//k = lerp(_AccumOrig, 1.0, circleF);

				k = 1.0 - _AccumOrig;

				k *= circleF;
				k *= _PlayEffect;
				
				//k = (1.0 - k) * _PlayEffect;
				//k += 1;

				half4 sc = tex2D(_SpeedTex, i.texcoord);
				//return half4(tex2D(_MainTex, i.texcoord).rgb, _AccumOrig);
				return half4(tex2D(_MainTex, i.texcoord).rgb, 1.0 - k );
				//return half4(tex2D(_MainTex, i.texcoord).rgb + sc.rbg, 1.0 - k );
			}

			ENDCG 
		} 

		Pass {
			Blend One Zero
			ColorMask A
			
		    BindChannels { 
				Bind "vertex", vertex 
				Bind "texcoord", texcoord
			} 
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
	
			#include "UnityCG.cginc"
	
			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD;
			};
	
			struct v2f {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD;
			};
			
			float4 _MainTex_ST;
			sampler2D _MainTex;
			float4 _SpeedTexture;
			sampler2D _SpeedTex;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			half4 frag (v2f i) : COLOR
			{
				half4 sc = tex2D(_SpeedTex, i.texcoord);
				return tex2D(_MainTex, i.texcoord) + sc;
			}
			ENDCG 
		}
		
	}

SubShader {
	ZTest Always 
	Cull Off 
	ZWrite Off
	Fog { Mode off }
	Pass {
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB
		SetTexture [_MainTex] {
			ConstantColor (0,0,0,[_AccumOrig])
			Combine texture, constant
		}
	}
	Pass {
		Blend One Zero
		ColorMask A
		SetTexture [_MainTex] {
			Combine texture
		}
	}
}

Fallback off

}