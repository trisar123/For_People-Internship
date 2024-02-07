Shader "Azerilo/2D Fluid" {

Properties {    
    _MainTex ("Texture", 2D) = "white" { }   
	_Threshold ("Threshold", float) = 85
	_Opacity ("Opacity", Range(0,1)) = 1
}

SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"
	
	float _Opacity;
	sampler2D _MainTex;	
	float _Threshold;
	float4 pixelColor;

	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;		
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
			
	float4 frag (v2f i) : COLOR{		
		float4 texcol= tex2D (_MainTex, i.uv); 

		if(texcol.a * 100 < _Threshold)
		{
			pixelColor = float4(0,0,0,0);
		}
		else
		{
			pixelColor = float4(texcol.x,texcol.y,texcol.z, _Opacity);
		}

	    return pixelColor;
	}
	ENDCG

    }
}
} 