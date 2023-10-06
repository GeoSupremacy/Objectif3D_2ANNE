#pragma once
#include <SFML/Graphics.hpp>
class Rectangle
{
#pragma region f/p
private:
	sf::RectangleShape rectangle;
	sf::Font font;
	sf::Text text;
	float length, height;
#pragma endregion f/p
#pragma region constructor/destructor
public:
	Rectangle(const float _length, const float _height, const std::string _text, const sf::Color _color, const float _x, const float _y);
	Rectangle(const float _length, const float _height, const std::string _text, const sf::Color _color);
	~Rectangle();
#pragma endregion constructor/destructor
#pragma region Setteur/Getteur
public:
	sf::RectangleShape GetShape()const;
	sf::Text GetText() const;
	sf::Vector2f GetOrigin()const;
	sf::Vector2f GetPosition()const;
	float GetLength()const;
	float GetHeight()const;
	void SetColor(sf::Color _color);

	void SetPosition(const float _x, const float _y);
#pragma endregion Setteur/Getteur
private:
	void Delete();
};

