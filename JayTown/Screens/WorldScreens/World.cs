using System.Collections.Generic;
using JayTown.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens;

public abstract class World: FullScreen
{
    protected bool IsRunning;
    protected List<Npc> NPCs;
    
    protected Dictionary<Point,string> Exits;
    private static readonly List<Color> BarrierColors = new() {Color.Red};

    protected Tile[][] Tiles;

    protected Player Player;

    protected World(ScreenManager manager, SpriteBatch spriteBatch, Texture2D background,Dictionary<Point,string> exits) : base(manager,spriteBatch)
    {
        NPCs = new List<Npc>();
        Player = null;
        Exits = exits;
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
                Tiles[y][x] = tile;
            }
        }

        IsRunning = false;
    }

    public virtual void Enter(Player player)
    {
        for (var y = 0; y < 10; y++)
        {
            for (var x = 0; x < 10; x++)
            {
                ScreenManager.Add(Tiles[y][x]);
            }
        }
        
        Player = player;
        Player.SetWorld(this);
        ScreenManager.Add(Player);
        IsRunning = true;
    }

    private void Exit(World world)
    {
        ScreenManager.SetBackgroud(world);
        ScreenManager.ClearForeground();
        IsRunning = false;
        world.Enter(Player);
        Player = null;
    }

    public override void Update(GameTime gameTime)
    {
        if (!IsRunning)
        {
            return;
        }

        Player.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        
    }

    public bool CheckTile(Point gridPosition)
    {
        if (gridPosition.Y > 9 || gridPosition.Y < 0 || gridPosition.X > 9 || gridPosition.X < 0)
        {
            if (Exits.ContainsKey(gridPosition))
            {
                Exit(ScreenManager.Worlds[Exits[gridPosition]]);
                return true;
            }
            return false;
        }

        if (BarrierColors.Contains(Tiles[gridPosition.Y][gridPosition.X].GetColor()))
        {
            return false;
        }

        foreach (var npc in NPCs)
        {
            if (npc.GetGridPosition() == gridPosition)
            {
                npc.InitiateDialogue();
                return false;
            }
        }

        return true;
    }
}