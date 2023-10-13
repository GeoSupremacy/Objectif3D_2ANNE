#pragma once
#include "EngineObject.h"

class RegularPolygons : public EngineObject
{
protected:
	CircleShape regularPolygone;
public:
	void Draw(RenderWindow& _window) override { _window.draw(regularPolygone); };
};

