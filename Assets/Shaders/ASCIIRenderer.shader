﻿//Made By Stefan Jovanović
//Twitter: https://twitter.com/SJovGD
//Reddit: https://www.reddit.com/user/sjovanovic3107
//Unity Asset Store: https://assetstore.unity.com/publishers/32235
//Itch.io: https://stefanjo.itch.io/

Shader "Custom/ASCIIShader" {
	Properties{
		_MainTex("Base", 2D) = "white" {}
		_CharTex("Character Map", 2D) = "white" {}
		_screenW("Screen Width", int) = 1920
		_screenH("Screen Height", int) = 1080
		_tilesX("X Characters", int) = 96
		_tilesY("Y Characters", int) = 54
		_tileW("Character Width", int) = 20
		_tileH("Character Height", int) = 20
		_monochromatic("Monochromatic", int) = 0
		_monoColour("Monochromatic Colour", Color) = (0, 1, 0, 1)
		_charCount("Number of Characters", int) = 8
		_brightness("Darkness", Float) = 0.0
		_dimming("Dimming", Float) = 1.0
		_contrastCurve("Contrast Curve", 2D) = "white" {}
	}

		SubShader{
			Pass{
				CGPROGRAM
				#pragma fragment frag
				#pragma vertex vert_img
				#pragma target 3.0
				#include "UnityCG.cginc"


				struct v2f {
					float4 pos : SV_POSITION;
					float2 uv  : TEXCOORD0;
				};

				sampler2D _MainTex;
				sampler2D _CharTex;
				float _screenW;
				float _screenH;
				float _tilesX;
				float _tilesY;
				float _tilesW;
				float _tilesH;
				float _brightness;
				int _monochromatic;
				int _charCount;
				float4 _monoColour;
				float _dimming;
				sampler2D _contrastCurve;


				float4 frag(v2f i) : COLOR{
					float2 newCoord = float2(saturate(floor(_tilesX * i.uv.x) / (_tilesX)), saturate(floor(_tilesY * i.uv.y) / (_tilesY)));
					float4 col = tex2D(_MainTex,newCoord);
					float gray = saturate((col.r + col.g + col.b)/3.0f);
					if (gray > 0 && gray < 1) {
						gray = tex2D(_contrastCurve, float2(gray, 0)).r;
					}
					int charIndex = round(gray * (_charCount-1));
					float2 charCoord =float2(((_screenW * i.uv.x) % _tilesW + (_tilesW-1)*charIndex)/ ((_tilesW - 1)* _charCount), saturate(((int)(_screenH * i.uv.y) % _tilesH) / (_tilesH-1)));
					float4 charCol = tex2D(_CharTex, charCoord);

					if (charCol.r > .8f) {
						if(_monochromatic == 1) {
							float contrast = 1 - ((1 - gray) * _dimming);
							return contrast * _monoColour;
						}
						else {
							return col;
						}
					}
					else {
						return col * _brightness;
					}					
				}
				ENDCG
			}
		}
			FallBack off
}
