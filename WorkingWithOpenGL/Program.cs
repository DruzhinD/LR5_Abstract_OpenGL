using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace WorkingWithOpenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameWindowSettings gameSettings = GameWindowSettings.Default;
            NativeWindowSettings nativeSettings = new NativeWindowSettings()
            {
                Title = "Работа с OpenGL",
                Size = (1800, 1800),
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,
            };

            Game game = new(gameSettings, nativeSettings);
            game.Run();
        }
    }
}