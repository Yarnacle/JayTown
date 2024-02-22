using System;
using System.Collections.Generic;
using JayTown.GameTextures;
using JayTown.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class FarmCorner: World
{
    public FarmCorner(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.FarmCorner, new Dictionary<Point, string>()
        {
            // { new Point(0, 3), "Spawn" },
            // { new Point(0, 4), "Spawn" },
            {new Point(2,10),"SpawnEntrance"},
            {new Point(3,10),"SpawnEntrance"},
            {new Point(4,10),"SpawnEntrance"}
        })
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        if (NPCs.ContainsKey(Color.Purple)) {
            ((Robber)NPCs[Color.Purple]).Start();
            Player.SetDrawn(true);
        }
    }
}