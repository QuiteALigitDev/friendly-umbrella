#version 330 core

in vec3 vertexPosition;
in vec3 vertexNormal;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;
uniform float outlineThickness;

void main()
{
    vec3 expandedPosition = vertexPosition + vertexNormal * 0.05;
    gl_Position = projection * view * model * vec4(expandedPosition, 1.0);
}