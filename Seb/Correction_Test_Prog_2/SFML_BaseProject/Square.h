#pragma once
#include "RegularPolygons.h"



class Square : public RegularPolygons
{
public:
	Square(const FVector& _position, const int& _radius, const Color& _color = Color::White, const float& _thickness = 0.0f, const Color& _colorThickness = Color::Transparent);
	~Square();
	
	//void Draw(RenderWindow& _window) override { _window.draw(regularPolygone); };
	//virtual void Draw(RenderWindow& _window) override { _window.draw(regularPolygone); }
	//void Draw() override { _window.draw(regularPolygone); }
};

