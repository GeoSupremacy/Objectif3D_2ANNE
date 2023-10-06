#pragma once
#include "EngineObject.h"


class CircleTrigo :public EngineObject
{
private:
	Vertex* vertex;
	int definition;
public:

	CircleTrigo(const FVector& _position, const float& _radius,const int& _def, const Color& _color = Color::White, const float& _thickness = 0.0f, const Color& _colorThickness = Color::Transparent);
	~CircleTrigo();
	 void Draw(RenderWindow& _window) override;
};

