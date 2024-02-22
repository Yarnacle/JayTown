using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using JayTown.GameTextures;
using JayTown.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class SpawnEntrance: World
{
    
    public SpawnEntrance(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.SpawnEntrance, new Dictionary<Point, string>()
        {
            { new Point(10, 4), "Spawn" },
            { new Point(10, 5), "Spawn" },
            {new Point(2,-1),"FarmCorner"},
            {new Point(3,-1),"FarmCorner"},
            {new Point(4,-1),"FarmCorner"},
            {new Point(2,10),"PathToHouse"},
            {new Point(3,10),"PathToHouse"},
            {new Point(4,10),"PathToHouse"}
        })
    {
        NPCs.Add(Color.Purple,new Robber(manager,spriteBatch,this));
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        player.SetDrawn(true);
    }
}