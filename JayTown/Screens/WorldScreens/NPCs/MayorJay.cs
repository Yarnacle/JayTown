using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class MayorJay: Npc
{
    public MayorJay(ScreenManager manager,SpriteBatch spriteBatch,Player player) : base(manager,spriteBatch, Color.Maroon,new List<Tuple<Color,string>>()
    {
        Tuple.Create(Color.DarkRed,"Hello! Ready for your next task?"),
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.DarkRed,"Talkative as usual. Anyway there's a ROBBER on the lose. Get him please. Please and thank you.")
    },player) {
        
    }

    public override void InitiateDialogue()
    {
        base.InitiateDialogue();
    }
}