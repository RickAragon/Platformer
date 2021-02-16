using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Actors
{
    public abstract class BaseActor
    {
        protected Point position;
        protected Point innerSize;
        protected Point sizeMultiplier;
        protected Texture2D texture;
        private Rectangle virtualBounds;
        public Rectangle VirtualBounds
        {
            get
            {
                return virtualBounds;
            }
        }
        public BaseActor(Texture2D texture, Point innerSize)
        {
            this.innerSize = innerSize;
            this.texture = texture;
            virtualBounds = new Rectangle(position, innerSize);
        }

        public BaseActor(Texture2D texture, Point innerSize, Point sizeMultiplier)
            :this(texture, innerSize)
        {
            if (sizeMultiplier.X == 0) sizeMultiplier.X = 1;
            if (sizeMultiplier.Y == 0) sizeMultiplier.Y = 1;
            this.sizeMultiplier = sizeMultiplier;

        }
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
