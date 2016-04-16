Shader "Custom/EdgeDetectionShader" 
{
	Properties 
	{
		_ColorTint ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {} 
		_RimColor ("Rim Color"), Color) = (1,1,1,1)
		_RimPower("Rim Power", Range(1.0, 5.0)) = 1.0
	}
	SubShader 
		{
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input 
		{
			float4 color : Color;
			float2 uv_MainText;
			float3 viewDir;
		};

		sampler2D _MainTex;
		float4 _RimColor;
		float4 _ColorTint;
		float _RimPower;

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			IN.colo = _ColorTint;
			o.Albedo = tex2D(_MainText, IN.uv_MainTex).rgb * IN.color;
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
