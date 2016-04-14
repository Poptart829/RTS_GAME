Shader "Custom/ClickMe"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_ColorTint("Tint", Color) = (0.1,0.73,0.23,1.0)
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			//LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			//#pragma surface surf Standard fullforwardshadows
			#pragma surface surf Lambert finalcolor:mycolor
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0


			struct Input 
			{
				float2 uv_MainTex;
				float4 customColor;
			};

			sampler2D _MainTex;
			fixed4 _ColorTint;
			void mycolor(Input IN, SurfaceOutput o, inout fixed4 color)
			{
				color *= _ColorTint;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				// Albedo comes from a texture tinted by color
				//fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.customColor;
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			}
			ENDCG
		}
	FallBack "Diffuse"
}
