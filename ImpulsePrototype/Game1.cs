using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpulsePrototype
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		Texture2D ballTexture;
		Vector2 ballPos = new Vector2(400, 200);
		Sprite ball = null;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here
			
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			ballTexture = Content.Load<Texture2D>(@"Master_Ball_Sprite");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here


			if (ball == null) {
				ball = new Sprite(ballTexture, ballPos, 80f);
			}
			else {
				GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
				Vector2 inputVelocity = new Vector2(gamePadState.ThumbSticks.Left.X, -gamePadState.ThumbSticks.Left.Y);

				float elapsedT = (float)gameTime.ElapsedGameTime.TotalSeconds;

				ball.update(inputVelocity, elapsedT, 0.85f);
			}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
			
			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(ballTexture, ball.Location, Color.White);
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
