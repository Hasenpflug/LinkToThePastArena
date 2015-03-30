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
using GameFramework2D.BaseObjects;


namespace LinkToThePastArena.DerivedObject
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GreenKnight : Character
    {
        protected Texture2D[] textures;
        protected bool isInBlockAnimation;
        protected const byte MAX_FRAME_DELAY = 5;       

        public GreenKnight(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 origin, float rotationFactor, float rotation,
        float scaleFactor, float scale, string state, string animationName)
            : base(game, spriteBatch, tex, position, origin, rotationFactor, rotation, scaleFactor, scale, state, animationName)
        {
            // TODO: Construct any child components here
            this.frameIndex = 1;
            this.frameDelay = 1;
            this.currentHealth = 1;
            this.maxHealth = 1;
        }

        public GreenKnight(Game game, SpriteBatch spriteBatch, Texture2D tex, Texture2D[] textures, Vector2 position, Vector2 origin, float rotationFactor, float rotation,
        float scaleFactor, float scale, string state, string animationName)
            : base(game, spriteBatch, tex, position, origin, rotationFactor, rotation, scaleFactor, scale, state, animationName)
        {
            // TODO: Construct any child components here
            this.textures = textures;
            this.frameIndex = 1;
            this.frameDelay = 1;
            this.currentHealth = 1;
            this.maxHealth = 1;
        }

        public GreenKnight(Game game, SpriteBatch spriteBatch, Texture2D tex, Texture2D[] textures, Vector2 position, Vector2 origin, float rotationFactor, float rotation,
        float scaleFactor, float scale, short currentHealth, short maxHealth, Vector2 velocityFactor, float velocity, string state, string animationName)
            : base(game, spriteBatch, tex, position, origin, rotationFactor, rotation, scaleFactor, scale, currentHealth, maxHealth, velocityFactor, velocity, state, animationName)
        {
            // TODO: Construct any child components here
            this.textures = textures;
            this.frameIndex = 1;
            this.frameDelay = 1;
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override Rectangle GetMask()
        {
            return new Rectangle((int)position.X - (int)origin.X, (int)position.Y - (int)origin.Y, Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth,
            Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
            animationName = "GreenKnight_Walking_Down";
            state = "Walking_Down";
            if (frameIndex >= stateFrameCount)
            {
                frameIndex = 1;
            }
            if (frameDelay > MAX_FRAME_DELAY)
            {
                frameIndex++;
                frameDelay = 0;
            }
            frameDelay++;
            tex = this.GetSingleTextureFromArray(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameSpritesheet, textures);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, new Rectangle(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameXLocation,
            Shared.AllAnimations[animationName].frames[frameIndex - 1].frameYLocation, Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth,
            Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight), Color.White, rotation, origin, scale * Shared.GlobalSpriteScaleFactor, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
