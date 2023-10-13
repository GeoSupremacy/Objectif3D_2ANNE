#pragma once
#include "RegularPolygons.h"


class Circle :public RegularPolygons
{
public:
	Circle(const FVector& _position, const float& _radius, const Color& _color = Color::White, const float& _thickness = 0.0f, const Color& _colorThickness= Color::Transparent);
	~Circle();
};

