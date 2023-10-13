#pragma once
#include "EngineObject.h"

enum Convex
{
	Rectangle_Triangle = 0,
	Rectangle=1,
};

 class ComplexPolygone : public EngineObject
{
protected:
	Vertex* vertex;
	int definition;

};

