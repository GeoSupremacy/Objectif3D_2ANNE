#pragma once
#include <string>
#include "Rectangle.h"

class Windows
{
#pragma region f/p
private:
	std::string name = "Windows";
	float length, height;
	sf::RenderWindow* window = nullptr;
	sf::CircleShape mouse;

	Rectangle* blockSquare = nullptr;
	Rectangle* blockCircle = nullptr;
	Rectangle* blockTriangle = nullptr;

	sf::CircleShape circle;
	sf::RectangleShape square;
	sf::CircleShape triangle;
#pragma endregion f/p
#pragma region constructor/destructor
public:
	Windows(const int _length, const int _height, const std::string _name);
	~Windows();
#pragma endregion constructor/destructor
#pragma region CUSTOM_METHOD
public:
	void GameLoop();
private:
	void Display();
	void Event();
	void Delete();
	void SetColor(const int _index, sf::Color _color);
#pragma endregion CUSTOM_METHOD
#pragma region WINDOW_METHOD
public:
	bool GetHasFocus() const;
	void SetSize(const int _lenght, const int _height)const;
	void SetTitle(const std::string _name) const;
#pragma endregion WINDOW_METHOD
};

