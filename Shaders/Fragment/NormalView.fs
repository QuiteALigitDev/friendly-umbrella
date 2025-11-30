#version 330 core

// Input from vertex shader
in vec3 fragNormal;

// Output color
out vec4 fragColor;

void main()
{
    // Normalize the normal (just in case)
    vec3 n = normalize(fragNormal);
    // Map from [-1, 1] to [0, 1] for RGB
    vec3 color = n * 0.5 + 0.5;

    fragColor = vec4(color, 1.0);
}
