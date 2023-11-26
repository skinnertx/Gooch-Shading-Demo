#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

out vec2 TexCoords;
out vec3 normals;
out vec3 lightDir;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec3 aLightDir;

void main()
{
    TexCoords = aTexCoords;
    normals = normalize(aNormal);
    lightDir = aLightDir;
    gl_Position = projection * view * model * vec4(aPos, 1.0);
}