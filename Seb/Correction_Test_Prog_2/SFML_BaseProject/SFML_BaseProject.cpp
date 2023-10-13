#include "GameEngine.h"


int main()
{
	GameEngine* _engine = new GameEngine();
	_engine->RunEngine();
	delete _engine;
}

