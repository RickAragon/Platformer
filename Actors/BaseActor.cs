using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Actors
{
    public abstract class BaseActor
    {
        protected Point position;
        protected Point innerSize;
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
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
