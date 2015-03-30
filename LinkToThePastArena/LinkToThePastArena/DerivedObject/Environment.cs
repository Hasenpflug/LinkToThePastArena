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
using GameFramework2D;


namespace LinkToThePastArena.DerivedObject
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Environment : Actor
    {
        protected Texture2D[] textures;
        protected byte frameIndex;

        public Environment(Game game, SpriteBatch spriteBatch, Texture2D tex, Texture2D[] textures, Vector2 position, Vector2 origin)
            : base(game, spriteBatch, tex, position, origin)
        {
            // TODO: Construct any child components here
            this.textures = textures;
        }

        public Environment(Game game, SpriteBatch spriteBatch, Texture2D tex, Texture2D[] textures, Vector2 position, Vector2 origin,
        float rotationFactor, float rotation, float scaleFactor, float scale, string state, string animationName)
            : base(game, spriteBatch, tex, position, origin, rotationFactor, rotation, scaleFactor, scale, state, animationName)
        {
            this.textures = textures;
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            tex = this.GetSingleTextureFromArray(Shared.AllAnimations[animationName].frames[frameIndex].frameSpritesheet, textures);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, new Rectangle(0, 0, tex.Width, tex.Height),
            Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
