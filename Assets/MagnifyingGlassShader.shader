Shader "Custom/MagnifyingGlassShader"
{
    Properties
    {
        _MagnifyCenter("Magnify Center", Vector) = (0.5,0.5,0,0)
        _MagnifyAmount("Magnify Amount", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float2 _MagnifyCenter;
            float _MagnifyAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                // Calcul de la déformation
                float2 offset = i.uv - _MagnifyCenter;
                float dist = length(offset);
                float magnify = smoothstep(0.0, 0.5, (0.5 - dist) * _MagnifyAmount);
                offset = normalize(offset) * dist * magnify;
                fixed4 col = tex2D(_MainTex, _MagnifyCenter + offset);
                return col;
            }
            ENDCG
        }
    }
}
