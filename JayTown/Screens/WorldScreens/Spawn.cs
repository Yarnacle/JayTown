using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Spawn: World
{
    private readonly Player _player;
    public Spawn(ScreenManager manager, SpriteBatch spriteBatch): base(manager,spriteBatch,(Texture2D) Textures.PixelMaps.Spawn)
    {
        _player = new Player(spriteBatch,Textures.General.Lan, new Vector2(500,500), 100, 100);
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        _player.Draw(gameTime);
    }

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
    }
}