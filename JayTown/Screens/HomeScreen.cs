using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JayTown.GameTextures;
using System;
using JayTown.Screens.WorldScreens;
using Microsoft.Xna.Framework.Input;

namespace JayTown.Screens;

public class HomeScreen: FullScreen
{
    private int _number;
    private readonly TextPopup _text;
    
    public HomeScreen(ScreenManager manager,SpriteBatch spriteBatch): base(manager,spriteBatch)
    {
        _number = 0;
        _text = new TextPopup(manager, spriteBatch, new Rectangle(200, 600, 500, 100),Textures.General.Font,"Press [ENTER] to play",Color.White,(float)1);
    }

    public override void Update(GameTime gameTime)
    {
        if (Game1.IsKeyDown(Keys.Space))
        {
            var random = new Random();
            ScreenManager.Add(new TestPopup(ScreenManager,SpriteBatch,new Rectangle(random.Next(0,700),random.Next(0,700),300,300)));
            _number++;
        }

        if (Game1.IsKeyDown(Keys.LeftShift))
        {
            ScreenManager.ClearTop();
            _number = Math.Max(0, _number - 1);
        }

        if (Game1.IsKeyPressed(Keys.C))
        {
            ScreenManager.ClearForeground();
        }

        if (Game1.IsKeyPressed(Keys.Enter))
        {
            ScreenManager.ClearAll(new Spawn(ScreenManager,SpriteBatch));
        }

        Game1.UpdateKb();
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.HomeScreen.Background,FullScreen.Box,Color.White);
        _text.Draw(gameTime);
    }
    
}