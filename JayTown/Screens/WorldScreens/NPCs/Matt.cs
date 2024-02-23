using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Matt: Npc
{
    public Matt(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Tomato, world, null, new Point(6, 7), null,null)
    {

    }
}