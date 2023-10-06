#include "CircleTrigo.h"
#define PI 3.14159265359
#define To_RAD PI/180

CircleTrigo::CircleTrigo(const FVector& _position, const float& _radius, const int& _def, const Color& _color, const float& _thickness, const Color& _colorThickness)
{
	definition = _def;
	vertex = new Vertex[_def +1];
	for (size_t i = 0; i < _def +1; i++)
	{
		const float _part = ((float)i / _def) * 360,
			_x = cos((_part * To_RAD)) * _radius,
			_y = sin((_part * To_RAD)) * _radius;

		vertex[i] = Vertex(FVector(_x, _y)+ _position, _color);

		//x = cos(deg -> toRad) * radius;
		//y = cos(deg -> toRad) * radius;
		//a[i] = Vector(x,y) + _pos;
	}
}
CircleTrigo::~CircleTrigo()
{
	delete[] vertex;
}

void CircleTrigo::Draw(RenderWindow& _window)
{
	_window.draw(vertex, definition+1, Lines);
}
