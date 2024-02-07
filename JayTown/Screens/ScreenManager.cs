using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class ScreenManager
{
    private readonly SpriteBatch _spriteBatch;
    private FullScreen _background;
    private readonly List<Screen> _foreground;

    public ScreenManager(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
        _foreground = new List<Screen>();
    }

public void Update(GameTime gameTime)
    {
        _background.Update(gameTime);
        foreach (var screen in _foreground)
        {
            screen.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        _spriteBatch.Draw(Textures.General.ClearScreen,FullScreen.Box,Color.White);
        _background.Draw(gameTime);
        foreach (var screen in _foreground)
        {
            screen.Draw(gameTime);
        }
    }

    public void ClearForegroundLayer(int screen)
    {
        _foreground.RemoveAt(screen);
    }

    public void ClearTop()
    {
        if (_foreground.Count == 0)
        {
            return;
        }
        _foreground.RemoveAt(_foreground.Count - 1);
    }

    public void ClearForeground()
    {
        _foreground.Clear();
    }
    public void ClearAll(FullScreen newBackground)
    {
        _background = newBackground;
        _foreground.Clear();
    }

    public void ClearForegroundScreen(Screen screen)
    {    
        _foreground.Remove(screen);
    }

    public void InsertScreen(int i,Screen screen)
    {
        _foreground.Insert(i,screen);
    }
    public void AddScreen(Screen screen)
    {
        _foreground.Add(screen);
    }
}