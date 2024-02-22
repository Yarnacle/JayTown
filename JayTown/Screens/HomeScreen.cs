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
    private readonly TextPopup _text2;
    
    public HomeScreen(ScreenManager manager,SpriteBatch spriteBatch): base(manager,spriteBatch)
    {
        _number = 0;
        _text = new TextPopup(manager, spriteBatch, new Rectangle(100, 600, 800, 400),Textures.General.Font,"Press [ENTER] to play\nPress [F] to interact",Color.Black,1f,50,Textures.General.Transparent);
        _text2 = new TextPopup(manager, spriteBatch, new Rectangle(100, 800, 800, 400),Textures.General.Font,"Press [SPACE] to Kill",Color.Maroon,1f,50,Textures.General.Transparent);
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
            ScreenManager.ClearForeground();
            ScreenManager.Worlds["Spawn"].Enter(new Player(ScreenManager,SpriteBatch, Textures.General.SheriffJay,new Point(5, 5)));
            ScreenManager.SetBackgroud(ScreenManager.Worlds["Spawn"]);
        }
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.HomeScreen.Background,FullScreen.Box,Color.White);
        _text.Draw(gameTime);
        _text2.Draw(gameTime);
    }
}