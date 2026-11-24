Shader "FlashPoint/Terreno/Arena y pasto"
{
 Properties { _Arena ("Arena", Color) = (0.52,0.38,0.23,1) _Pasto ("Pasto",Color)=(0.24,0.29,0.10,1) }
 SubShader {
 Tags { "RenderType"="Opaque" }
 LOD 200
 CGPROGRAM
 #pragma surface surf Standard fullforwardshadows
 #pragma target 3.0
 fixed4 _Arena, _Pasto;
 struct Input { float3 worldPos; };
 float hash(float2 p) { return frac(sin(dot(p,float2(127.1,311.7)))*43758.5453); }
 float noise(float2 p) { float2 i=floor(p), f=frac(p);float2 u=f*f*(3-2*f);return lerp(lerp(hash(i),hash(i+float2(1,0)),u.x),lerp(hash(i+float2(0,1)),hash(i+1),u.x),u.y); }
 void surf(Input IN,inout SurfaceOutputStandard o) {
 float2 p=IN.worldPos.xz;
 float broad=noise(p*.16)*.6+noise(p*.42)*.3+noise(p*1.4)*.1;
 float grain=noise(p*22);
 float grass=smoothstep(-2.0,4.0,max(abs(p.x)-51.0,abs(p.y)-40.5)+(broad-.5)*8);
 float blades=noise(p*float2(14,2.4));
 float3 sand=_Arena.rgb*(.78+broad*.37)+(grain-.5)*.075;
 float3 turf=_Pasto.rgb*(.64+broad*.65)+(blades-.5)*float3(.045,.07,.022);
 o.Albedo=lerp(sand,turf,grass);
 o.Metallic=0;o.Smoothness=.04;o.Occlusion=.92+broad*.08;
 float2 d=float2(noise(p*22+float2(.03,0))-grain,noise(p*22+float2(0,.03))-grain);
 o.Normal=normalize(float3(-d*.35,1));
 }
 ENDCG
 }
 Fallback "Diffuse"
}