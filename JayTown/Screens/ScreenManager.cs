using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace JayTown.Screens;

public class ScreenManager
{
    private FullScreen background;
    private List<Screen> foreground;

    public ScreenManager(FullScreen home)
    {
        this.background = home;
        this.foreground = new List<Screen>();
    }

    public void Update(GameTime gameTime)
    {
        background.Update(gameTime);
        foreach (var screen in foreground)
        {
            screen.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        background.Draw(gameTime);
        foreach (var screen in foreground)
        {
            screen.Draw(gameTime);
        }
    }

    public void ClearScreen(int screen)
    {
        this.foreground.RemoveAt(screen);
    }

    public void Clear(FullScreen newBackground)
    {
        this.background = newBackground;
        this.foreground.Clear();
    }

    public void RemoveScreen(Screen screen)
    {    
        this.foreground.Remove(screen);
    }

    public void InsertScreen(int i,Screen screen)
    {
        this.foreground.Insert(i,screen);
    }
    public void AddScreen(Screen screen)
    {
        this.foreground.Add(screen);
    }
}