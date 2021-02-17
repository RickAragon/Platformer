using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Platformer.Actors;
using Platformer.Managers;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameClass : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private PlayerActor player;
        private InputManager inputManager;

        private RenderTarget2D renderTarget;
        
        public GameClass()
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
            renderTarget = new RenderTarget2D(GraphicsDevice, 800, 450);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 450;
            graphics.ApplyChanges();
            inputManager = InputManager.GetInstance();
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
            player = new PlayerActor(Content.Load<Texture2D>("Textures/mario"), new Point(16, 16), new Point(2,1));
            player.AddAnimation("IDLE", new Utils.Animation(Point.Zero, new Point(1, 1)));
            player.AddAnimation("WALK", new Utils.Animation(new Point(1, 0), new Point(4, 1), 250));
            player.AddAnimation("RUN", new Utils.Animation(new Point(1, 0), new Point(4, 1), 120));
            player.AddAnimation("JUMP", new Utils.Animation(new Point(5, 0), new Point(6, 1)));
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

            inputManager.Update(gameTime);
            player.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, 600, 600), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
