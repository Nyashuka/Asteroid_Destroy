Shader "Custom/SpaceShader" {
Properties{
 _Color("Color", Color) = (1,1,1,1)
 _Speed("Speed", Range(0.0, 10.0)) = 1
}
SubShader{
 Tags { "RenderType" = "Opaque" }
 Pass {
  CGPROGRAM
   #pragma vertex vert
   #pragma fragment frag
   #include "UnityCG.cginc"

   struct appdata {
    float4 vertex : POSITION;
   };

   struct v2f {
    float4 vertex : SV_POSITION;
   };

   v2f vert(appdata v) {
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    return o;
   }

   half4 frag(v2f i) : SV_Target {
    float3 color = 1.0 / sin(_Time.x * _Speed);
    return half4(color, 1);
   }
  ENDCG
 }
}
}