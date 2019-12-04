using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregar
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;



namespace clbTriangulo
{
    public class Triangulo
    {
        #region Campos y propiedades
        private double _a;

        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        private double _b;

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        private double _c;

        public double C
        {
            get { return _c; }
            set { _c = value; }
        }

        public static double Escala;


        #endregion

        #region Constructores


        #endregion

        #region Métodos propios de la clase

        public double Mayor
        {
            get
            {
                double mayor = 0;

                if ((_a > _b) && (_a > _c))
                    mayor = _a;
                if ((_b > _c) && (_b > _a))
                    mayor = _b;
                if ((_c > _a) && (_c > _b))
                    mayor = _c;
                return mayor;

            }

        }

        public double Semiperimetro
        {
            get
            {
                double s;
                s = (_a + _b + _c) / 2;
                return s;
            }
        }

        public double Area
        {
            get
            {
                double area;
                area = Math.Sqrt(Semiperimetro * (Semiperimetro - _a) * (Semiperimetro - _b) * (Semiperimetro - _c));
                return area;
            }
        }

        public double Altura
        {
            get
            {
                double h = 0;
                h = 2 * Area / Mayor;
                return h;
            }
        }

        public double Menor
        {
            get
            {
                double menor = 0;
                if ((_a < _b) && (_a < _c))
                    menor = _a;
                if ((_b < _a) && (_b < _c))
                    menor = _b;
                if ((_c < _a) && (_c < _b))
                    menor = _c;
                return menor;
            }
        }

        public double xAltura
        {
            get
            {
                double xA;
                xA = Math.Sqrt((Menor * Menor) - (Altura * Altura));
                return xA;
            }
        }


        public void Dibujar(Canvas unCanvas)
        {
            Line Lmayor = new Line();
            Line Lado1 = new Line();
            Line Lado2 = new Line();

            Lmayor.StrokeThickness = 1;
            Lado1.StrokeThickness = 1;
            Lado2.StrokeThickness = 1;
            Lmayor.Stroke = Brushes.Black;
            Lado1.Stroke = Brushes.Black;
            Lado2.Stroke = Brushes.Black;





            double h = unCanvas.Height;
            double w = unCanvas.Width;

            Heron();


            double margenX = (w - Mayor * Escala) / 2;
            double margenY = (h - Altura * Escala) / 2;

            Lmayor.X1 = margenX;
            Lmayor.Y1 = margenY + Altura * Escala;
            Lmayor.X2 = margenX + Mayor * Escala;
            Lmayor.Y2 = margenY + Altura * Escala;



            Lado1.X1 = margenX;
            Lado1.Y1 = margenY + Altura * Escala;
            Lado1.X2 = margenX + xAltura * Escala;
            Lado1.Y2 = margenY;



            Lado2.X1 = margenX + Mayor * Escala;
            Lado2.Y1 = margenY + Altura * Escala;
            Lado2.X2 = xAltura * Escala + margenX;
            Lado2.Y2 = margenY;

            //mejor valida si es númerico con expresiones regulares :000
            ValidarEscala(unCanvas);
            unCanvas.Children.Add(Lmayor);
            unCanvas.Children.Add(Lado1);
            unCanvas.Children.Add(Lado2);


        }

        public bool ValidarEscala(Canvas unCanvas)
        {
            bool val = false;
            double w = unCanvas.Width;
            double margenX = (w - Mayor * Escala) / 2;
            if ((Escala * Mayor + margenX) > w)
            {
                val = false;
                MessageBox.Show("Escala muy grande para poder graficar");
            }
            else
                val = true;
            return val;
        }

        public bool Heron()
        {
            bool heron = false;
            if ((_a + _b > _c) || (_b + _c > _a) || (_c + _a > _b))
                heron = true;
            else
            {
                heron = false;
                MessageBox.Show("Valor de lados no graficable");
            }
            return heron;
        }



        #endregion


    }
}
