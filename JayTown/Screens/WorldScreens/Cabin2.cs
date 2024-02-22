using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Cabin2: World
{
    public Cabin2(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Cabin2, new Dictionary<Point, string>()
        {
            { new Point(-1, 3), "FarmBend" },
            { new Point(-1,4), "FarmBend" }
        },false)
    {
        
    }
}