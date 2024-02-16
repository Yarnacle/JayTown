using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Spawn: World
{
    public Spawn(ScreenManager manager, SpriteBatch spriteBatch): base(manager,spriteBatch,(Texture2D) Textures.PixelMaps.Spawn)
    {
    }

    public override void Draw(GameTime gameTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}