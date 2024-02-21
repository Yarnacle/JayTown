using System;
using System.Collections.Generic;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JayTown.Screens.WorldScreens.NPCs;

public abstract class Npc: Tile
{
    protected enum State
    {
        Before,During,After
    }
    
    protected TextPopup DialogueBox;

    protected Player Player;
    // protected  Color TextColor;
    private int _dialogueIndex;
    protected List<Tuple<Color,string>> Dialogue;
    protected State DialogueState;
    
    protected Npc(ScreenManager manager,SpriteBatch spriteBatch,Color color,List<Tuple<Color,string>> dialogue,Player player): base(manager,spriteBatch,new Point(6,4),color)
    {
        Player = player;
        DialogueState = State.Before;
        Dialogue = dialogue;
        _dialogueIndex = 0;
        // TextColor = textColor;
        DialogueBox = new TextPopup(manager, spriteBatch, new Rectangle(0, 750, 1000, 250), Textures.General.Font,
            Dialogue[0].Item2, Dialogue[0].Item1, .6f, 60, Textures.General.DialogueBox);
    }

    public virtual void InitiateDialogue()
    {
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

    public override void Draw(GameTime gameTime)
    {
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
        if (DialogueState == State.During)
        {
            if (Game1.IsKeyPressed(Keys.F))
            {
                NextDialogue();
            }
        }
    }
}