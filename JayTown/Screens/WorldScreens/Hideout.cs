using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Hideout: World
{
    public Hideout(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Hideout, new Dictionary<Point, string>()
        {
            { new Point(-1, 8), "Cabin2" }
        },false)
    {
        
    }
}