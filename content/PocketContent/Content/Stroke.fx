#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_3 // Bumped slightly for better loop support
	#define PS_SHADERMODEL ps_4_0_level_9_3
#endif

// --- Uniforms ---
float4 GlowColor;
float GlowRadius;
float Intensity;
float Threshold;
int Samples;
int Rings;
float Falloff;
float2 TextureSize;

Texture2D SpriteTexture;
sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
	MinFilter = Linear;
	MagFilter = Linear;
	AddressU = Clamp;
	AddressV = Clamp;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

static const float PI = 3.14159265359;

float4 MainPS(VertexShaderOutput input) : COLOR
{
	// Sample the base pixel normally (outside the loop, standard tex2D is fine here)
	float4 base = tex2D(SpriteTextureSampler, input.TextureCoordinates);
	float base_a = base.a;

	if (GlowRadius <= 0.001)
	{
		return base * input.Color;
	}

	float2 texel = float2(1.0 / TextureSize.x, 1.0 / TextureSize.y);
	float glow = 0.0;
	
	// Safety clamps
	int s = clamp(Samples, 0, 48);
	int rmax = clamp(Rings, 0, 8);

	// [loop] tells the compiler: "Keep this dynamic, do not unroll." 
	// It saves registers but might be slightly slower on ancient hardware.
	[loop]
	for (int ri = 1; ri <= rmax; ri++)
	{
		float ring_t = (float)ri / (float)rmax;
		float radius_px = ring_t * GlowRadius;
		float ring_weight = pow(abs(1.0 - ring_t), Falloff);

		[loop]
		for (int si = 0; si < s; si++)
		{
			float a = 2.0 * PI * ((float)si / (float)s);
			float2 off = float2(cos(a), sin(a)) * (radius_px * texel);
			
			// CRITICAL FIX: tex2Dlod
			// We pass float4(uv.x, uv.y, 0, 0). The 4th 0 forces Mip Level 0.
			// This prevents the "gradient instruction" error.
			float sa = tex2Dlod(SpriteTextureSampler, float4(input.TextureCoordinates + off, 0, 0)).a;

			if (sa > Threshold)
			{
				glow += sa * ring_weight;
			}
		}
	}

	float norm_factor = (float)s * (float)rmax;
	if (norm_factor > 0.0)
	{
		glow /= norm_factor;
	}

	glow = clamp(glow * Intensity, 0.0, 1.0);

	// --- Compositing ---
	float glow_alpha = glow * GlowColor.a;
	float out_a = clamp(base_a + (1.0 - base_a) * glow_alpha, 0.0, 1.0);

	float3 text_rgb = base.rgb * base_a;
	float3 glow_rgb = GlowColor.rgb * glow_alpha * (1.0 - base_a);
	float3 out_rgb = text_rgb + glow_rgb;

	float edge_mix = smoothstep(0.0, 0.6, glow * (1.0 - base_a));
	
	float3 mix_target_1 = base.rgb * base_a;
	float3 mix_target_2 = GlowColor.rgb * glow_alpha + base.rgb * base_a;
	
	float3 inner_mix = lerp(mix_target_1, mix_target_2, 0.5);
	out_rgb = lerp(out_rgb, inner_mix, edge_mix);

	if (out_a > 0.0)
	{
		out_rgb /= out_a;
	}

	return float4(out_rgb, out_a) * input.Color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};