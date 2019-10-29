// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Geometry/FlatShadingTest"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo", 2D) = "white" {}
		
	}

		SubShader
	{

		Tags{ "Queue" = "Geometry" "RenderType" = "Opaque" "LightMode" = "ForwardBase" }

		Pass
	{
		CGPROGRAM

#include "UnityCG.cginc"
#pragma vertex vert
//#pragma surface surf Lambert
#pragma geometry geom
#pragma fragment frag
#pragma multi_compile _ VERTEXLIGHT_ON

		float4 _Color;
	sampler2D _MainTex;

	struct v2g
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		float3 vertex : TEXCOORD1;
	};
	
	struct g2f
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		float light : TEXCOORD1;
	};

	v2g vert(appdata_full v)
	{
		v2g o;
		o.vertex = v.vertex;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord;
		return o;
	}

	[maxvertexcount(3)]
	void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
	{
		g2f o;

		// Compute the normal
		float3 vecA = IN[1].vertex - IN[0].vertex;
		float3 vecB = IN[2].vertex - IN[0].vertex;
		float3 normal = cross(vecA, vecB);
		normal = normalize(mul(normal, (float3x3) unity_WorldToObject));

		// Compute diffuse light
		float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
		o.light = max(0., dot(normal, lightDir));

		// Compute barycentric uv
		o.uv = (IN[0].uv + IN[1].uv + IN[2].uv) / 3;

		for (int i = 0; i < 3; i++)
		{
			o.pos = IN[i].pos;
			triStream.Append(o);
		}
	}

	half4 frag(g2f i) : COLOR
	{
		float4 col = tex2D(_MainTex, i.uv);
		col.rgb *= i.light * _Color * 0.5;
		return col;
	}
		struct VertOutput1 { // vertex output info
		half4 pos : SV_POSITION;
		half4 colur: COLOR;
		half4 sktex : TEXCOORD0;
		half4 lightDir : TEXCOORD1;
		half3 posNormal : TEXCOORD2;
		half3 tans : TEXCOORD3;
		half3 binoms : TEXCOORD4;
		half3 cameraView :TEXCOORD5;
		half4 spTex : TEXCOORD6;
		float2 cap  : TEXCOORD7;

	};

	struct VertInput1 {   // vertex imput info
		half4 vertex : POSITION;
		half3 normal : NORMAL;
		half4 texcoord : TEXCOORD0;
		half4 tangent : TANGENT;
	};
	// vertex

	VertOutput1 vertsA(VertInput1 g)
	{
		VertOutput1 h;
		//matcap
		half2 capCoord;
		capCoord.x = dot(UNITY_MATRIX_IT_MV[0].xyz, g.normal);
		capCoord.y = dot(UNITY_MATRIX_IT_MV[1].xyz, g.normal);
		h.cap = capCoord * 0.5 + 0.5;


		// direction variables
		h.posNormal = normalize(mul(half4(g.normal, 0.0), unity_WorldToObject).xyz); //normalworld
		h.tans = normalize(mul(unity_ObjectToWorld, g.tangent).xyz); //tangentworld
		h.binoms = normalize(cross(h.posNormal, h.tans)* g.tangent.w);//binormalWorld

		half4 posMain = mul(unity_ObjectToWorld, g.vertex);
		h.pos = UnityObjectToClipPos(g.vertex);
		h.sktex = g.texcoord;

		h.cameraView = normalize(_WorldSpaceCameraPos.xyz - posMain.xyz); //tweakable



																		  //multilight and light physics
		half3 facetolite = _WorldSpaceLightPos0.xyz - posMain.xyz;
		half distance = length(facetolite);

		h.lightDir = half4(normalize(lerp(_WorldSpaceLightPos0.xyz, facetolite, _WorldSpaceLightPos0.w)),
			lerp(1.0, (1.0 / (distance*distance)), _WorldSpaceLightPos0.w));


		return h;

	}


	//user variables
	//uniform half4 _Color2;
	uniform half _Shininess;
	uniform half4 _LightColor0;
	//uniform sampler2D _MainTex;
	uniform half4 _MainTex_ST;
	uniform sampler2D _Normals;
	uniform half4 _Normals_ST;
	uniform half _NorRange;
	uniform half _CapPower;
	uniform sampler2D _Smap;
	uniform half4 _Smap_ST;
	uniform sampler2D _MatCap;
	uniform float2 matcapUV;
	//half4x4 unity_ObjectToWorld;
	//half4x4 unity_WorldToObject;
	//half4 _WorldSpaceLightPos0;
	//half3 _WorldSpaceCameraPos;
	// fragment

	half4 fragsA(VertOutput1 i) : COLOR
	{


		//maps

		half4 sktexf = tex2D(_MainTex, i.sktex.xy + (_MainTex_ST.xy * _MainTex_ST.zw));
		half4 tans = tex2D(_Normals, i.sktex.xy + (_Normals_ST.xy * _Normals_ST.zw));
		half4 spTex = tex2D(_Smap, i.sktex.xy + (_Smap_ST.xy *_Smap_ST.zw));

		//normals
		half3 localCoords = half3(2.0 * tans.ag - half2(1.0,1.0),_NorRange);

		half3x3 local2WorldTranspose = float3x3(i.tans, i.binoms, i.posNormal);
		half3 normalDirection = normalize(mul(localCoords, local2WorldTranspose));

		//matcap
		fixed4 mc = tex2D(_MatCap,i.cap);

		//Half-Lambert lighting calc.

		half3 SNdotL = saturate(dot(normalDirection,i.lightDir.xyz));
		half3 thelighting = i.lightDir.w * _LightColor0.xyz * 2 * SNdotL;


		//Specularty calc (0.7*normalDirection,0.7*mainlightDir for wetness, specularity and shine,
		half3 theshine = i.lightDir.w * 0.8*spTex.rgb*(0.4*max(0.0,dot(0.7*normalDirection,0.7* i.lightDir.xyz)))
			* pow(max(0.0, dot(reflect(-i.lightDir.xyz, normalDirection),i.cameraView)),_Shininess);
		//spec highlights messy code
		half3 thehigh = i.lightDir.w * max(0.0,dot(normalDirection, i.lightDir.xyz))
			*pow(max(0.0, dot(reflect(-i.lightDir.xyz, normalDirection),i.cameraView)),15);
		half3 thebrightness = theshine + (0.06*thehigh);
		//combine the lights
		half3 lights = (mc*_CapPower)*(thelighting)+(thebrightness);//(theshine*0.6);// + (2*UNITY_LIGHTMODEL_AMBIENT.xyz);



																	//final lighting

		return half4 (sktexf.rgb*lights,1.0);

	}


		ENDCG
	}
	}
		Fallback "Diffuse"
}