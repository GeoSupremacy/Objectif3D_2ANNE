using System;

namespace RPG
{
    internal class ViewPort
    {
        Map currentMap = null;
        Player player =null;
        public ViewPort()
        {
            currentMap = new Map();
            player = new Player();

            player.SetPosition(currentMap);

            while (true)
            {
                currentMap.AddGrid();
                player.Movement();
                currentMap.SetPlayer(player);
               // Console.Read();
            }
        }
    }
}
