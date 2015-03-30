using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameFramework2D.IO;

namespace LinkToThePastArena
{
    class Shared
    {
        public static Vector2 stage;
        public static Dictionary<string, SpriteAnimation> AllAnimations = new Dictionary<string, SpriteAnimation>();
        public const float GlobalSpriteScaleFactor = 1.5f;
    }
}
