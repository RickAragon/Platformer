using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Platformer.Managers
{
    public enum ControlsInput
    {
        None,
        Up,
        Down,
        Left,
        Right,
        R2,
        L2,
        R1,
        L1,
        L3,
        R3,
        LUp,
        LDown,
        LLeft,
        LRight,
        RUp,
        RDown,
        RLeft,
        RRight,
        A,
        B,
        X,
        Y
    }

    public delegate void KeyPressEvent(Keys pressedKey, ControlsInput pressedLogical);

    public class InputManager
    {
        private static InputManager INSTANCE;
        protected KeyboardState lastState;
        public Dictionary<Keys, ControlsInput> Bindings { get; protected set; }
        public event KeyPressEvent OnButtonPress;


        protected InputManager(Dictionary<Keys, ControlsInput> inputConfig = null)
        {
            lastState = Keyboard.GetState();
            if (inputConfig == null)
                Bindings = new Dictionary<Keys, ControlsInput>();
            else
                Bindings = inputConfig;
        }

        public virtual void Update(GameTime gameTime)
        {
            var currentState = Keyboard.GetState();
            foreach(var pair in Bindings)
            {
                if(currentState.IsKeyDown(pair.Key) && lastState.IsKeyUp(pair.Key))
                {
                    OnButtonPress?.Invoke(pair.Key, pair.Value);
                }
            }
        }

        public void SetControls(Dictionary<Keys, ControlsInput> bindings)
        {
            if (bindings == null) return;
            foreach(var pair in bindings)
            {
                if(Bindings.ContainsKey(pair.Key))
                {
                    Bindings[pair.Key] = pair.Value;
                }
                else
                {
                    Bindings.Add(pair.Key, pair.Value);
                }
            }
        }

        public static InputManager GetInstance(Dictionary<Keys, ControlsInput> inputConfig = null)
        {
            if(INSTANCE == null)
            {
                var defaultConfig = new Dictionary<Keys, ControlsInput>()
                {
                    {Keys.A, ControlsInput.LLeft },
                    {Keys.D, ControlsInput.LRight },
                    {Keys.W, ControlsInput.LUp },
                    {Keys.S, ControlsInput.LDown },
                    {Keys.Left, ControlsInput.Left },
                    {Keys.Up, ControlsInput.Up },
                    {Keys.Right, ControlsInput.Right },
                    {Keys.Down, ControlsInput.Down },
                    {Keys.K, ControlsInput.A },
                    {Keys.I, ControlsInput.Y },
                    {Keys.J, ControlsInput.X },
                    {Keys.L, ControlsInput.B },
                    {Keys.Q, ControlsInput.L1 },
                    {Keys.E, ControlsInput.R1 },
                    {Keys.U, ControlsInput.L2 },
                    {Keys.O, ControlsInput.R2 },
                    {Keys.V, ControlsInput.L3 },
                    {Keys.B, ControlsInput.R3 },
                };
                var inputManager = new InputManager(defaultConfig);
                INSTANCE = inputManager;
            }
            INSTANCE.SetControls(inputConfig);
            return INSTANCE;
        }
    }
}
