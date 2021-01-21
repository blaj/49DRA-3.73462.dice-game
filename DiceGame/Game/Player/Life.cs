using System.Collections.Generic;
using System.IO;
using System.Threading;
using DiceGame.Engine;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Life: GameElement
    { 
        public Texture2D texture { get; set; }
        public Vector2i position { get; set; }

        public Life()
        {
            this.texture = AssetManager.lifeTexture;
            this.position = new Vector2i();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(position.x, position.y, 32, 32), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            this.position = position;
        }
    }
}