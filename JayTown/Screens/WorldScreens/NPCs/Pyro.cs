using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Pyro: Npc
{
    public Pyro(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Coral, world, new List<Tuple<Color, string>>()
        {
            
        }, new Point(5, 6), null,null)
    {

    }
}