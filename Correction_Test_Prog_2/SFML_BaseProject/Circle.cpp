#include "Circle.h"

Circle::Circle(const FVector& _position, const float& _radius, const Color& _color, const float& _thickness, const Color& _colorThickness)
{
	regularPolygone = CircleShape(_radius,3);
	regularPolygone.setPosition(_position);
	//? set Origin
	regularPolygone.setRotation(45);
	regularPolygone.setFillColor(_color);
	regularPolygone.setOutlineThickness(_thickness);
	regularPolygone.setOutlineColor(_colorThickness);
}
Circle::~Circle()
{
}

