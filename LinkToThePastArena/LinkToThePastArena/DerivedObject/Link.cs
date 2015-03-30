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
    public class Link : Character
    {
        protected Texture2D[] textures;
        protected short currentMana;
        protected short maxMana;
        protected KeyboardState oldKeyboardState;
        protected bool isInBlockAnimation;
        protected const byte MAX_FRAME_DELAY = 3;
       
        public Link(Game game, SpriteBatch spriteBatch, Texture2D tex, Texture2D[] textures, Vector2 position, Vector2 origin,
        float rotationFactor, float rotation, float scaleFactor, float scale, string state, string animationName)
            : base(game, spriteBatch, tex, position, origin, rotationFactor, rotation, scaleFactor, scale, state, animationName)
        {
            // TODO: Construct any child components here
            this.textures = textures;
            this.currentMana = 1;
            this.maxMana = 1;
            this.state = state;
            this.frameIndex = 1;
            this.animationName = animationName;
            this.frameDelay = 1;
            this.tex = this.GetSingleTextureFromArray(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameSpritesheet, textures);
            this.isInBlockAnimation = false;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
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
            Vector2 newFramePosition;
            KeyboardState newKeyboardState = Keyboard.GetState();
            Vector2 oldFramePosition = new Vector2(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth, 
            Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight);
            if (!isInBlockAnimation)
            {
                if (newKeyboardState.IsKeyDown(Keys.W))
                {
                    animationName = "Link_GreenTunic_Shield_Walking_Up";
                    state = "Walking_Up";
                    int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
                    velocityFactor = new Vector2(0, -1);
                    velocity = 1.5f;
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
                }
                else if (newKeyboardState.IsKeyDown(Keys.A))
                {
                    animationName = "Link_GreenTunic_Shield_Walking_Right";
                    state = "Walking_Left";
                    int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
                    velocityFactor = new Vector2(-1, 0);
                    velocity = 1.5f;
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
                }
                else if (newKeyboardState.IsKeyDown(Keys.S))
                {
                    animationName = "Link_GreenTunic_Shield_Walking_Down";
                    state = "Walking_Down";
                    int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
                    velocityFactor = new Vector2(0, 1);
                    velocity = 1.5f;
                    frameDelay++;
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
                }
                else if (newKeyboardState.IsKeyDown(Keys.D))
                {
                    animationName = "Link_GreenTunic_Shield_Walking_Right";
                    state = "Walking_Right";
                    int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
                    velocityFactor = new Vector2(1, 0);
                    velocity = 1.5f;
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
                }
                else if (newKeyboardState.IsKeyDown(Keys.Space))
                {
                    if (state.IndexOf("Left") > 0)
                    {
                        animationName = "Link_GreenTunic_Sword_Slashing_Right";
                        state = "Slashing_Left";
                    }
                    else
                    {
                        animationName = "Link_GreenTunic_Sword_Slashing" + state.Substring(state.LastIndexOf('_'));
                        state = "Slashing" + state.Substring(state.LastIndexOf('_'));
                    }
                   
                    velocity = 0f;
                    velocityFactor = Vector2.Zero;
                    frameIndex = 1;
                    isInBlockAnimation = true;

                }
                else if (newKeyboardState.GetPressedKeys().Length == 0)
                {
                    if (state.IndexOf("Left") > 0)
                    {
                        animationName = "Link_GreenTunic_Shield_Standing_Right";
                        state = "Standing_Left";
                    }
                    else
                    {
                        animationName = "Link_GreenTunic_Shield_Standing" + state.Substring(state.LastIndexOf('_'));
                        state = "Standing" + state.Substring(state.LastIndexOf('_'));
                    }
                   
                    velocityFactor = new Vector2(0, 0);
                    frameIndex = 1;
                    velocity = 0;
                }
                oldKeyboardState = newKeyboardState;
                tex = this.GetSingleTextureFromArray(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameSpritesheet, textures);
            }
            else
            {
                int stateFrameCount = Shared.AllAnimations[animationName].frames.Count;
                if (frameIndex >= stateFrameCount)
                {
                    isInBlockAnimation = false;
                    frameIndex = 1;
                }
                else
                {
                    if (frameDelay > MAX_FRAME_DELAY)
                    {
                        frameIndex++;
                        frameDelay = 0;
                    }
                    frameDelay++;
                }
            }
            if (state.IndexOf("Left") > 0 || state.IndexOf("Up") > 0)
            {
                newFramePosition = new Vector2(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth,
                Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight);
                position += oldFramePosition - newFramePosition;
            }
            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (state.IndexOf("Left") > 0)
            {
                spriteBatch.Draw(tex, position, new Rectangle(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameXLocation,
                Shared.AllAnimations[animationName].frames[frameIndex - 1].frameYLocation, Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth,
                Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight), Color.White, rotation, origin, scale * Shared.GlobalSpriteScaleFactor, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(tex, position, new Rectangle(Shared.AllAnimations[animationName].frames[frameIndex - 1].frameXLocation,
                Shared.AllAnimations[animationName].frames[frameIndex - 1].frameYLocation, Shared.AllAnimations[animationName].frames[frameIndex - 1].frameWidth,
                Shared.AllAnimations[animationName].frames[frameIndex - 1].frameHeight), Color.White, rotation, origin, scale * Shared.GlobalSpriteScaleFactor, SpriteEffects.None, 0f);
            }
            spriteBatch.End();
        }
    }
}
