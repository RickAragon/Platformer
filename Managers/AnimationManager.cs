using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Platformer.Actors;
using Platformer.Utils;

namespace Platformer.Managers
{
    public class AnimationManager
    {
        protected Dictionary<string, Animation> animations;
        protected Animation activeAnimation;

        public Animation ActiveAnimation
        {
            get
            {
                return activeAnimation;
            }
        }
        public AnimationManager()
        {
            animations = new Dictionary<string, Animation>();
        }

        public void AddAnimation(string name, Animation animation)
        {
            animations.Add(name, animation);
            if (activeAnimation == null) activeAnimation = animation;
        }

        public void AddAnimation(string name, Point animationStart, Point animationBounds)
        {
            animations.Add(name, new Animation(animationStart, animationBounds));
        }

        public void AddAnimation(string name, int animStartX, int animStartY, int animBoundX, int animBoundY)
        {
            animations.Add(name, new Animation(new Point(animStartX, animStartY), new Point(animBoundX, animBoundY)));
        }

        public void ChangeAnimation(string name)
        {
            activeAnimation?.ResetState();
            if(animations.ContainsKey(name))
            {
                activeAnimation = animations[name];
            }
        }

        public void Update(GameTime gameTime)
        {
            activeAnimation?.Update(gameTime);
        }
    }
}
