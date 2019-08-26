#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0;  
    vec2 offsets[9] = vec2[](
        vec2(-offset,  offset), // ����
        vec2( 0.0f,    offset), // ����
        vec2( offset,  offset), // ����
        vec2(-offset,  0.0f),   // ��
        vec2( 0.0f,    0.0f),   // ��
        vec2( offset,  0.0f),   // ��
        vec2(-offset, -offset), // ����
        vec2( 0.0f,   -offset), // ����
        vec2( offset, -offset)  // ����
    );

	  float kernel_ruihua[9] = float[](
        -1, -1, -1,
        -1,  9, -1,
        -1, -1, -1
    );
	  float kernel_mohui[9] = float[](
	1.0 / 16, 2.0 / 16, 1.0 / 16,
    2.0 / 16, 4.0 / 16, 2.0 / 16,
    1.0 / 16, 2.0 / 16, 1.0 / 16  
	);
	  float kernel_bianyuan[9] = float[](
        -1, -1, -1,
        -1, 8, -1,
        -1, -1, -1
    );






//����
vec3  fanxiang(vec3 col){
     return (1-col);
}
//�Ҷ�
vec3  huidu1(vec3 col){ 
   return vec3((col.r+col.g+col.b)/3);
}
//�Ҷ�
vec3  huidu2(vec3 col){ 
   return vec3(0.2126 * col.r + 0.7152 * col.g + 0.0722 * col.b);
}
//�˺���
vec3  ruihua (int k){
   vec3 col;
    for(int i = 0; i < 9; i++)
       {
	      if(k==1)
		  col += (vec3(texture(screenTexture, TexCoords.st + offsets[i]))) * kernel_ruihua[i];
		  else if(k==2)
		  col += (vec3(texture(screenTexture, TexCoords.st + offsets[i]))) * kernel_mohui[i];
		  else if(k==3)
		  col += (vec3(texture(screenTexture, TexCoords.st + offsets[i]))) * kernel_bianyuan[i];
        }
	return col;
}


void main()
{

   // vec3 col = texture(screenTexture, TexCoords).rgb;
    FragColor = vec4(ruihua(3), 1.0);
} 