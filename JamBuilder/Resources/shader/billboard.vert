#version 330 core
layout (location = 0) in vec2 _inPos;
layout (location = 1) in vec2 _inTex;

out vec2 _tex;

uniform vec3 trans;
uniform vec3 scale;
uniform mat4 projection;
uniform mat4 view;
uniform vec4 colorTint;
uniform vec3 colorOffset;

void main(){

	vec3 cRight = vec3(view[0][0], view[1][0], view[2][0]);
	vec3 cUp = vec3(view[0][1], view[1][1], view[2][1]);
	vec3 worldP = vec3(view[0][3],view[1][3],view[2][3]) + trans + cRight * _inPos.x * scale.x + cUp * _inPos.y * scale.y;
	gl_Position = projection * vec4(worldP, 1.0);
	_tex = _inTex;
	/*vec4 center = projection * view * vec4(trans,1.0);
	center /= center.w;
	gl_Position = vec4(vec3(_inPos,0.0)*scale+center.xyz, 1.0);
	_tex = _inTex;*/
}