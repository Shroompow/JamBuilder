#version 330 core
layout (location = 0) in vec2 _inPos;
layout (location = 1) in vec2 _inTex;

out vec2 _tex;

void main(){
	gl_Position = vec4(_inPos, 0.0, 1.0);
	_tex = _inTex;
}