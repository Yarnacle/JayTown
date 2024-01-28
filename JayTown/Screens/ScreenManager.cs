using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace JayTown.Screens;

public class ScreenManager
{
    private FullScreen _background;
    private readonly List<Screen> _foreground;

    public ScreenManager(FullScreen home)
    {
        this._background = home;
        this._foreground = new List<Screen>();
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
        _background.Draw(gameTime);
        foreach (var screen in _foreground)
        {
            screen.Draw(gameTime);
        }
    }

    public void ClearScreen(int screen)
    {
        this._foreground.RemoveAt(screen);
    }

    public void Clear(FullScreen newBackground)
    {
        this._background = newBackground;
        this._foreground.Clear();
    }

    public void RemoveScreen(Screen screen)
    {    
        this._foreground.Remove(screen);
    }

    public void InsertScreen(int i,Screen screen)
    {
        this._foreground.Insert(i,screen);
    }
    public void AddScreen(Screen screen)
    {
        this._foreground.Add(screen);
    }
}