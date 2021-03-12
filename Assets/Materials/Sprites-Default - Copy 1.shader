// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/Sprites/Default Copy"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		[HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
		[HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
		[PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
		[PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
		_Offset("Offset", Vector) = (1,1,1,1)
	}

		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane" 
				"CanUseSpriteAtlas" = "True"
			}

			Cull Off
			Lighting Off
			ZWrite Off
			Blend One OneMinusSrcAlpha

			Pass
			{
			CGPROGRAM
				#pragma vertex Vert
				#pragma fragment Frag
				#pragma target 2.0
				#pragma multi_compile_instancing
				#pragma multi_compile_local _ PIXELSNAP_ON
				#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
				#include "UnitySprites.cginc"

				float4 _Offset;
		float4 _MainTex_TexelSize;

			struct v2f2
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 pixel	: TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			v2f2 Vert(appdata_t IN)
			{
				v2f2 OUT;

				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

				OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
				OUT.vertex = UnityObjectToClipPos(OUT.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.pixel = ComputeScreenPos(OUT.vertex);
				OUT.color = IN.color * _Color * _RendererColor;

#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif

				return OUT;
			}


			//float4 Frag(v2f2 IN) : SV_Target{
			//	float2 uv = floor(IN.texcoord) +0.5;
			//	uv += 1.0 - clamp((1.0 - frac(IN.texcoord)) , 0.0, 1.0);
			//	fixed4 color = tex2D(_MainTex, uv);// *IN.color;
			//	//color.rg = IN.texcoord;
			//	//color.b = 0;
			//	color.rgb *= color.a;
			//	return color;
			//}
			fixed4 Frag(v2f2 IN) : SV_Target{

			//fixed2 uv = floor(IN.pixel) + 0.5;
			//uv += 1.0 - clamp((1.0 - frac(IN.pixel)), 0.0, 1.0);
			//fixed2 _TC = IN.texcoord + uv;
			/*IN.texcoord += 1.0 - clamp((1.0 - fract()))*/
			fixed4 color = tex2D(_MainTex, IN.texcoord + _Offset) * IN.color;
			color.rgb *= color.a;
			//color.rg = uv;
			return color;
			}
ENDCG
}
		}
}
