using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EvenAndAudioPart1.Model;
using EvenAndAudioPart1.View;
using Microsoft.Xna.Framework.Audio;

namespace EvenAndAudioPart1.Controller
{
    class MasterController : Game
    {
         GraphicsDeviceManager graphics;
         SpriteBatch spriteBatch;
         GameController m_gameController;
         BallView m_ballView;
         BallSimulation m_ballSumlation;
        
         

        public MasterController()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 512;
            IsMouseVisible = true;
      
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

            // TODO: use this.Content to load your game content heres
            m_ballSumlation = new BallSimulation();
            m_ballView = new BallView(GraphicsDevice, Content);
            m_gameController = new GameController(GraphicsDevice, Content,m_ballSumlation);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            m_gameController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            m_ballSumlation.Update(gameTime);
           // m_ballView.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
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
             m_gameController.Draw(spriteBatch);

            foreach (BallModel ballModel in m_ballSumlation.getBalls())
            {
                m_ballView.drawBall(ballModel.XPosition,ballModel.YPosition,ballModel.diameter,ballModel.isDead);
            }
            m_ballView.drawFramWall(GraphicsDevice);
            base.Draw(gameTime);
        }

    }
}
