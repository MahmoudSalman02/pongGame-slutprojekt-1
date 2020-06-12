using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pongGame.Classes
{
    class ClassBall : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D pixel;
        Random random;


        int ballSize;

        public int speed { get; set; } = 1; 
        public bool gameRun { get; set; }
        public int dirX { get; set; }
        public int dirY { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public ClassBall(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int ballSize) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.ballSize = ballSize;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            random = new Random();

        }
        public void RD()
        {
            do
            {
                dirX = random.Next(-10, 10);
            } while (dirX == 0);

            do
            {
                dirY = random.Next(-10, 10);
            } while (dirY == 0);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(pixel, new Rectangle(posX, posY, ballSize, ballSize), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void Reetball()
        {
            posX = graphics.Viewport.Width / 2 - ballSize / 2;
            posY = graphics.Viewport.Height / 2 - ballSize / 2;
            RD();
        }
        public void ChWCo()
        {
            if (posY <=0 || posY + ballSize > graphics.Viewport.Height)
            {
                dirY = -dirY; 
            }
        }

        public override void Update(GameTime gameTime)
        {

                posX += dirX * speed;
                posY += dirY * speed;

                ChWCo();
      
            base.Update(gameTime);
        }
    }
}
