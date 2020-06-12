using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using pongGame.Classes;
using System.Text;
using Microsoft.Xna.Framework.Content; 

namespace pongGame
{

    public class PongGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont scorefont;
        ClassBall ball;
        ClassRacket player1;
        ClassRacket player2;

        int score1 = 0;
        int score2 = 0;
        int racketW = 10;
        int racketH = 75;
        int ballSize = 10;
        public PongGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() { 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            scorefont = Content.Load<SpriteFont>("scorefont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new ClassBall(GraphicsDevice, spriteBatch, this, ballSize);
            
            player1 = new ClassRacket(GraphicsDevice, spriteBatch, this, racketW, racketH,10 , GraphicsDevice.Viewport.Height  / 2 - racketH / 2);
            player2=  new ClassRacket(GraphicsDevice, spriteBatch, this, racketW, racketH, GraphicsDevice.Viewport.Width -racketH, GraphicsDevice.Viewport.Height / 2 - racketH / 2);

            Components.Add(player1);
            Components.Add(player2);
            Components.Add(ball);

            ball.Reetball();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && !ball.gameRun)
            {
                ball.gameRun = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R) && ball.gameRun)
            {
                ball.gameRun = false;
                ball.Reetball();
            }
            player1.posY = Mouse.GetState().Y;
            player2.posY = Mouse.GetState().Y;

            //bollen går till spelare nm2
            if (ball.dirX > 0)
            {
                if (ball.posY >= player2.posY && ball.posY + ballSize < player2.posY + racketH && ball.posX + ballSize >= player2.posX )
                {
                    ball.dirX = -ball.dirX;
                }
                else if (ball.posX >= GraphicsDevice.Viewport.Width - ballSize)
                {
                    score1++;
                    ball.gameRun = false;
                    ball.Reetball();
                }
            }
            //bollen går till spelare nm1
            else if (ball.dirX < 0)
            { 
                if (ball.posY >= player1.posY && ball.posY+ ballSize <= player1.posY + racketH && ball.posX <= player1.posX +racketW)
                {
                    ball.dirX = -ball.dirX;
                }
                else if (ball.posX <= 0)
                {
                    score2++;
                    ball.gameRun = false;
                    ball.Reetball();
                }
              
               
            }

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(scorefont,score1.ToString(), new Vector2(50,50),Color.White);
            spriteBatch.DrawString(scorefont,score2.ToString(), new Vector2(GraphicsDevice.Viewport.Width -250, 50), Color.White);
            spriteBatch.End();
           

            base.Draw(gameTime);
        }
    }
}
