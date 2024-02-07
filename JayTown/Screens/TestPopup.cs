using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class TestPopup: PopupScreen
{
    public TestPopup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box) : base(manager,spriteBatch,box)
    {
        
    }
    
    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.HomeScreen.Lan, Box, Color.White);
    }
}