using System.Collections.Generic;
using System.Transactions;
using JayTown.GameTextures;
using JayTown.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Spawn : World
{
    private MayorJay MJ;

    public Spawn(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Spawn, new Dictionary<Point, string>()
        {
            { new Point(-1, 4), "World2" },
            { new Point(-1, 5), "World2" },
            {new Point(-1,1),"World2"}
        })
    {
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        MJ = new MayorJay(ScreenManager,SpriteBatch,Player);
        NPCs.Add(MJ);
        ScreenManager.Add(MJ);
    }

    public override void Draw(GameTime gameTime)
    {
    }

    // public override void Update(GameTime gameTime)
    // {
    //     base.Update(gameTime);
    // }
}