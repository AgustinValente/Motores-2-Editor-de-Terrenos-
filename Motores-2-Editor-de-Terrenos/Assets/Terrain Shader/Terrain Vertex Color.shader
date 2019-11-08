// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Brush"
{
	Properties
	{
		[HideInInspector][NoScaleOffset]_Texture1Normal("Texture 1 Normal", 2D) = "bump" {}
		[HideInInspector][NoScaleOffset]_Texture2Normal("Texture 2 Normal", 2D) = "bump" {}
		[HideInInspector][NoScaleOffset]_Texture3Normal("Texture 3 Normal", 2D) = "bump" {}
		[HideInInspector][NoScaleOffset]_Texture4Normal("Texture 4 Normal", 2D) = "bump" {}
		[NoScaleOffset]_Texture1("Texture 1", 2D) = "white" {}
		_TileTexture1("Tile - Texture 1", Float) = 2
		_IntensityNormal1("Intensity Normal 1", Range( 1 , 2)) = 0
		[NoScaleOffset]_Texture2("Texture 2", 2D) = "white" {}
		_TileTexture2("Tile - Texture 2", Float) = 2
		_IntensityNormal2("Intensity Normal 2", Range( 1 , 1.5)) = 0
		[NoScaleOffset]_Texture3("Texture 3", 2D) = "white" {}
		_TileTexture3("Tile - Texture 3", Float) = 2
		_IntensityNormal3("Intensity Normal 3", Range( 1 , 1.5)) = 1
		[NoScaleOffset]_Texture4("Texture 4", 2D) = "white" {}
		_TileTexture4("Tile - Texture 4", Float) = 2
		_IntensityNormal4("Intensity Normal 4", Range( 1 , 1.5)) = 2
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 4.6
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float _IntensityNormal1;
		uniform sampler2D _Texture1Normal;
		uniform float _TileTexture1;
		uniform float _IntensityNormal2;
		uniform sampler2D _Texture2Normal;
		uniform float _TileTexture2;
		uniform float _IntensityNormal3;
		uniform sampler2D _Texture3Normal;
		uniform float _TileTexture3;
		uniform float _IntensityNormal4;
		uniform sampler2D _Texture4Normal;
		uniform float _TileTexture4;
		uniform sampler2D _Texture1;
		uniform sampler2D _Texture2;
		uniform sampler2D _Texture3;
		uniform sampler2D _Texture4;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_cast_0 = (_TileTexture1).xx;
			float2 uv_TexCoord17 = i.uv_texcoord * temp_cast_0;
			float2 temp_cast_1 = (_TileTexture2).xx;
			float2 uv_TexCoord19 = i.uv_texcoord * temp_cast_1;
			float Red61 = i.vertexColor.r;
			float3 lerpResult59 = lerp( UnpackScaleNormal( tex2D( _Texture1Normal, uv_TexCoord17 ), _IntensityNormal1 ) , UnpackScaleNormal( tex2D( _Texture2Normal, uv_TexCoord19 ), _IntensityNormal2 ) , Red61);
			float2 temp_cast_2 = (_TileTexture3).xx;
			float2 uv_TexCoord22 = i.uv_texcoord * temp_cast_2;
			float Green62 = i.vertexColor.g;
			float3 lerpResult47 = lerp( lerpResult59 , UnpackScaleNormal( tex2D( _Texture3Normal, uv_TexCoord22 ), _IntensityNormal3 ) , Green62);
			float2 temp_cast_3 = (_TileTexture4).xx;
			float2 uv_TexCoord24 = i.uv_texcoord * temp_cast_3;
			float Blue60 = i.vertexColor.b;
			float3 lerpResult50 = lerp( lerpResult47 , UnpackScaleNormal( tex2D( _Texture4Normal, uv_TexCoord24 ), _IntensityNormal4 ) , Blue60);
			o.Normal = lerpResult50;
			float4 lerpResult7 = lerp( tex2D( _Texture1, uv_TexCoord17 ) , tex2D( _Texture2, uv_TexCoord19 ) , Red61);
			float4 lerpResult8 = lerp( lerpResult7 , tex2D( _Texture3, uv_TexCoord22 ) , Green62);
			float4 lerpResult9 = lerp( lerpResult8 , tex2D( _Texture4, uv_TexCoord24 ) , Blue60);
			o.Albedo = lerpResult9.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16900
0;414;1080;274;2870.604;1107.226;3.155808;True;False
Node;AmplifyShaderEditor.VertexColorNode;2;-2574.948,-728.9564;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;20;-2213.755,-1205.432;Float;False;Property;_TileTexture2;Tile - Texture 2;8;0;Create;True;0;0;False;0;2;1.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-2251.887,-1605.893;Float;False;Property;_TileTexture1;Tile - Texture 1;5;0;Create;True;0;0;False;0;2;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-2053.129,-1624.376;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;74;-2049.647,-1474.101;Float;False;Property;_IntensityNormal1;Intensity Normal 1;6;0;Create;True;0;0;False;0;0;1;1;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;61;-2308.936,-807.2318;Float;False;Red;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;19;-2017.891,-1223.466;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;73;-2098.565,-1065.666;Float;False;Property;_IntensityNormal2;Intensity Normal 2;9;0;Create;True;0;0;False;0;0;1;1;1.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-1731.898,-665.9513;Float;False;Property;_TileTexture3;Tile - Texture 3;11;0;Create;True;0;0;False;0;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;13;-1742.422,-1333.658;Float;True;Property;_Texture2;Texture 2;7;1;[NoScaleOffset];Create;True;0;0;False;0;None;f061199b2c8ab6343ba8fc67e341047b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;55;-1751.824,-1540.129;Float;True;Property;_Texture1Normal;Texture 1 Normal;0;2;[HideInInspector];[NoScaleOffset];Create;True;0;0;False;0;None;d406ae0ed6fa75f4c8dd0b57c11e4c40;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;12;-1756.16,-1751.827;Float;True;Property;_Texture1;Texture 1;4;1;[NoScaleOffset];Create;True;0;0;False;0;None;08b3639045d966048a1cb779dcc1b69e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;57;-1752.859,-1138.163;Float;True;Property;_Texture2Normal;Texture 2 Normal;1;2;[HideInInspector];[NoScaleOffset];Create;True;0;0;False;0;None;8ccd438ba0ab0854b8a29fa57e6e85c5;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;63;-1613.683,-1853.341;Float;False;61;Red;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;62;-2315.528,-686.9244;Float;False;Green;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;7;-1312.105,-1570.641;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;71;-1553.359,-524.0497;Float;False;Property;_IntensityNormal3;Intensity Normal 3;12;0;Create;True;0;0;False;0;1;1;1;1.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;22;-1522.077,-682.4483;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;59;-1307.769,-1358.944;Float;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;64;-1139.855,-957.7747;Float;False;62;Green;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-1363.227,-157.6403;Float;False;Property;_TileTexture4;Tile - Texture 4;14;0;Create;True;0;0;False;0;2;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;58;-1223.475,-630.9189;Float;True;Property;_Texture3Normal;Texture 3 Normal;2;2;[HideInInspector];[NoScaleOffset];Create;True;0;0;False;0;None;7ca73eb1c6c78784fb3f60583d8297b3;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;65;-1017.509,-1405.881;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;15;-1235.592,-846.5572;Float;True;Property;_Texture3;Texture 3;10;1;[NoScaleOffset];Create;True;0;0;False;0;None;322392db0ff7b7047a312daabfc68609;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;66;-992.5569,-1085.07;Float;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;60;-2315.529,-599.5781;Float;False;Blue;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;47;-787.6494,-621.7399;Float;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;8;-818.1521,-845.6895;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;24;-1171.227,-173.6403;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;72;-1166.827,-31.95463;Float;False;Property;_IntensityNormal4;Intensity Normal 4;15;0;Create;True;0;0;False;0;2;1;1;1.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;69;-598.5918,-477.016;Float;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;48;-859.2533,-113.8659;Float;True;Property;_Texture4Normal;Texture 4 Normal;3;2;[HideInInspector];[NoScaleOffset];Create;True;0;0;False;0;None;1c4a920e5124c574884759604f30dd95;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;16;-865.4893,-337.1555;Float;True;Property;_Texture4;Texture 4;13;1;[NoScaleOffset];Create;True;0;0;False;0;None;09ab5acea4ba25a4c83e523bc44ea7d8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;70;-780.6473,-446.765;Float;False;60;Blue;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;68;-548.5587,-638.887;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;50;-489.3533,-127.4565;Float;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;9;-497.1686,-352.5379;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-218.756,-351.337;Float;False;True;6;Float;ASEMaterialInspector;0;0;Standard;Brush;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;2;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;17;0;18;0
WireConnection;61;0;2;1
WireConnection;19;0;20;0
WireConnection;13;1;19;0
WireConnection;55;1;17;0
WireConnection;55;5;74;0
WireConnection;12;1;17;0
WireConnection;57;1;19;0
WireConnection;57;5;73;0
WireConnection;62;0;2;2
WireConnection;7;0;12;0
WireConnection;7;1;13;0
WireConnection;7;2;63;0
WireConnection;22;0;21;0
WireConnection;59;0;55;0
WireConnection;59;1;57;0
WireConnection;59;2;63;0
WireConnection;58;1;22;0
WireConnection;58;5;71;0
WireConnection;65;0;7;0
WireConnection;15;1;22;0
WireConnection;66;0;59;0
WireConnection;60;0;2;3
WireConnection;47;0;66;0
WireConnection;47;1;58;0
WireConnection;47;2;64;0
WireConnection;8;0;65;0
WireConnection;8;1;15;0
WireConnection;8;2;64;0
WireConnection;24;0;23;0
WireConnection;69;0;47;0
WireConnection;48;1;24;0
WireConnection;48;5;72;0
WireConnection;16;1;24;0
WireConnection;68;0;8;0
WireConnection;50;0;69;0
WireConnection;50;1;48;0
WireConnection;50;2;70;0
WireConnection;9;0;68;0
WireConnection;9;1;16;0
WireConnection;9;2;70;0
WireConnection;0;0;9;0
WireConnection;0;1;50;0
ASEEND*/
//CHKSM=17651414DD237A1E551623634E623530B68D6516