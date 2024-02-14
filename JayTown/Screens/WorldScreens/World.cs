using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public abstract class World: FullScreen
{
    private readonly Color[] _pixelMap;
    protected Player Player;

    protected World(ScreenManager manager,SpriteBatch spriteBatch,Texture2D background): base(manager,spriteBatch)
    {
        Player = new Player(spriteBatch, Textures.General.Lan, new Vector2(400, 400), 100, 100);
        _pixelMap = new Color[background.Width * background.Height];
        background.GetData<Color>(_pixelMap);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        for (var y = 0; y < 10; y++)
        {
            for (var x = 0; x < 10; x++)
            {
                SpriteBatch.Draw(Textures.Tiles[_pixelMap[y * 10 + x]], new Rectangle(x * 100, y * 100, 100, 100), Color.White);
            }
        }
    }
}