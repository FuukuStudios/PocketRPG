// Parameters set from your C# code
float4 FontColor;
float4 OutlineColor;
float OutlineWidth; // The width in pixels

// This is automatically set by SpriteBatch
float2 TexelSize; // (1.0 / TextureWidth, 1.0 / TextureHeight)

sampler TextureSampler : register(s0);

struct VertexShaderInput
{
    float4 Position : POSITION0;
    float4 Color : COLOR0;
    float2 TexCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
    float4 Color : COLOR0;
    float2 TexCoord : TEXCOORD0;
};

// Standard pass-through Vertex Shader
VertexShaderOutput MainVS(VertexShaderInput input)
{
    VertexShaderOutput output = (VertexShaderOutput)0;
    output.Position = input.Position;
    output.Color = input.Color; // This will be Color.White from your Sprite.DrawText
    output.TexCoord = input.TexCoord;
    return output;
}

// The Pixel Shader that does all the work
float4 MainPS(VertexShaderOutput input) : COLOR0
{
    // 1. Get the alpha of the center pixel (the actual text)
    // We multiply by input.Color.a, which your C# code sets to 1.0 (from Color.White)
    
    // --- FIX: Read from .r instead of .a ---
    float centerAlpha = tex2D(TextureSampler, input.TexCoord).r * input.Color.a;

    // 2. Sample surrounding pixels to find the outline shape
    float outlineAlpha = 0.0;
    
    // Calculate the UV coordinate offset for one pixel, scaled by the desired width
    float2 step = TexelSize * OutlineWidth;

    // Sample in 8 directions (diagonals included) for a smooth outline
    const int SAMPLES = 8;
    float2 offsets[SAMPLES] = 
    {
        float2(-step.x, -step.y), // Top-Left
        float2( 0,      -step.y), // Top
        float2( step.x, -step.y), // Top-Right
        float2(-step.x,  0),      // Left
        float2( step.x,  0),      // Right
        float2(-step.x,  step.y), // Bottom-Left
        float2( 0,       step.y), // Bottom
        float2( step.x,  step.y)  // Bottom-Right
    };
    
    for (int i = 0; i < SAMPLES; i++)
    {
        // --- FIX: Read from .r instead of .a ---
        outlineAlpha = max(outlineAlpha, tex2D(TextureSampler, input.TexCoord + offsets[i]).r);
    }
    
    // 3. Combine the colors
    // We linearly interpolate (lerp) between the OutlineColor and the FontColor
    // based on the center pixel's alpha. This creates a smooth, antialiased
    // transition from the stroke to the text fill.
    float4 finalColor = lerp(OutlineColor, FontColor, centerAlpha);

    // 4. Set the final pixel alpha
    // The final pixel should be opaque if it's *either* part of the
    // outline OR part of the text. So, we take the max alpha of the two.
    finalColor.a = max(outlineAlpha, centerAlpha);

    return finalColor;
}

// The technique SpriteBatch will use
technique SpriteBatch
{
    pass P0
    {
        VertexShader = compile vs_3_0 MainVS();
        PixelShader = compile ps_3_0 MainPS();
    }
}