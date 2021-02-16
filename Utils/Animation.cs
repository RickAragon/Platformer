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
        public long acumulatedFrames = 0;

        public Animation(Point animationStart, Point animationBounds, int step = 200)
        {
            this.animationStart = animationStart;
            this.animationState = animationStart;
            this.animationBounds = animationBounds;
            Step = step;
        }

        public void ResetState()
        {
            this.animationState = animationStart;
        }
        public void Update(GameTime gameTime)
        {
            if(acumulatedFrames > Step)
            {
                acumulatedFrames = 0;
                if(animationState.X + 1 >= animationBounds.X)
                {
                    animationState.X = animationStart.X;
                    if(animationState.Y + 1 >= animationBounds.Y)
                    {
                        animationState.Y = animationStart.Y;
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
                acumulatedFrames += gameTime.ElapsedGameTime.Milliseconds;
            }
        }
    }
}
