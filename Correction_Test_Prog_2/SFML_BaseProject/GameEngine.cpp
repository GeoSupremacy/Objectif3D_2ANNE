#include "GameEngine.h"

#pragma region constructeur/destructeur
GameEngine::GameEngine()
{
	viewport = new ViewPort();
	gameContent = new Content();
}
GameEngine::GameEngine(const float& _length, const float& _height, const string& _name)
{
	viewport = new ViewPort(_length, _height, _name);
	gameContent = new Content();
}
GameEngine::~GameEngine()
{
	delete viewport, gameContent;
}
#pragma endregion constructeur/destructeur
#pragma region Method
void GameEngine::RunEngine()
{
	
	viewport->InitAllObjects(*gameContent);
	viewport->Draw();
}
void GameEngine::StopEngine()
{
	//TODO viewport->Stop()....
}
#pragma endregion Method


