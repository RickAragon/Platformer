using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Managers
{
    class DrawableAnimationManager : AnimationManager
    {
        public Texture2D AnimationSprite { get; protected set; }
        public Point UnitSize { get; protected set; }
        public DrawableAnimationManager(Texture2D sprite, Point unitSize) : base()
        {
            AnimationSprite = sprite;
            UnitSize = unitSize;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle textureScreenBounds)
        {
            if (activeAnimation == null) return;
            spriteBatch.Draw(AnimationSprite, textureScreenBounds, 
                new Rectangle(activeAnimation.AnimationState * UnitSize, UnitSize), Color.White);
        }
    }
}
