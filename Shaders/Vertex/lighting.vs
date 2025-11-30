#version 330

in vec2 fragTexCoord;
in vec4 fragColor;
uniform sampler2D texture0;
uniform vec4 colDiffuse;


float Dot(vec2 a, vec2 b){ return a.x * b.x + a.y * b.y;}

vec2 Perpind(vec2 vect){return vec2(vect.y, -vect.x);}

bool PointOnRightSideOfLine(vec2 a, vec2 b, vec2 p)
{
    vec2 ap = p - a;
    vec2 apPerp = Perpind(b - a);
    return Dot(ap, apPerp) > 0;
}

bool IsInTriangle(vec2 p, vec2 a, vec2 b, vec2 c)
{
    bool ab = PointOnRightSideOfLine(a, b, p);
    bool bc = PointOnRightSideOfLine(b, c, p);
    bool ca = PointOnRightSideOfLine(c, a, p);
    
    return ab && bc && ca;
}

void main()
{
    // For Frag Color the vec4 is Litterly just corrosponds to these values of said pixel were on
    //x = red channel
    //y = green channel
    //z = blue channel
    //w = alpha channel
    // and its just the percentage (in decimal) of 0 - 255 ex. 255 = 1.0 and 0 = 0.0
    vec2 uv = gl_FragCoord.xy;
    uv.y = 450.0 - uv.y;

    if (IsInTriangle(uv, vec2(100, 100), vec2(200, 100), vec2(150, 200)))
    {
        fragColor = vec4(1.0, 0.0, 0.0, 1.0);
    }
    else
    {
        fragColor = vec4(0.0, 0.0, 1.0, 1.0);
    }
}