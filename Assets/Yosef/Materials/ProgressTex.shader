Shader "Unlit/ProgressTex"
{
    Properties
    {
        _BlankTex ("Empty", 2D) = "white" {}
        _ColorTex ("Full", 2D) = "white" {}
        _Progress ("Progress", float) = 0
        _Transparency ("Transparency", float) = 1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Zwrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _BlankTex;
            float4 _BlankTex_ST;
            sampler2D _ColorTex;
            float4 _ColorTex_ST;
            float _Progress;
            float _Transparency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BlankTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color;
            
                if (i.uv.y > _Progress)
                    color = tex2D(_BlankTex, i.uv);
                else
                    color = tex2D(_ColorTex, i.uv);

                color.a = min(color.a, _Transparency);

                return color;
            }
            ENDCG
        }
    }
}
