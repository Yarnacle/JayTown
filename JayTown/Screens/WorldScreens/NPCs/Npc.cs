using System;
using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JayTown.Screens.WorldScreens.NPCs;

public abstract class Npc: Tile
{
    protected List<Point> Path;
    protected World World;
    protected int Destination;
    protected enum State
    {
        Before,During,After
    }

    protected bool Dead;
    private int _deathFrames;
    
    protected TextPopup DialogueBox;

    protected Player Player;
    private int _dialogueIndex;
    protected List<Tuple<Color,string>> Dialogue;
    protected State DialogueState;
    
    protected Npc(ScreenManager manager,SpriteBatch spriteBatch,Color color,World world,List<Tuple<Color,string>> dialogue,Point gridPosition,List<Point> path): base(manager,spriteBatch,gridPosition,color)
    {
        Dead = false;
        _deathFrames = -1;
        World = world;
        Destination = -1;
        Path = path;
        DialogueState = State.Before;
        Dialogue = dialogue;
        _dialogueIndex = 0;
        // TextColor = textColor;
        DialogueBox = new TextPopup(manager, spriteBatch, new Rectangle(0, 750, 1000, 250), Textures.General.Font,
            Dialogue[0].Item2, Dialogue[0].Item1, .6f, 60, Textures.General.DialogueBox);
    }

    public void SetPlayer(Player player)
    {
        Player = player;
    }

    public bool IsDead()
    {
        return Dead;
    }

    public virtual void InitiateDialogue()
    {
        if (Dead)
        {
            return;
        }
        if (DialogueState == State.After)
        {
            return;
        }

        Player.SetParalyzed(true);
        DialogueState = State.During;
    }
    public void NextDialogue()
    {
        if (_dialogueIndex == Dialogue.Count - 1)
        {
            DialogueState = State.After;
            Player.SetParalyzed(false);
            return;
        }
        _dialogueIndex++;
        DialogueBox.SetColor(Dialogue[_dialogueIndex].Item1);
        DialogueBox.SetText(Dialogue[_dialogueIndex].Item2);
    }

    public void Die()
    {
        if (Dead)
        {
            return;
        }
        Dead = true;
        _deathFrames = 0;
        DialogueState = State.After;
        
    }

    public void ChangeWorld(World world,Point position,List<Point> newPath,List<Tuple<Color,string>> newDialogue)
    {
        GridPosition = position;
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
        World = world;
        Path = newPath;
        Dialogue = newDialogue;
        DialogueState = State.Before;
        _dialogueIndex = 0;
        world.AddNPC(this);
    }

    public Point GetDestination()
    {
        if (Destination < 0 || Destination > Path.Count)
        {
            return GridPosition;
            
        }
        if (Path[Destination].Y > GridPosition.Y)
        {
            return new Point(GridPosition.X, GridPosition.Y + 1);
        }
        
        if (Path[Destination].Y < GridPosition.Y)
        {
            return new Point(GridPosition.X, GridPosition.Y - 1);
        }
        
        if (Path[Destination].X > GridPosition.X)
        {
            return new Point(GridPosition.X + 1, GridPosition.Y);
        }
        
        if (Path[Destination].X < GridPosition.X)
        {
            return new Point(GridPosition.X - 1, GridPosition.Y);
        }
        
        return GridPosition;
    }

    public override void Draw(GameTime gameTime)
    {
        // SpriteBatch.Draw(Textures.General.SolidColor,new Rectangle(GridPosition.X * 100,GridPosition.Y * 100,100,100),Color.White);
        if (_deathFrames > 40)
        {
            SpriteBatch.Draw(Textures.NPCs.Death3,Box,Color.White);
        }
        else if (_deathFrames > 30)
        {
            SpriteBatch.Draw(Textures.NPCs.Death3,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 45,Box.Width,Box.Height - 90),Color.White);
        }
        else if (_deathFrames > 20)
        {
            SpriteBatch.Draw(Textures.NPCs.Death2,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 40,Box.Width,Box.Height - 80),Color.White);
        }
        else if (_deathFrames > 10)
        {
            SpriteBatch.Draw(Textures.NPCs.Death1,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 30,Box.Width,Box.Height - 60),Color.White);
        }
        else if (_deathFrames > -1)
        {
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 10,Box.Width,Box.Height - 20),Color.White);
        }

        if (Dead)
        {
            return;
        }
        base.Draw(gameTime);
        if (DialogueState == State.During)
        {
            DialogueBox.Draw(gameTime);
            if (_dialogueIndex < Dialogue.Count - 1)
            {
                SpriteBatch.Draw(Textures.General.NextArrow, new Rectangle(910,910, 32, 32), Color.White);
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        if (Dead)
        {
            if (GridPosition != GetDestination())
            {
                if (GetDestination().X * 100 > Box.X)
                {
                    Box.X += 5;
                }
                else if (GetDestination().Y * 100 > Box.Y)
                {
                    Box.Y += 5;
                }
                else if (GetDestination().X * 100 < Box.X)
                {
                    Box.X -= 5;
                }
                else if (GetDestination().Y * 100 < Box.Y)
                {
                    Box.Y -= 5;
                }

                if (Box.X == GetDestination().X * 100 && Box.Y == GetDestination().Y * 100)
                {
                    GridPosition = GetDestination();
                    Destination = -1;
                    Console.WriteLine("No more remains momentum");
                }
            }
            _deathFrames++;
            return;
        }
        if (DialogueState == State.During)
        {
            if (Game1.IsKeyPressed(Keys.F))
            {
                NextDialogue();
            }
        }

        if (Destination > -1 && Destination < Path.Count)
        {
            if (Box.Y % 100 == 0 && Box.X % 100 == 0)
            {
                GridPosition = new Point(Box.X / 100, Box.Y / 100);
            }
            if (Path[Destination].Y * 100 == Box.Y && Path[Destination].X * 100 == Box.X)
            {
                Destination++;
            }
            else if (Path[Destination].Y > GridPosition.Y)
            {
                Box.Y += 5;
            }
            else if (Path[Destination].X > GridPosition.X)
            {
                Box.X += 5;
            }
            else if (Path[Destination].X < GridPosition.X)
            {
                Box.X -= 5;
            }
            else
            {
                Box.Y -= 5;
            }
        }
    }
}