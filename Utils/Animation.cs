using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Utils
{
    public class Animation
    {
        protected Point animationStart;
        protected Point animationBounds;
        protected Point animationState;

        public Point AnimationState
        {
            get
            {
                return animationState;
            }
        }

        public int Step { get; set; }

        public Animation(Point animationStart, Point animationBounds, int step = 1)
        {
            this.animationStart = animationStart;
            this.animationBounds = animationBounds;
        }

        public void ResetState()
        {
            this.animationState = animationStart;
        }
        public void Update(GameTime gameTime)
        {
            if(Step > gameTime.ElapsedGameTime.TotalMilliseconds)
            {
                Step = 0;
                if(animationState.X + 1 >= animationBounds.X)
                {
                    animationState.X = 0;
                    if(animationState.Y + 1 >= animationBounds.Y)
                    {
                        animationState.Y = 0;
                    }
                    else
                    {
                        animationState.Y++;
                    }
                }
                else
                {
                    animationState.X++;
                }
            }
            else
            {
                Step += gameTime.ElapsedGameTime.Milliseconds;
            }
        }
    }
}
