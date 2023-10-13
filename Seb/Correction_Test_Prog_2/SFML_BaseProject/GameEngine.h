#pragma once
#include "ViewPort.h"
#include "Core.h"
class GameEngine
{
	//1 - ViewPort(Render) class
	//2 - RessourceManager (class)
	// 
	// 
	//RunEngine() void
	//StopEngie() void
#pragma region f/p
private:
	vector<EngineObject*> engineObjects;
	ViewPort* viewport = nullptr;
	Content* gameContent = nullptr;
#pragma endregion f/p
#pragma region constructeur/destructeur
public:
	GameEngine();
	GameEngine(const float& _length, const float& _height, const string& _name);
	~GameEngine();
#pragma endregion constructeur/destructeur
#pragma region Method
public:
	void RunEngine();
	void StopEngine();
#pragma endregion Method
};

