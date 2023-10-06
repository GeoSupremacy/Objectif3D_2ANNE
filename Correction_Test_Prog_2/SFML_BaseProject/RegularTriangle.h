#pragma once
#include "RegularPolygons.h"


class RegularTriangle :public RegularPolygons
{
	
public:
	RegularTriangle(const FVector& _position, const float& _radius, const Color& _color = Color::White, const float& _thickness = 0.0f, const Color& _colorThickness = Color::Transparent);
	~RegularTriangle();
};

