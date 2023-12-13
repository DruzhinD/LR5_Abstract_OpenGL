using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace WorkingWithOpenGL
{
    internal class Rect : Figure
    {
        float width, height;

        public Rect(float x, float y, float width, float height, Vector3 color)
            : base(new Vector2(x, y), color)
        {
            this.width = width;
            this.height = height;
        }

        //конструктор для создания прямоугольник, залитого градиентом
        public Rect(float x, float y, float width, float height, List<Vector3> colors)
            : base(new Vector2(x, y), colors)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            GL.Color3(color);

            GL.Begin(PrimitiveType.Polygon);

            if (colors != null)
                GL.Color3(colors[0]);
            GL.Vertex2(Position.X - width / 2, Position.Y - height / 2);
            if (colors != null)
                GL.Color3(colors[1]);
            GL.Vertex2(Position.X + width / 2, Position.Y - height / 2);
            if (colors != null)
                GL.Color3(colors[2]);
            GL.Vertex2(Position.X + width / 2, Position.Y + height / 2);
            if (colors != null)
                GL.Color3(colors[3]);
            GL.Vertex2(Position.X - width / 2, Position.Y + height / 2);

            GL.End();
        }

        public override bool IsPointIn(Vector2 test)
        {
            return (
                Position.X - width / 2 < test.X && test.X < Position.X + width / 2 &&
                Position.Y - height / 2 < test.Y && test.Y < Position.Y + height / 2 );
        }
    }
}
