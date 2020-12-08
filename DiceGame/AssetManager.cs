using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public class AssetManager
    {
        public static Texture2D diceDistanceAttackTexture;
        public static Texture2D diceDistanceBlockTexture;
        public static Texture2D diceMaleAttackTexture;
        public static Texture2D diceMaleBlockTexture;
        public static Texture2D tableTexture;
        public static Texture2D floorTexture;
        public static Texture2D lifeTexture;
        
        public static void loadTextures(GraphicsDevice graphicsDevice)
        {
            diceDistanceAttackTexture = makeTexture("icon_distance_attack.png", graphicsDevice);
            diceDistanceBlockTexture = makeTexture("icon_distance_block.png", graphicsDevice);
            diceMaleAttackTexture = makeTexture("icon_male_attack.png", graphicsDevice);
            diceMaleBlockTexture = makeTexture("icon_male_block.png", graphicsDevice);
            
            tableTexture = makeTexture("table.png", graphicsDevice);
            floorTexture = makeTexture("floor.png", graphicsDevice);
            lifeTexture = makeTexture("icon_life.png", graphicsDevice);
        }

        private static Texture2D makeTexture(String image, GraphicsDevice graphicsDevice)
        {
            var stream = new FileStream("Content/" + image, FileMode.Open);
            var texture = Texture2D.FromStream(graphicsDevice, stream);
            stream.Close();
            return texture;
        }
    }
}