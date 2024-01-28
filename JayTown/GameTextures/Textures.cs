using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.GameTextures;

public static class Textures
{
    private static GraphicsDevice _graphicsDevice;
    
    public static dynamic HomeScreen;
    
    public static void Load(ContentManager content,GraphicsDevice graphicsDevice)
    {
        Textures._graphicsDevice = graphicsDevice;
        
        // Directories
        HomeScreen = new ExpandoObject();
        
        // Textures
        HomeScreen.Lan = Load("HomeScreen/Lan.png");
    }

    private static Texture2D Load(string path)
    {
        FileStream fileStream = new FileStream("Content/Textures/" + path, FileMode.Open);
        Texture2D texture = Texture2D.FromStream(_graphicsDevice,fileStream);
        fileStream.Dispose();
        return texture;
    }
}