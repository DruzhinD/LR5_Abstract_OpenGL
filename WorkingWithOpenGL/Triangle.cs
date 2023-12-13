using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace WorkingWithOpenGL
{
    internal class Triangle : Figure
    {
        /// <summary>длина стороны треугольника</summary>
        float length;

        /// <summary>координаты вершин треугольника</summary>
        Vector2[] vertexes;
        
        public Triangle(float x, float y, float length, Vector3 color)
            : base(new Vector2(x, y), color)
        {
            this.length = length;
        }

        //конструктор для создания треугольника, залитого градиентом
        public Triangle(float x, float y, float length, List<Vector3> colors)
            : base(new Vector2(x, y), colors)
        {
            this.length = length;
        }

        public override void Draw()
        {
            GenVertexes();

            GL.Color3(color);

            GL.Begin(PrimitiveType.Triangles);

            if (colors != null) GL.Color3(colors[0]);
            GL.Vertex2(vertexes[0]); //точка A

            if (colors != null) GL.Color3(colors[1]);
            GL.Vertex2(vertexes[1]); //B

            if (colors != null) GL.Color3(colors[2]);
            GL.Vertex2(vertexes[2]); //C

            GL.End();
        }

        public override bool IsPointIn(Vector2 test)
        {
            
            float a = ((vertexes[1].Y - vertexes[2].Y) * (test.X - vertexes[2].X) + (vertexes[2].X - vertexes[1].X) * 
                (test.Y - vertexes[2].Y)) / ((vertexes[1].Y - vertexes[2].Y) * (vertexes[0].X - vertexes[2].X) + 
                (vertexes[2].X - vertexes[1].X) * (vertexes[0].Y - vertexes[2].Y));
            float b = ((vertexes[2].Y - vertexes[0].Y) * (test.X - vertexes[2].X) + (vertexes[0].X - vertexes[2].X) * 
                (test.Y - vertexes[2].Y)) / ((vertexes[1].Y - vertexes[2].Y) * (vertexes[0].X - vertexes[2].X) + 
                (vertexes[2].X - vertexes[1].X) * (vertexes[0].Y - vertexes[2].Y));
            float c = 1 - a - b;

            if (a == 0 || b == 0 || c == 0) return true;
            else if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true;
            else return false;
        }

        /// <summary>
        /// Создание вершин треугольника
        /// </summary>
        public void GenVertexes()
        {
            vertexes = new Vector2[3];
            vertexes[0] = (Position.X - length / 2, (float)(Position.Y - Math.Sqrt(3) * length / 6));
            vertexes[1] = (Position.X, (float)(Position.Y + Math.Sqrt(3) * length / 3));
            vertexes[2] = (Position.X + length / 2, (float)(Position.Y - Math.Sqrt(3) * length / 6));
        }
    }
}
