Shader "MaskedTexture"
 {
    Properties
    {
       _MainTex ("Base (RGB)", 2D) = "white" {}
       //_Mask ("Culling Mask", 2D) = "white" {}
       _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
    }
    SubShader
    {
       Lighting Off
       ZWrite Off
       Cull Off
       Blend SrcAlpha OneMinusSrcAlpha
       AlphaTest GEqual [_Cutoff]
       
       
       Pass
       {
            ColorMask 0
          ZWrite On
          SetTexture [_MainTex] {combine texture}
       }
       
       
 
    }
 }