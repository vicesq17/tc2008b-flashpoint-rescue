Shader "FlashPoint/Lava/Burbuja superficial"
{
    Properties
    {
        _MainTex ("Borde de la burbuja", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            sampler2D _MainTex;
            struct Vertex { float4 position : POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            struct Varyings { float4 position : SV_POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            Varyings vert(Vertex input)
            {
                Varyings output;
                output.position = UnityObjectToClipPos(input.position);
                output.uv = input.uv;
                output.color = input.color;
                return output;
            }
            fixed4 frag(Varyings input) : SV_Target
            {
                float2 p = 2.0 * input.uv - 1.0;
                float radius = length(p);
                half rim = tex2D(_MainTex, input.uv).a;
                half cap = 1.0 - smoothstep(0.66, 0.80, radius);
                half light = saturate(0.58 + dot(p, float2(-0.75, 0.8)));
                half3 amber = lerp(half3(0.82, 0.18, 0.025), half3(1.0, 0.78, 0.20), light);
                half3 color = lerp(amber, half3(0.64, 0.10, 0.018), rim);
                half glint = 1.0 - smoothstep(0.12, 0.34, length(p - float2(-0.24, 0.25)));
                color = lerp(color, half3(1.0, 0.94, 0.52), glint);
                return fixed4(color * lerp(half3(1,1,1), input.color.rgb, 0.18),
                              max(cap * 0.96, rim) * input.color.a);
            }
            ENDCG
        }
    }
}