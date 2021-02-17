using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using Platformer.Managers;
using Platformer.Utils;

namespace Platformer.Actors
{
    class PlayerActor: BaseActor
    {
        private InputManager inputManager;
        private DrawableAnimationManager animationManager;

        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public int Rapidez { get; set; } = 2;
        public PlayerActor(Texture2D texture, Point innerSize, Point sizeMultiplier) : base(texture, innerSize, sizeMultiplier)
        {
            inputManager = InputManager.GetInstance();
            animationManager = new DrawableAnimationManager(texture, innerSize);
            inputManager.OnButtonPress += (pressedKey, controlInput) =>
            {
                switch(controlInput)
                {
                    case ControlsInput.Down:
                        position.Y += Rapidez;
                        break;
                    case ControlsInput.Up:
                        position.Y -= Rapidez;
                        break;
                    case ControlsInput.Left:
                        position.X -= Rapidez;
                        break;
                    case ControlsInput.Right:
                        position.X += Rapidez;
                        break;
                    case ControlsInput.A:
                        break;
                    case ControlsInput.X:
                        break;
                    case ControlsInput.B:
                        break;
                    case ControlsInput.Y:
                        break;
                }
            };
        }

        public override void Initialize()
        {
            // Codigo de inicializacion aca
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
