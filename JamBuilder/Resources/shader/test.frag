#version 330 core
out vec4 FragColor;

in vec2 _tex;

uniform sampler2D texSampler;
uniform float time;

void main(){
	
	FragColor = texture(texSampler, _tex+vec2(0.2*sin(time+_tex.y*6),0));
}