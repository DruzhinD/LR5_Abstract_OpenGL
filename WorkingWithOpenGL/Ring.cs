using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace WorkingWithOpenGL
{
    internal class Ring : Figure
    {
        float R, r;

        public Ring(float x, float y, float R, float r, Vector3 color)
            : base(new Vector2(x, y), color)
        {
            this.R = R;
            this.r = r;
        }

        //конструктор для кольца с градиентом
        public Ring(float x, float y, float R, float r, List<Vector3> colors)
            : base(new Vector2(x, y), colors)
        {
            this.R = R;
            this.r = r;
        }

        public override void Draw()
        {
            //DrawingExamples.DrawPolygon(Position, 40, R, color);
            DrawPolygon(Position, 40, R, r, color, colors);
        }

        private void DrawPolygon(Vector2 center, int N, double R, double r,
            Vector3 color, List<Vector3>? colors = null)
        {
            GL.Color3(color);

            GL.Begin(PrimitiveType.TriangleStrip);

            for (int i = 0; i < N + 1; i++)
            {
                //если был передан один цвет, а не список цветов
                if (colors.Count >= 2) GL.Color3(colors[0]);
                GL.Vertex2(
                    new Vector2(
                        (float)(center.X + R * Math.Cos(i * 2 * Math.PI / N)),
                        (float)(center.Y + R * Math.Sin(i * 2 * Math.PI / N))
                        )
                    );

                if (colors.Count >= 2) GL.Color3(colors[1]);
                GL.Vertex2(
                    new Vector2(
                        (float)(center.X + r * Math.Cos(i * 2 * Math.PI / N)),
                        (float)(center.Y + r * Math.Sin(i * 2 * Math.PI / N))
                        )
                    );
            }

            GL.End();
        }

        public override bool IsPointIn(Vector2 test)
        {
            bool bigCircle = Math.Pow(test.X - Position.X, 2) +
                Math.Pow(test.Y - Position.Y, 2) < R * R;

            bool smallCircle = Math.Pow(test.X - Position.X, 2) +
                Math.Pow(test.Y - Position.Y, 2) > r * r;

            return bigCircle && smallCircle;
        }
    }
}
