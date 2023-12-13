using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace WorkingWithOpenGL
{
    internal class Game : GameWindow
    {
        List<Figure> visualObjects = new List<Figure>();

        /// <summary>список цветов</summary>
        List<Vector3> colors = new();

        /// <summary>объект, на котором была нажата кнопка мышки</summary>
        Figure? choosenFigure = null;

        public Game(GameWindowSettings gameSettings, NativeWindowSettings nativeSettings)
            : base(gameSettings, nativeSettings)
        {
            //генерация цветов
            MakeColors();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
                Close();
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.5f, 0.4f, 0.7f, 1.0f);

            visualObjects.Add(new Rect(-0.5f, -0.5f, 0.4f, 0.25f, colors.GetRange(0, 4)));
            visualObjects.Add(new Rect(-0.5f, 0.0f, 0.4f, 0.3f, colors.GetRange(4, 4)));
            visualObjects.Add(new Rect(-0.5f, 0.5f, 0.3f, 0.35f, colors.GetRange(8, 4)));

            visualObjects.Add(new Circle(0.5f, -0.5f, 0.15f, colors.GetRange(12, 2)));
            visualObjects.Add(new Circle(0.5f, 0.0f, 0.2f, colors.GetRange(14, 2)));
            visualObjects.Add(new Circle(0.5f, 0.5f, 0.25f, colors.GetRange(16, 2)));

            visualObjects.Add(new Triangle(-0.5f, 0.5f, 0.2f, colors.GetRange(18, 3)));
            visualObjects.Add(new Triangle(0.0f, 0.5f, 0.25f, colors.GetRange(21, 3)));
            visualObjects.Add(new Triangle(0.5f, 0.5f, 0.3f, colors.GetRange(24, 3)));

            visualObjects.Add(new Ring(-0.5f, -0.5f, 0.2f, 0.1f, colors.GetRange(27, 2)));
            visualObjects.Add(new Ring(0.0f, -0.5f, 0.25f, 0.2f, colors.GetRange(29, 2)));
            visualObjects.Add(new Ring(0.5f, -0.5f, 0.3f, 0.28f, colors.GetRange(31, 2)));
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            for (int i = 0; i < visualObjects.Count; i++)
            {
                visualObjects[i].Draw();
            }

            //DrawingExamples.DrawPolygon(N: 10, color: new Vector3(0.1f, 0.4f, 0.7f));

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        private Vector2 cursorPosition = new();
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            cursorPosition.X = 2 * e.Position.X / ClientSize.X - 1.0f;
            cursorPosition.Y = -(2 * e.Position.Y / ClientSize.Y - 1.0f);

            //перетаскивание фигуры вслед за курсором
            if (choosenFigure != null)
            {
                choosenFigure.Position = cursorPosition;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            for (int i = visualObjects.Count - 1; i >= 0 ; i--)
            {
                if (visualObjects[i].IsPointIn(cursorPosition))
                {
                    choosenFigure = visualObjects[i];
                    choosenFigure.Touch(cursorPosition);

                    visualObjects.Remove(choosenFigure);
                    visualObjects.Add(choosenFigure);
                    break;
                }
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (choosenFigure != null )
            {
                choosenFigure = null;
            }
        }

        /// <summary>
        /// генератор цветов,
        /// хранящихся в списке colors
        /// </summary>
        public void MakeColors()
        {
            Random rnd = new();
            for (int i = 0; i < 34; i++)
            {
                colors.Add(new Vector3(
                    rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle())
                    );
            }
        }
    }

}
