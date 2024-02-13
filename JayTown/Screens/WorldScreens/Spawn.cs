using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public class Spawn: FullScreen
{
    private readonly Player _player;
    public Spawn(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch)
    {
        _player = new Player(Textures.General.Lan, new Vector2(500,500), 100, 100);
    }

    public override void Draw(GameTime gameTime)
    {
        _player.Draw(SpriteBatch,gameTime);
    }

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
    }
}