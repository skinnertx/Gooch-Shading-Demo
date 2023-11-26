#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec3 normals;
in vec3 lightDir;

uniform sampler2D texture_diffuse1;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float shininess;
};

struct Hue {
    vec3 cool;
    vec3 warm;
    float alpha;
    float beta;
};

uniform Material material;
uniform Hue hue;
uniform bool isMap;

void main()
{   
    // object base color
    vec3 objColor;
    if (isMap) {
        objColor = texture(texture_diffuse1, TexCoords).xyz;
    } else {
        objColor = material.diffuse;
    }

    // interpolate between the cool and the warm term
    vec3 k_cool = hue.cool + objColor * hue.alpha;
    vec3 k_warm = hue.warm + objColor * hue.beta;
    float l_dot_n = dot(normals, lightDir);
    float avg = (1.0 + l_dot_n) / 2.0;
    vec3 color = avg * k_cool + (1.0 - avg) * k_warm;

    // vec3 objColor = vec3(0.1, 0.3, 0.3);
    // vec3 ambient = float(0.1) * lightColor;
    // vec3 diffuse = max(dot(normalize(normals), lightDir), 0.0) * lightColor;
    // vec3 color = (ambient + diffuse) * objColor;
    FragColor = vec4(color, 1.0);
}