using Ejercicio_CRUD_Mvvm_2.Models;
using Ejercicio_CRUD_Mvvm_2.ViewModels;

namespace Ejercicio_CRUD_Mvvm_2.Views;

public partial class addProducto : ContentPage
{
    private addProductoViewModels viewModels;
    public addProducto()
    {
        InitializeComponent();
        viewModels = new addProductoViewModels();
        this.BindingContext = viewModels;
    }

    public addProducto (Producto producto)
    {
        InitializeComponent();
        viewModels=new addProductoViewModels(producto);
        this.BindingContext = viewModels;
    }

}