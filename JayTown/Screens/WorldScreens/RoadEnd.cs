using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class RoadEnd: World
{
    public RoadEnd(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.RoadEnd, new Dictionary<Point, string>()
        {
            { new Point(10, 2), "CobbleRoad" },
            { new Point(10,3), "CobbleRoad" }
        },false)
    {
        
    }
}