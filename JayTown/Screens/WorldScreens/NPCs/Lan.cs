using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Lan: Npc
{
    public Lan(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Beige, world, null, new Point(4, 7), null,new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.LightBlue,"Some greater good indeed...")
        })
    {

    }
}