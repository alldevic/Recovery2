using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridExtensions
{
    public class CustomShortcutKeysEditor : ShortcutKeysEditor
    {
        public CustomShortcutKeysEditor()
        {
            var validKeys = new[]
            {
                Keys.A,
                Keys.B,
                Keys.C,
                Keys.D,
                Keys.D0,
                Keys.D1,
                Keys.D2,
                Keys.D3,
                Keys.D4,
                Keys.D5,
                Keys.D6,
                Keys.D7,
                Keys.D8,
                Keys.D9,
                Keys.Delete,
                Keys.Down,
                Keys.E,
                Keys.End,
                Keys.Enter,
                Keys.Escape,
                Keys.F,
                Keys.F1,
                Keys.F10,
                Keys.F11,
                Keys.F12,
                Keys.F2,
                Keys.F3,
                Keys.F4,
                Keys.F5,
                Keys.F6,
                Keys.F7,
                Keys.F8,
                Keys.F9,
                Keys.G,
                Keys.H,
                Keys.I,
                Keys.Insert,
                Keys.J,
                Keys.K,
                Keys.L,
                Keys.Left,
                Keys.M,
                Keys.N,
                Keys.NumLock,
                Keys.NumPad0,
                Keys.NumPad1,
                Keys.NumPad2,
                Keys.NumPad3,
                Keys.NumPad4,
                Keys.NumPad5,
                Keys.NumPad6,
                Keys.NumPad7,
                Keys.NumPad8,
                Keys.NumPad9,
                Keys.O,
                Keys.P,
                Keys.Pause,
                Keys.Q,
                Keys.R,
                Keys.Right,
                Keys.S,
                Keys.Space,
                Keys.T,
                Keys.Tab,
                Keys.U,
                Keys.Up,
                Keys.V,
                Keys.W,
                Keys.X,
                Keys.Y,
                Keys.Z
            };

            var validKeysField = typeof(ShortcutKeysEditor)
                .GetField("shortcutKeysUI", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.FieldType
                .GetField("validKeys", BindingFlags.NonPublic | BindingFlags.Static);

            validKeysField?.SetValue(validKeysField, validKeys);
        }
    }
}