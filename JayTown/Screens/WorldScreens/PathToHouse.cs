using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class PathToHouse: World
{
    public PathToHouse(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.PathToHouse, new Dictionary<Point, string>()
        {
            { new Point(2, -1), "SpawnEntrance" },
            { new Point(3,-1), "SpawnEntrance" },
            {new Point(4,-1),"SpawnEntrance"}
        })
    {
        
    }
}