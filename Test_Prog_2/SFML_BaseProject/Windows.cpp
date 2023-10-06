#include "Windows.h"
#include <iostream>

#define REGULAR_EQUILATERAL_TRIANGLE(radius) radius,3
#define SQUARE(radius) radius,4

#pragma region constructor/destructor
Windows::Windows(const int _length, const int _height, const std::string _name)
    : name(_name), length(length), height(_height)
{
    window = new sf::RenderWindow(sf::VideoMode(_length, _height), _name, sf::Style::Close);

    blockSquare = new Rectangle(120, 50, "Square", sf::Color::Red, 100, 250);
    blockTriangle = new Rectangle(120, 50, "Triangle", sf::Color::Red, 230, 250);
    blockCircle = new Rectangle(120, 50, "Circle", sf::Color::Red, 360, 250);


    mouse.setFillColor(sf::Color::Red);
    mouse.setRadius(24);
    mouse.setOrigin(24 / 2, 24 / 2);

    circle.setRadius(50);
    square = sf::RectangleShape(sf::Vector2f(50, 50));
    triangle = sf::CircleShape(REGULAR_EQUILATERAL_TRIANGLE(50));

    circle.setPosition(sf::Vector2f(length / 2, height / 2));
    square.setPosition(length / 2, height / 2);
    triangle.setPosition(sf::Vector2f(length / 2, height / 2));


    triangle.setRadius(100);

    square.setFillColor(sf::Color::Transparent);
    circle.setFillColor(sf::Color::Transparent);
    triangle.setFillColor(sf::Color::Transparent);
}
Windows::~Windows()
{
    Delete();
}
#pragma endregion constructor/destructor
#pragma region CUSTOM_METHOD
void Windows::GameLoop()
{
    while (window->isOpen())
    {
        Event();

        Display();
    }
    Delete();
}
void Windows::Display()
{

    window->clear();
    window->draw(mouse);
    if (blockSquare)
    {
        window->draw(blockSquare->GetShape());
        window->draw(blockSquare->GetText());
    }
    if (blockCircle)
    {
        window->draw(blockCircle->GetShape());
        window->draw(blockCircle->GetText());
    }

    if (blockTriangle)
    {
        window->draw(blockTriangle->GetShape());
        window->draw(blockTriangle->GetText());
    }

    window->draw(square);
    window->draw(triangle);
    window->draw(circle);

    window->display();

}
void Windows::Event()
{
    sf::Event event;
    while (window->pollEvent(event))
    {

        switch (event.type)
        {
        case sf::Event::Closed:
        {
            window->close();
            break;

        }
        case sf::Event::MouseMoved:
        {

            mouse.setPosition(sf::Vector2f(sf::Mouse::getPosition(*window)));

            break;
        }
        case::sf::Event::MouseButtonPressed:
        {

            if (mouse.getPosition().x >= blockSquare->GetPosition().x && mouse.getPosition().x <= blockSquare->GetPosition().x + blockSquare->GetLength()
                && mouse.getPosition().y >= blockSquare->GetPosition().y && mouse.getPosition().y <= blockSquare->GetPosition().y + blockSquare->GetHeight())
            {

                SetColor(0, sf::Color::Red);
            }
            else if (mouse.getPosition().x >= blockTriangle->GetPosition().x && mouse.getPosition().x <= blockTriangle->GetPosition().x + blockTriangle->GetLength()
                && mouse.getPosition().y >= blockTriangle->GetPosition().y && mouse.getPosition().y <= blockTriangle->GetPosition().y + blockTriangle->GetHeight())

            {

                SetColor(2, sf::Color::Red);
            }
            else if (mouse.getPosition().x >= blockCircle->GetPosition().x && mouse.getPosition().x <= blockCircle->GetPosition().x + blockCircle->GetLength()
                && mouse.getPosition().y >= blockCircle->GetPosition().y && mouse.getPosition().y <= blockCircle->GetPosition().y + blockCircle->GetHeight())

            {

                SetColor(1, sf::Color::Red);
            }
        }
        default:
            break;
        }

    }
}
void Windows::Delete()
{
    delete window;
    window = nullptr;


    delete blockSquare;
    delete blockTriangle;
    delete blockCircle;


    blockSquare = nullptr;
    blockTriangle = nullptr;
    blockCircle = nullptr;


}
void Windows::SetColor(const int _index, sf::Color _color)
{
    switch (_index)
    {
    case 0:
        square.setFillColor(_color);
        circle.setFillColor(sf::Color::Transparent);
        triangle.setFillColor(sf::Color::Transparent);
        break;
    case 1:
        square.setFillColor(sf::Color::Transparent);
        circle.setFillColor(_color);
        triangle.setFillColor(sf::Color::Transparent);
        break;
    case 2:
        square.setFillColor(sf::Color::Transparent);
        circle.setFillColor(sf::Color::Transparent);
        triangle.setFillColor(_color);
        break;
    default:
        break;
    }
}
#pragma endregion CUSTOM_METHOD
#pragma region WINDOW_METHOD
bool Windows::GetHasFocus() const
{
    if (window)
        if (window->hasFocus())
            return true;
        else
            return false;
}
void Windows::SetSize(const int _lenght, const int _height) const
{
    if (window)
        window->setSize(sf::Vector2u(_lenght, _height));
}
void Windows::SetTitle(const std::string _name) const
{
    if (window)
        window->setTitle(_name);
}
#pragma endregion WINDOW_METHOD



