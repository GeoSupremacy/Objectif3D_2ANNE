#include <iostream>
#include <SFML/Graphics.hpp>
#include "Windows.h"


Windows windows = Windows(1600,560,"View");
int main()
{

    windows.GameLoop();

    return 0;
}

