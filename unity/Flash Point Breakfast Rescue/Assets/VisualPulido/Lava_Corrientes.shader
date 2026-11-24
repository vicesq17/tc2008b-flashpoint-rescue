Shader "FlashPoint/Lava/Corrientes" {
SubShader { Tags {"RenderType"="Opaque"} Pass { CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
struct V {float4 pos:SV_POSITION; float2 p:TEXCOORD0;};
V vert(appdata_base v){V o;o.pos=UnityObjectToClipPos(v.vertex);o.p=mul(unity_ObjectToWorld,v.vertex).xz;return o;}
fixed4 frag(V i):SV_Target{float t=_Time.y*.65;float2 p=i.p;float flow=sin(p.x*1.4+t+1.7*sin(p.y*1.1-t*.7))+sin(p.y*1.9+t*.6+.9*sin(p.x-t));float hot=smoothstep(-.2,1.5,flow);float edge=1-smoothstep(.04,.42,abs(flow+.5));return fixed4(lerp(float3(.68,.105,.012),float3(1,.59,.055),hot)+edge*float3(.21,.17,.035),1);}
ENDCG
} } }