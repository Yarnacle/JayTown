using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Chenny: Npc
{
    public Chenny(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
    Color.LightGreen, world, null, new Point(2, 6), null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.LightGreen,"Clear... my... search history..."),
        Tuple.Create(Color.DarkOrange,"No shot you actually killed him. But don't call for medical attention! I don't want to be in debt for the rest of my life...")
    })
    {

    }
    
    public override void AfterDeath()
    {
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.IndianRed,"Well done. You're on a roll!"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Those guys were really going at it every single day. It's a wonder how they even got together in the first place if you ask me."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Okay, back to business. Recently, there has been a surge in incidents involving farmers being hostile towards new nearby establishments."),
            Tuple.Create(Color.IndianRed,"I think it's time we put our foot down and remind them who calls the shots in this town. How about we start with Vorrow and his farm just north of here?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Alright then! We make a good team.")
        });
    }
}