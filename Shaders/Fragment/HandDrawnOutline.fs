#version 330 core

uniform sampler2D sceneTexture;
in vec2 fragTexCoord;
out vec4 fragColor;

void main()
{
    vec2 texel = 1.0 / textureSize(sceneTexture, 0);
    vec4 center = texture(sceneTexture, fragTexCoord);
    
    int outlineRadius = 2;

    float maxDiff = 0.0;

    for(int x = -outlineRadius; x <= outlineRadius; x++) {
        for(int y = -outlineRadius; y <= outlineRadius; y++) {
            if(x == 0 && y == 0) continue;
            vec4 neighbor = texture(sceneTexture, fragTexCoord + vec2(texel.x * x, texel.y * y));
            maxDiff = max(maxDiff, length(center.rgb - neighbor.rgb));
        }
    }

    // smoothstep for soft edges
    float outlineThreshold = 0.2;
    float edge = smoothstep(0.0, outlineThreshold, maxDiff);

    fragColor = vec4(center.rgb * 0.6, edge); // black edges, transparent elsewhere
}
