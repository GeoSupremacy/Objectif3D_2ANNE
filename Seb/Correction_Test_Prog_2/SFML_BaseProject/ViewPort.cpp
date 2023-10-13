#include "ViewPort.h"


#pragma region constructeur/destructeur
ViewPort::ViewPort()
{
	sfmlWindow = new RenderWindow(VideoMode(1280, 720), "Render");
}
ViewPort::ViewPort(const float& _length, const float& _height, const string& _name)
{
	sfmlWindow = new RenderWindow(VideoMode(_length, _height), _name);
	
}
ViewPort::~ViewPort()
{
	delete sfmlWindow;
	for (EngineObject*  _obj : allObjects)
		delete _obj;
	
}
#pragma endregion constructeur/destructeur
#pragma region Method
void ViewPort::Draw()
{
	while (sfmlWindow->isOpen())
	{
		Event _event;
		while (sfmlWindow->pollEvent(_event))
		{
			if (_event.type == Event::Closed)
				sfmlWindow->close();
		}
		sfmlWindow->clear();
		
		DrawAllObjects();
		sfmlWindow->display();
	}
}
void ViewPort::DrawAllObjects()
{
	for (EngineObject* _ob : allObjects)
	{
		if (!_ob)
			continue;
		_ob->Draw(*sfmlWindow);
	}
}
void ViewPort::InitAllObjects(const vector<EngineObject*>& _objects)
{
	allObjects = _objects;
}
void ViewPort::InitAllObjects(Content& _contents)
{
	allObjects = _contents.Get();
	
}
void ViewPort::AddObjectToViewport(EngineObject* _object)
{
	allObjects.push_back(_object);
}
void ViewPort::ClearObjects()
{
	for (EngineObject* _ob : allObjects)
	delete _ob;
	
}
#pragma endregion Method