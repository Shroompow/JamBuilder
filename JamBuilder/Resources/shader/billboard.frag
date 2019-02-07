#version 330 core
out vec4 FragColor;

in vec2 _tex;

uniform sampler2D texSampler;

uniform vec3 trans;
uniform vec3 scale;
uniform mat4 projection;
uniform mat4 view;
uniform vec4 colorTint;
uniform vec3 colorOffset;

void main(){
	
	FragColor = texture(texSampler, _tex) * colorTint + vec4(colorOffset, 0.0);
}