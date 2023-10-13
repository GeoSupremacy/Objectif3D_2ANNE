#pragma once
#include "SFMLCore.h"



class EngineObject 
{
public:
	EngineObject() = default;
	~EngineObject() = default;
public:
	virtual void Draw(RenderWindow& _window) { };
};

