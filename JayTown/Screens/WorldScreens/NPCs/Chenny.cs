using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Chenny: Npc
{
    public Chenny(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
    Color.LightGreen, world, null, new Point(2, 6), null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.LightGreen,"Clear... my... search history..."),
        Tuple.Create(Color.DarkOrange,"No shot you actually killed him. But don't call for medical attention! I don't want to be in debt for the rest of my life...")
    })
    {

    }
}