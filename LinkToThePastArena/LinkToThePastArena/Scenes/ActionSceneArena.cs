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
using GameFramework2D.BaseObjects;
using LinkToThePastArena.DerivedObject;
using GameFramework2D.IO;

namespace LinkToThePastArena.Scenes
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ActionSceneArena : GameScene
    {
        protected SpriteBatch spriteBatch;
        protected Link link;
        protected Texture2D[] sceneTextures;
        protected GreenKnight testKnight;
        protected DerivedObject.Environment background;
        protected DerivedObject.Wall arenaWall;
                     
        public ActionSceneArena(Game game, Texture2D[] sceneTextures)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = new SpriteBatch(game.GraphicsDevice);
            this.sceneTextures = sceneTextures;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            background = new DerivedObject.Environment(Game, spriteBatch, null, new Texture2D[] { sceneTextures[4] }, Vector2.Zero,
            Vector2.Zero, 0f, 0f, 0f, 1f, "", "Background_Arena");
            foreach (AnimationFrame frame in Shared.AllAnimations["Arena_Walls"].frames)
            {
                arenaWall = new Wall(Game, new Vector2(frame.frameXLocation, frame.frameYLocation), Vector2.Zero, frame.frameWidth, frame.frameHeight);
                Components.Add(arenaWall);
            }
            link = new Link(Game, spriteBatch, null, new Texture2D[] { sceneTextures[0], sceneTextures[1], sceneTextures[2], sceneTextures[3]},
            new Vector2(Shared.stage.X / 2 + 20, Shared.stage.Y / 2 + 20), new Vector2(Shared.AllAnimations["Link_GreenTunic_NoShield_Walking_Down"].frames[0].frameWidth / 2,
            Shared.AllAnimations["Link_GreenTunic_Shield_Walking_Down"].frames[0].frameHeight / 2), 0f, 0f, 0f, 1f, "Walking_Down", "Link_GreenTunic_NoShield_Walking_Down");
            testKnight = new GreenKnight(Game, spriteBatch, null, new Texture2D[] { sceneTextures[5] }, 
            new Vector2(Shared.stage.X / 2 + 40, Shared.stage.Y / 2 + 40), Vector2.Zero, 0f, 0f, 0f, 1f, "Walking_Down", "GreenKnight_Walking_Down");
            Components.Add(background);
            Components.Add(link);
            Components.Add(testKnight);
            Show();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            foreach (DrawableGameComponent component in Components)
	        {
                if (component is Wall)
                {
                    Wall wall = (Wall)component;
                    if (link.GetMask().Intersects(wall.GetMask()))
                    {
                        // link.Stop();
                        link.Push(new Vector2(link.GetMask().Width - (wall.GetMask().X - link.GetMask().X), link.GetMask().Height - (wall.GetMask().Y - link.GetMask().Y)));  
                    }
                }
	        }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
