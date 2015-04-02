using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameFramework2D;
using System.Configuration;
using GameFramework2D.IO;
using LinkToThePastArena.Scenes;

namespace LinkToThePastArena
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ActionSceneArena actionSceneArena;
        Texture2D[] actionSceneArenaTextures;
                       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Shared.AllAnimations = FileIO.LoadAllAnimations();
            graphics.PreferredBackBufferWidth = Convert.ToInt16(Shared.AllAnimations["Background_Arena"].frames[0].frameWidth);
            graphics.PreferredBackBufferHeight = Convert.ToInt16(Shared.AllAnimations["Background_Arena"].frames[0].frameHeight);
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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
            
            // Instantiate all scenes and add them to the game
            actionSceneArenaTextures = new Texture2D[10];
            actionSceneArenaTextures[0] = Content.Load<Texture2D>("LinkSpriteSheet1");
            actionSceneArenaTextures[0].Name = "LinkSpriteSheet1";
            actionSceneArenaTextures[1] = Content.Load<Texture2D>("LinkSpriteSheet2");
            actionSceneArenaTextures[1].Name = "LinkSpriteSheet2";
            actionSceneArenaTextures[2] = Content.Load<Texture2D>("LinkSpriteSheet3");
            actionSceneArenaTextures[2].Name = "LinkSpriteSheet3";
            actionSceneArenaTextures[3] = Content.Load<Texture2D>("LinkSpriteSheet4");
            actionSceneArenaTextures[3].Name = "LinkSpriteSheet4";
            actionSceneArenaTextures[4] = Content.Load<Texture2D>("LargeOpenGrassArea");
            actionSceneArenaTextures[4].Name = "LargeOpenGrassArea";
            actionSceneArenaTextures[5] = Content.Load<Texture2D>("EnemiesSpriteSheet1");
            actionSceneArenaTextures[5].Name = "EnemiesSpriteSheet1";
            actionSceneArena = new ActionSceneArena(this, actionSceneArenaTextures);
            this.Components.Add(actionSceneArena);
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
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (DrawableGameComponent component in this.Components)
            {
                if (component.Visible)
                {
                    component.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }
    }
}
