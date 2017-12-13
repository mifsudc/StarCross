using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Custom
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GM gm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = Constant.screenWidth;
            graphics.PreferredBackBufferHeight = Constant.screenHeight;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            gm = new GM();
            IsMouseVisible = true;
            Mouse.WindowHandle = Window.Handle;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.actor = Content.Load<Texture2D>("player");
            Resources.bullet = Content.Load<Texture2D>("bullet");
            Resources.particle = Content.Load<Texture2D>("particle");
            Resources.background = Content.Load<Texture2D>("background");
            Resources.galaxy = Content.Load<Texture2D>("galaxy");
            Resources.marker = Content.Load<Texture2D>("marker");
            Resources.npc = Content.Load<Texture2D>("npc");

            Resources.OStar = Content.Load<Texture2D>("OStar");
            Resources.BStar = Content.Load<Texture2D>("BStar");
            Resources.AStar = Content.Load<Texture2D>("AStar");
            Resources.FStar = Content.Load<Texture2D>("FStar");
            Resources.GStar = Content.Load<Texture2D>("GStar");
            Resources.KStar = Content.Load<Texture2D>("KStar");
            Resources.MStar = Content.Load<Texture2D>("MStar");
            Resources.BlackHole = Content.Load<Texture2D>("BlackHole");
            Resources.WhiteDwarf = Content.Load<Texture2D>("WhiteDwarf");
            Resources.Alien = Content.Load<Texture2D>("alien");
            Resources.planet = Content.Load<Texture2D>("planet");

            Resources.testFont = Content.Load<SpriteFont>("test");

            Resources.Music = Content.Load<Song>("music");
            MediaPlayer.Play(Resources.Music);
            MediaPlayer.IsRepeating = true;
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

            gm.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin();
            gm.Render(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
