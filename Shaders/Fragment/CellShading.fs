#version 330

// Input vertex attributes (from vertex shader)
in vec3 fragPosition;
in vec2 fragTexCoord;
in vec4 fragColor;
in vec3 fragNormal;

// // Input uniform values
uniform sampler2D texture0;
uniform vec3 CameraView;

// Output fragment color
out vec4 finalColor;

void main()
{
    vec3 texColor = texture(texture0, fragTexCoord).rgb;
    vec3 camview = CameraView;
    vec3 LightSource = normalize(vec3(1.0, 1.0, 0.0));
    vec3 LightColor = vec3(1, 1, 1);
    vec3 ambientLight = vec3(1, 1, 1);

    //Diffuse
    vec3 L = normalize(LightSource);
    vec3 N = normalize(fragNormal);
    float DiffuseStrength = max(0.0, dot(L, N));
    vec3 Diffuse = DiffuseStrength * LightColor;

    //Cell Shading
    float threshold = 0.45;
    vec3 CellDiffuse = mix((vec3(texColor * 0.1)), Diffuse, step(threshold, Diffuse));
    
    //Specular Lighting
    vec3 viewSource = normalize(camview);
    vec3 ReflectSource = normalize(reflect(-L, N));
    float SpecularStrength = max(0.0, dot(viewSource, ReflectSource));
    SpecularStrength = pow(SpecularStrength, 32.0);
    vec3 Specular = SpecularStrength * LightColor;
    
    // Ambient
    vec3 Lighting = ambientLight;
    
    Lighting = ambientLight * 0.5 + CellDiffuse * 1 + Specular * 0.5;
    
    finalColor = vec4(Lighting * texColor, 1.0);


}