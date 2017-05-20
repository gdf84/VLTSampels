using Ninject;
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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StandardKernel kernel;

        public MainWindow()
        {
            InitializeComponent();
            kernel = new StandardKernel();
            kernel.Bind<Warrior>().ToSelf();
            kernel.Bind<IWeapon>().To<Chaka>();//.InSingletonScope();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            MessageBox.Show(kernel.Get<Warrior>().Hit());
        }
    }
}
