#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float shininess;
};

uniform Material material;
uniform bool isMap;

void main()
{   
    // object base color
    vec3 objColor;
    if (isMap) {
        objColor = vec3(1.0); // texture(texture_diffuse1, TexCoords).xyz;
    } else {
        objColor = material.diffuse;
    }

    // vec3 objColor = vec3(0.1, 0.3, 0.3);
    // vec3 ambient = float(0.1) * lightColor;
    // vec3 diffuse = max(dot(normalize(normals), lightDir), 0.0) * lightColor;
    // vec3 color = (ambient + diffuse) * objColor;
    FragColor = vec4(objColor, 1.0);
}