Shader "mgrosser/samples/stereo3d/interlace"
{
    Properties
    {
        _LeftTex ("Texture", 2D) = "red" {}
        _RightTex("Texture", 2D) = "green" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _LeftTex;
            sampler2D _RightTex;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col;

                float u = i.uv.x;
                int c = (int)(_ScreenParams.x * u);

                if (c % 2 == 0)
                    col = tex2D(_LeftTex, i.uv);
                else
                    col = tex2D(_RightTex, i.uv);

                return col;
            }
            ENDCG
        }
    }
}
