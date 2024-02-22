using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class CobbleRoad: World
{
    public CobbleRoad(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.CobbleRoad, new Dictionary<Point, string>()
        {
            // { new Point(-1, 2), "FarmBend" },
            // { new Point(-1,3), "FarmBend" },
            // { new Point(-1,4), "FarmBend" },
            { new Point(10, 2), "PathToHouse" },
            { new Point(10,3), "PathToHouse" }
        },false)
    {
        
    }
}