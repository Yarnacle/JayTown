using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Pav: Npc
{
    public Pav(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
    Color.DarkOrange, world, new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.DarkOrange, "Bro Chenny is such an op!"),
        Tuple.Create(Color.LightGreen,"Sooo who forgot to file our taxes?"),
        Tuple.Create(Color.DarkOrange,"Sooooooo who pays for this house?"),
        Tuple.Create(Color.LightGreen,"Aight bro. You're only where you are today because of me."),
        Tuple.Create(Color.DarkOrange,"Nah nah nah, I carried you though college. YOU'RE where YOU are because of ME."),
        Tuple.Create(Color.LightGreen,"Who kept giving you that lil calc plug?"),
        Tuple.Create(Color.DarkOrange,"Bro the sheriff can HEAR YOU."),
        Tuple.Create(Color.LightGreen,"YOU'RE THE ONE YELLING!"),
        Tuple.Create(Color.DarkOrange,"CALM YO ASS DOWN."),
        Tuple.Create(Color.LightGreen,"NAH I'M GONNA BOX YOUR ASS UP-"),
        Tuple.Create(Color.DarkOrange,"OH, SO THAT'S HOW IT IS THEN. YOU'RE NOT READY FOR THIS.")
    }, new Point(5, 6), null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.DarkOrange,"Clear... my... search history..."),
        Tuple.Create(Color.LightGreen,"Don't call for medical attention! I don't want to be in debt for the rest of my life...")
    })
    {

    }
}