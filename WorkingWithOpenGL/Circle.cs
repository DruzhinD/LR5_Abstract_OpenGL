using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace WorkingWithOpenGL
{
    internal class Circle : Figure
    {
        float R;

        public Circle(float x, float y, float R, Vector3 color) 
            : base(new Vector2(x, y), color)
        {
            this.R = R;
        }

        //конструктор для заливки круга градиентом
        public Circle(float x, float y, float R, List<Vector3> colors)
            : base(new Vector2(x, y), colors)
        {
            this.R = R;
        }

        public override void Draw()
        {
            //DrawingExamples.DrawPolygon(Position, 40, R, color);
            DrawPolygon(Position, 40, R, color, colors);
        }

        public override bool IsPointIn(Vector2 test)
        {
            return Math.Pow(test.X - Position.X, 2) + 
                Math.Pow(test.Y - Position.Y, 2) < R*R;
        }

        private void DrawPolygon(Vector2 center, int N, double R,
            Vector3 color, List<Vector3>? colors=null)
        {
            GL.Color3(color);

            GL.Begin(PrimitiveType.Polygon);

            int idColor = 0;
            for (int i = 0; i < N; i++)
            {
                if (colors != null && i % 20 == 0)
                {
                    GL.Color3(colors[idColor]);
                    idColor++;
                } 
                GL.Vertex2(
                    new Vector2(
                        (float)(center.X + R * Math.Cos(i * 2 * Math.PI / N)),
                        (float)(center.Y + R * Math.Sin(i * 2 * Math.PI / N))
                        )
                    );
            }

            GL.End();
        }
    }
}
