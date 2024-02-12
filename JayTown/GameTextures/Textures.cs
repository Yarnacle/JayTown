using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.GameTextures;

public static class Textures
{
    private static GraphicsDevice _graphicsDevice;
    
    // Directories
    public static readonly dynamic HomeScreen = new ExpandoObject();
    public static readonly dynamic General = new ExpandoObject();
    
    public static void Load(GraphicsDevice graphicsDevice,ContentManager content)
    {
        _graphicsDevice = graphicsDevice;
        
        // Textures
        General.SolidColor = Load("General/SolidColor.png");
        General.ClearScreen = Load("General/ClearScreen.png");
        General.Font = LoadFont(content,"PixelFont");
        
        HomeScreen.Lan = Load("HomeScreen/Lan.png");
        HomeScreen.Background = Load("HomeScreen/Background.png");
    }

    private static Texture2D Load(string path)
    {
        var fileStream = new FileStream("Content/Textures/" + path, FileMode.Open);
        var texture = Texture2D.FromStream(_graphicsDevice,fileStream);
        fileStream.Close();
        return texture;
    }

    private static SpriteFont LoadFont(ContentManager content,string path)
    {
        return content.Load<SpriteFont>(path);
    }
}