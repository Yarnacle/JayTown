using System;
using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public abstract class World: FullScreen
{
    private static readonly List<Color> BarrierColors = new() {Color.Red};

    protected Tile[][] Tiles;

    protected readonly Player Player;

    protected World(ScreenManager manager,SpriteBatch spriteBatch,Texture2D background): base(manager,spriteBatch)
    {
        Player = new Player(manager,this,spriteBatch, Textures.General.Lan, new Point(5,5));
        var pixelMap = new Color[background.Width * background.Height];
        background.GetData(pixelMap);
        Tiles = new Tile[10][];
        for (var y = 0; y < 10; y++)
        {
            Tiles[y] = new Tile[10];
            for (var x = 0; x < 10; x++)
            {
                var color = pixelMap[y * 10 + x];
                var tile = new Tile(ScreenManager, SpriteBatch, new Point(x,y),color);
                ScreenManager.Add(tile);
                Tiles[y][x] = tile;
            }
        }
        ScreenManager.Add(Player);
    }

    public override void Update(GameTime gameTime)
    {
        Player.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        
    }

    public bool CheckTile(Point gridPosition)
    {
        if (gridPosition.Y > 9 || gridPosition.Y < 0 || gridPosition.X > 9 || gridPosition.X < 0)
        {
            return false;
        }

        if (BarrierColors.Contains(Tiles[gridPosition.Y][gridPosition.X].GetColor()))
        {
            return false;
        }

        return true;
    }
}