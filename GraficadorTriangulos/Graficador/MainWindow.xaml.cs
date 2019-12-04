using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using clbTriangulo;

namespace Graficador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, RoutedEventArgs e)
        {

            Triangulo tria = new Triangulo();
            tria.A = double.Parse(txtValorA.Text);
            tria.B = double.Parse(txtValorB.Text);
            tria.C = double.Parse(txtValorC.Text);
            Triangulo.Escala = double.Parse(txtEscala.Text);
            tria.Dibujar(cnvGrafico);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            cnvGrafico.Children.Clear();
            txtEscala.Text = string.Empty;
            txtValorA.Text = string.Empty;
            txtValorB.Text = string.Empty;
            txtValorC.Text = string.Empty;
        }

    }
}
