#include "Rectangle.h"
#include <iostream>

#pragma region constructeur/destructeur
Rectangle::Rectangle(const float _length, const float _height, const std::string _text, const sf::Color _color, const float _x, const float _y)
	: length(_length), height(_height)
{
	rectangle = sf::RectangleShape(sf::Vector2f(length, height));

	if (!font.loadFromFile("../Fonts/Dateline.otf"))
		return;

	rectangle.setPosition(_x, _y);

	text.setFont(font);
	text.setString(_text);
	text.setFillColor(_color);
	text.setCharacterSize(height / 2);
	text.setOrigin(length / 2 / 2, height / 2 / 2);
	text.setPosition(rectangle.getPosition().x + length / 2, rectangle.getPosition().y + height / 2);



}
Rectangle::Rectangle(const float _length, const float _height, const std::string _text, const sf::Color _color)
	: length(_length), height(_height)
{
	rectangle = sf::RectangleShape(sf::Vector2f(length, height));

	if (!font.loadFromFile("../Fonts/Dateline.otf"))
		return;


	rectangle.setPosition(100, 130);

	text.setFont(font);
	text.setString(_text);
	text.setFillColor(_color);
	text.setCharacterSize(height / 2);
	text.setOrigin(height / 2 / 2, height / 2 / 2);
	text.setPosition(rectangle.getPosition().x + length / 2, rectangle.getPosition().y + height / 2);
}
Rectangle::~Rectangle()
{
	Delete();
}
#pragma endregion constructeur/destructeur
#pragma region Getteur/Setteur
sf::Text Rectangle::GetText() const
{
	return text;
}
sf::RectangleShape Rectangle::GetShape() const
{
	return rectangle;
}
sf::Vector2f Rectangle::GetOrigin() const
{
	return sf::Vector2f(length / 2, height / 2);
}
sf::Vector2f Rectangle::GetPosition() const
{
	return rectangle.getPosition();
}
void Rectangle::SetColor(sf::Color _color)
{
	rectangle.setFillColor(_color);
}
void Rectangle::SetPosition(const float _x, const float _y)
{
	rectangle.setPosition(_x, _y);
}
float Rectangle::GetLength()const
{
	return length;
}
float Rectangle::GetHeight()const
{
	return height;
}
#pragma endregion Getteur/Setteur

void Rectangle::Delete()
{
	
}

