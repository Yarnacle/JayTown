using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JayTown.GameTextures;
using System;

namespace JayTown.Screens;

public class HomeScreen: FullScreen
{
    public HomeScreen(SpriteBatch spriteBatch): base(spriteBatch)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Draw(Textures.HomeScreen.Lan,FullScreen.rectangle,Color.White);
    }
    
}