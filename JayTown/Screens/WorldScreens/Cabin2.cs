using System;
using System.Collections.Generic;
using JayTown.GameTextures;
using JayTown.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Cabin2: World
{
    public Cabin2(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Cabin2, new Dictionary<Point, string>()
        {
            { new Point(-1, 3), "FarmBend" },
            { new Point(-1,4), "FarmBend" },
            {new Point(10,8),"Hideout"}
        },false)
    {
        NPCs.Add(Color.Gold,new SecretDoor(manager,spriteBatch,this));
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        if (player.GetGridPosition().Y == 8)
        {
            NPCs[Color.Gold].NewPath(new List<Point>() { new Point(9, 8) });
            NPCs[Color.Gold].StartPath();
        }
    }

    protected override void Exit(World world)
    {
        base.Exit(world);
        if (world == ScreenManager.Worlds["FarmBend"])
        {
            NPCs[Color.Gold].SetGridPosition(new Point(9,8));
            NPCs[Color.Gold].NewPath(new List<Point>() {new Point(11,8)});
        }
    }
}