#pragma once
#include "SFMLCore.h"
#include "Content.h"
#include <vector>

using namespace std;
class ViewPort
{
	
#pragma region f/p
private:
	RenderWindow* sfmlWindow = nullptr;
	vector<EngineObject*> allObjects;
#pragma endregion f/p
#pragma region constructeur/destructeur
public:
	ViewPort();
	ViewPort(const float& _length, const float& _height, const string& _name);
	~ViewPort();
#pragma endregion constructeur/destructeur
#pragma region Method
private:
	void DrawAllObjects();
public:
	void Draw();
	void InitAllObjects(const vector<EngineObject*>& _objects);
	void InitAllObjects(Content& _contents);
	void AddObjectToViewport(EngineObject* _object);
	void ClearObjects();
#pragma endregion Method
};

