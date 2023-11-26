#version 330 core
out vec4 FragColor;
  
in vec2 TexCoords;

uniform sampler2D normalTexture;

void main()
{
    
    FragColor = texture(normalTexture, TexCoords.st);
    
}  