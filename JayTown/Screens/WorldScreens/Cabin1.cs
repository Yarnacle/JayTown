using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Cabin1: World
{
    public Cabin1(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Cabin1, new Dictionary<Point, string>()
        {
            { new Point(5, -1), "PathToHouse" },
            { new Point(6, -1), "PathToHouse" }
        })
    {
        
    }
}