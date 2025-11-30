#version 330 core

in vec3 fragPosition;
in vec3 fragNormal;

uniform vec3 cameraPos;
uniform vec4 outlineColor;

out vec4 fragColor;

void main() {

    fragColor = vec4(0, 0, 0, 1);
}
