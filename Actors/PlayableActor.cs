using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Platformer.Managers;
using Platformer.Utils;

namespace Platformer.Actors
{
    class PlayableActor: BaseActor
    {
        private InputManager inputManager;
        private DrawableAnimationManager animationManager;
        public PlayableActor(Texture2D texture, Point innerSize, Point sizeMultiplier) : base(texture, innerSize, sizeMultiplier)
        {
            inputManager = InputManager.GetInstance();
            animationManager = new DrawableAnimationManager(texture, innerSize);
        }

        public void AddAnimation(string key, Animation animation)
        {
            animationManager.AddAnimation(key, animation);
        }

        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, new Rectangle(position, innerSize * sizeMultiplier));
        }
    }
}
