﻿namespace PintarMyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyGame game = new MyGame();
            UDK.Game.Launch(game);
        }
    }
}