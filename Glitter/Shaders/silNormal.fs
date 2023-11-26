#version 330 core
layout(location = 0) out vec4 normalColor;

in vec3 normal;

void main()
{
    normalColor = vec4(normal, 1.0);
}