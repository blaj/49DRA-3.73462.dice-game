using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DiceGame
{
    public class AssetManager
    {
        public static Texture2D diceDistanceAttackTexture;
        public static Texture2D diceDistanceBlockTexture;
        public static Texture2D diceMaleAttackTexture;
        public static Texture2D diceMaleBlockTexture;
        
        public static Texture2D diceHoverTexture;
        
        public static Texture2D tableTexture;
        public static Texture2D floorTexture;
        public static Texture2D lifeTexture;
        public static Texture2D blackTexture;

        public static Texture2D buttonTexture;

        public static Song inGameAudio;
        public static Song mainMenuAudio;
        public static SoundEffect diceClickAudio;
        public static SoundEffect buttonClickAudio;

        public static SpriteFont arialFont;
        public static SpriteFont pressStartFont;

        public static void loadTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            diceDistanceAttackTexture = content.Load<Texture2D>("Sprites/Dice/DiceDistanceAttack");
            diceDistanceBlockTexture = content.Load<Texture2D>("Sprites/Dice/DiceDistanceBlock");
            diceMaleAttackTexture = content.Load<Texture2D>("Sprites/Dice/DiceMaleAttack");
            diceMaleBlockTexture = content.Load<Texture2D>("Sprites/Dice/DiceMaleBlock");

            diceHoverTexture = content.Load<Texture2D>("Sprites/Dice/DiceHoverBorder");

            tableTexture = content.Load<Texture2D>("Sprites/Table");
            floorTexture = content.Load<Texture2D>("Sprites/Floor");
            lifeTexture = content.Load<Texture2D>("Sprites/PlayerLife");
            
            blackTexture = new Texture2D(graphicsDevice, 1, 1);
            blackTexture.SetData(new[] { Color.Black });

            buttonTexture = content.Load<Texture2D>("Sprites/Button");
        }

        public static void loadAudios(ContentManager content)
        {
            inGameAudio = content.Load<Song>("Audio/Music/InGameMusic");
            mainMenuAudio = content.Load<Song>("Audio/Music/MainMenuMusic");
            diceClickAudio = content.Load<SoundEffect>("Audio/Effects/DiceClick");
            buttonClickAudio = content.Load<SoundEffect>("Audio/Effects/ButtonClick");
        }

        public static void loadFonts(ContentManager content)
        {
            arialFont = content.Load<SpriteFont>("Font/Arial");
            pressStartFont = content.Load<SpriteFont>("Font/PressStart");
        }

    }
}