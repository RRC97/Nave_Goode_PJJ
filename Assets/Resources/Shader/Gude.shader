Shader "Custom/Gude"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "" {}
		_Color ("Color", Color) = (0,0,0, 1)
		_Blend ("Color Influence", Range(0, 1)) = 1
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
	    Blend SrcAlpha OneMinusSrcAlpha
	    LOD 200
	    ZWrite off
	    
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		fixed4 _Color;
		float _Blend;

		struct Input
		{
			float2 uv_MainTex;
		};
	
	
		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 mainTex = tex2D (_MainTex, IN.uv_MainTex);
			
			o.Albedo = mainTex.rgb * (_Color.rgb * _Blend);
      		o.Alpha = mainTex.a * _Color.a;
		}
		ENDCG
	}
}