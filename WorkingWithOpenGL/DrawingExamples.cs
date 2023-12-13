using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Mathematics;

namespace WorkingWithOpenGL
{
    internal static class DrawingExamples
    {
        /// <summary>отрисовка с лабораторной работы</summary>
        internal static void LabExample()
        {
            GL.Begin(PrimitiveType.LineStrip);

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex2(0.5f, 0.5f);

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();
        }

        internal static void DrawExample1()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Khaki);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(Color.Khaki);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.LightSeaGreen);
            GL.Vertex2(0.5f, 0.5f);
            GL.Color3(Color.LightSeaGreen);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();
        }

        internal static void DrawExample2()
        {
            //рисует только в 2 измерениях, а не в трех
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.PaleGoldenrod);
            GL.Vertex3(-0.5f, -0.5f, 0.2f);
            GL.Color3(Color.Green);
            GL.Vertex3(-0.5f, 0.5f, 0.2f);
            GL.Color3(Color.Maroon);
            GL.Vertex3(0.5f, 0.5f, 0.2f);
            GL.Color3(Color.Magenta);
            GL.Vertex3(0.5f, -0.5f, 0.2f);

            GL.End();
        }

        /// <summary>
        /// отрисовка правильного многоугольника
        /// </summary>
        /// <param name="center">центр фигуры</param>
        /// <param name="N">количество вершин многоугольника</param>
        /// <param name="radius">ридус описанной окружности</param>
        /// <param name="color">цвет фигуры</param>
        internal static void DrawPolygon(Vector2 center = default(Vector2),
            int N = 8, float radius = 0.5f, Vector3 color = default)
        {
            //значение по умолчанию для координат центра фигуры
            if (object.Equals(center, default(Vector2)))
                center = new Vector2(0.0f, 0.0f);

            //значение по умолчанию для вектора цвета
            if (object.Equals(color, default(Vector3)))
                color = new Vector3(1.0f, 0.57f, 0.0f);

            Vector2[] vertexes = new Vector2[N];
            for (int i = 0; i < N; i++)
            {
                vertexes[i] = new Vector2(
                    (float)(center.X + radius * Math.Cos(i * 2 * Math.PI / N)),
                    (float)(center.Y + radius * Math.Sin(i * 2 * Math.PI / N)));
            }

            //непосредственно отрисовка фигуры
            GL.Begin(PrimitiveType.Polygon);
            for (int i = 0; i < vertexes.Length; i++)
            {
                GL.Color3(color);
                GL.Vertex2(vertexes[i]);

            }
            GL.End();
        }
    }
}
