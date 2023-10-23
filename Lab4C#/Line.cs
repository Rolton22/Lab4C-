using System;

namespace Lab4C_
{
    /// <summary>
    /// Класс Line,являющиейся моделью прямой,состоящий их двух точек(x1,y1) и (x2,y2).
    /// В классе есть метод вывода уравнения прямой,проверка на параллельность прямых и нахождения угла с помощью перегрузки операторов 
    /// |-параллельность и %-определение угла между двумя прямыми.Также есть метод вывода координат точек с помощью ToString
    /// /// </summary>
    internal class Line
    {

        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;

        /// <summary>
        /// Конструктор прямой с двумя точками
        /// </summary>
        /// <param name="x1">Точка x1</param>
        /// <param name="y1">Точка y1</param>
        /// <param name="x2">Точка x2</param>
        /// <param name="y2">Точка y2</param>
        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

        }

        /// <summary>
        /// Установка и получение полей _x1,_y1,_x2,_y2 являющиеся точками двух прямых.
        /// </summary>
        public double X1 { get => _x1; set => _x1 = value; }
        public double Y1 { get => _y1; set => _y1 = value; }
        public double X2 { get => _x2; set => _x2 = value; }
        public double Y2 { get => _y2; set => _y2 = value; }

        /// <summary>
        /// В этом методе вычисляется наклой прямой(slope) и пересечение прямой(intercept) оси y.
        /// Вывод уравнения происходит в формате "y = mx + b", где m - наклон прямой, а b - пересечение.
        /// </summary>
        /// <returns>Уравнение прямой</returns>
        public string PrintEquation()
        {
            double slope = (Y2 - Y1) / (X2 - X1);
            double intercept = Y1 - slope * X1;

          
            return $"Уравнение прямой: y = (0)x + (1), {slope}, {intercept}";
        }

        /// <summary>
        /// Перезагружать оператор || нельзя,ссылка на источник в Read.Me
        /// Здесь который проверяет параллельность двух прямых, используя наклоны.
        /// </summary>
        /// <param name="left_line">Первая прямая</param>
        /// <param name="right_line">Вторая прямая</param>
        /// <returns>Сравнение разницы между наклонами</returns>
        public static bool operator |(Line left_line, Line right_line)
        {
            //Эти строки рассчитывает наклон (угловой коэффициент) первой прямой и второй прямой (представленной объектом left_line и right_line)
            double slope1 = (left_line.Y2 - left_line.Y1) / (left_line.X2 - left_line.X1);
            double slope2 = (right_line.Y2 - right_line.Y1) / (right_line.X2 - right_line.X1);
            //В этой стоке происходит сравнение разницы наклонов двух прямых с double.Epsilon,которое ялвяется очень маленьким положительным числом
            //и если разница между наклонами меньше,то прямые считаются практически параллельными, и метод возвращает true.Math.Abs нужен , чтобы убедиться, что разница положительная.
            return Math.Abs(slope1 - slope2) < double.Epsilon;
        }

        /// <summary>
        /// Перегрузка оператора % для определения угла между двумя прямыми
        /// </summary>
        /// <param name="line1">Первая прямая</param>
        /// <param name="line2">Вторая прямая</param>
        /// <returns>Угол в градусах</returns>
        public static double operator %(Line line1, Line line2)
        {
            // Вычисление скалярного произведения векторов прямых
            double dotProduct = (line1.X2 - line1.X1) * (line2.X2 - line2.X1) + (line1.Y2 - line1.Y1) * (line2.Y2 - line2.Y1);

            // Вычисление длины векторов
            double length1 = Math.Sqrt(Math.Pow(line1.X2 - line1.X1, 2) + Math.Pow(line1.Y2 - line1.Y1, 2));
            double length2 = Math.Sqrt(Math.Pow(line2.X2 - line2.X1, 2) + Math.Pow(line2.Y2 - line2.Y1, 2));

            // Вычисление угла между прямыми в радианах
            double angleRad = Math.Acos(dotProduct / (length1 * length2));

            // Перевод угла в градусы
            double angleDeg = angleRad * (180.0 / Math.PI);

            return angleDeg;
        }

        
        public override string ToString()
        {
            return $"Line(x1{_x1},y1{_y1},x2{_x2},y2{_y2})";
        }
    }
}

