#include "Content.h"
#include "CoreEngineObject.h"


Content::Content()
{
	engineObjects.push_back(new Square(FVector(500, 500), 50.0f,Color::Blue, 0));
	engineObjects.push_back(new RegularTriangle(FVector(570, 500), 50.0f));
	engineObjects.push_back(new Circle(FVector(620, 500), 100.0f));
	engineObjects.push_back(new CircleTrigo(FVector(100,100),50,480*2));
}

Content::~Content()
{
	for (EngineObject* _obj : engineObjects)
		delete _obj;
}
