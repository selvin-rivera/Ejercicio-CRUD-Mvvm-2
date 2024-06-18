
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejercicio_CRUD_Mvvm_2.Models;
using Ejercicio_CRUD_Mvvm_2.Services;


namespace Ejercicio_CRUD_Mvvm_2.ViewModels
{
    public partial class addProductoViewModels : ObservableObject
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string descripcion;
        [ObservableProperty]
        private string ubicacion;
        [ObservableProperty]
        private string proveedor;

        private readonly ProductoService service;

        public addProductoViewModels()
        {
            this.service = new ProductoService();
        }

        public addProductoViewModels(Producto producto)
        {
            this.id = producto.Id;
            this.nombre = producto.Nombre;
            this.descripcion = producto.Descripcion;
            this.ubicacion = producto.Ubicacion;
            this.proveedor = producto.Proveedor;
            service = new ProductoService();
        }

        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Producto producto = new Producto()
                {
                    Id = this.id,
                    Nombre = this.nombre,
                    Descripcion = this.descripcion,
                    Ubicacion = this.ubicacion,
                    Proveedor = this.proveedor
                };

                if (producto.Nombre != null || producto.Nombre != "")
                {
                    if (Id == 0)
                    {
                        service.Insert(producto);
                    }
                    else
                    {
                        service.Update(producto);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }else
                {
                    Alerta("ADVERTENCI", "Ingrese el nombre completo");
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }

        }
    }
}
