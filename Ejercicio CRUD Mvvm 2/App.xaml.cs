using Ejercicio_CRUD_Mvvm_2.Views;

namespace Ejercicio_CRUD_Mvvm_2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProductoMain());
        }
    }
}
