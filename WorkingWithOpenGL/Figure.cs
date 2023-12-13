using OpenTK.Mathematics;

namespace WorkingWithOpenGL
{
    internal abstract class Figure
    {
        /// <summary>вектор цвета</summary>
        protected Vector3 color;

        /// <summary>список цветов</summary>
        protected List<Vector3>? colors;

        private Vector2 position;
        /// <summary>
        /// вектор позиции точки (курсора мыши), привязанной к фигуре
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position.X = value.X - shift.X;
                position.Y = value.Y - shift.Y;
            }
        }

        private Vector2 shift = new();

        protected Figure(Vector2 position, Vector3 color)
        {
            this.color = color;
            Position = position;
        }

        protected Figure(Vector2 position, List<Vector3> colors)
        {
            this.colors = colors;
            Position = position;
        }

        /// <summary>
        /// проверка на принадлежность точки фигуре
        /// </summary>
        /// <param name="test">проверяемая точка</param>
        /// <returns>true если принадлежит, иначе false</returns>
        public abstract bool IsPointIn(Vector2 test);

        /// <summary>отрисовка фигуры</summary>
        public abstract void Draw();

        public void Touch(Vector2 touch)
        {

            shift.X = touch.X - Position.X;
            shift.Y = touch.Y - Position.Y;
        }
    }
}
