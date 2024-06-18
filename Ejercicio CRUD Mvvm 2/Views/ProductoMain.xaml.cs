using Ejercicio_CRUD_Mvvm_2.ViewModels;

namespace Ejercicio_CRUD_Mvvm_2.Views;

public partial class ProductoMain : ContentPage
{
    private ProductoMainViewModels viewModels;
    public ProductoMain()
    {
        InitializeComponent();
        viewModels = new ProductoMainViewModels();
        this.BindingContext = viewModels;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModels.GetAll();
    }
}