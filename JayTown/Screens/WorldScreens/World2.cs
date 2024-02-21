using System.Collections.Generic;
using System.Text.Encodings.Web;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class World2: World
{
    public World2(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.World2, new Dictionary<Point, string>()
        {
            { new Point(10, 4), "Spawn" },
            { new Point(10, 5), "Spawn" },
            { new Point(10,1),"Spawn"}
        })
    {
        
    }
}