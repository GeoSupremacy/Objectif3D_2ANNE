#include "Square.h"


Square::Square(const FVector& _position, const int& _size, const Color& _color, const float& _thickness, const Color& _colorThickness)
{
	regularPolygone = CircleShape(_size, SQUARE);
	regularPolygone.setPosition(_position);
	//? set Origin
	regularPolygone.setRotation(45);
	regularPolygone.setFillColor(_color);
	regularPolygone.setOutlineThickness(_thickness);
	regularPolygone.setOutlineColor(_colorThickness);
}
Square::~Square()
{
}

