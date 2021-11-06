Shader "Custom/VoiceOverShader"
{
    Properties
    {
        _Noise("Noise", 2D) = "white" {}
		_LineWidth("Line Width", Float) = 0.1
		_LineColor("Bar Color", Color) = (255, 255, 255, 1)
		_FillColor("Top Color", Color) = (255, 255, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata 
			{
				float4 vertex: POSITION;
				float2 uv: TEXCOORD0;
			};
			
			struct v2f 
			{
				float2 uv: TEXCOORD0;
				float4 vertex: SV_POSITION;
			};

			sampler2D _Noise;
			float4 _Noise_ST;
			float _LineWidth;
			float4 _LineColor;
			float4 _FillColor;

			v2f vert(appdata v) 
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _Noise);
				return o;
			}

			float4 frag(v2f i) : SV_Target
			{
				float noise = tex2D(_Noise, float2(i.uv.x, 0.5)).r;
				float y = i.uv.y;
				float w = _LineWidth / 2;
				float2 wk = noise + float2(-w, w);
				float f = (y >= wk.x) && (y <= wk.y);
				return (y < noise) * _LineColor + f * _FillColor;
			}
			ENDCG
		}
    }
    FallBack "Diffuse"
}
