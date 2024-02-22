using System;
using System.Collections.Generic;
using System.Dynamic;
using JayTown.GameTextures;
using JayTown.Screens.WorldScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class ScreenManager
{
    private readonly SpriteBatch _spriteBatch;
    private FullScreen _background;
    private readonly List<Screen> _foreground;
    private int _kills;

    public readonly Dictionary<string,World> Worlds;

    public ScreenManager(SpriteBatch spriteBatch)
    {
        _kills = 0;
        _spriteBatch = spriteBatch;
        _foreground = new List<Screen>();

        Worlds = new Dictionary<string, World>()
        {
            { "Spawn", new Spawn(this, spriteBatch) },
            {"SpawnEntrance",new SpawnEntrance(this,spriteBatch)},
            {"FarmCorner",new FarmCorner(this,spriteBatch)},
            {"PathToHouse",new PathToHouse(this,spriteBatch)},
            {"Cabin1",new Cabin1(this,spriteBatch)}
        };
    }

    public void AddKill()
    {
        _kills++;
    }

    public List<Screen> GetForeground()
    {
        return _foreground;
    }
    
public void Update(GameTime gameTime)
    {
        _background.Update(gameTime);
        try
        {
            foreach (var screen in _foreground)
            {
                screen.Update(gameTime);
            }
        }
        catch
        {
            return;
        }

        Game1.UpdateKb();
    }

    public void Draw(GameTime gameTime)
    {
        _spriteBatch.Draw(Textures.General.ClearScreen,FullScreen.Box,Color.White);
        _background.Draw(gameTime);
        foreach (var screen in _foreground)
        {
            screen.Draw(gameTime);
        }
        _spriteBatch.Draw(Textures.General.Vignette,FullScreen.Box,Color.White *  .2f * _kills);
    }

    public void RemoveAt(int index)
    {
        _foreground.RemoveAt(index);
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
    public void SetBackgroud(FullScreen background)
    {
        _background = background;
    }

    public void Remove(Screen screen)
    {    
        _foreground.Remove(screen);
    }

    public void Insert(int i,Screen screen)
    {
        _foreground.Insert(i,screen);
    }
    public void Add(Screen screen)
    {
        _foreground.Add(screen);
    }
}