using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejercicio_CRUD_Mvvm_2.Models;
using Ejercicio_CRUD_Mvvm_2.Services;
using Ejercicio_CRUD_Mvvm_2.Views;
using System.Collections.ObjectModel;


namespace Ejercicio_CRUD_Mvvm_2.ViewModels
{
    public partial class ProductoMainViewModels : ObservableObject
    {
        // Coleccion de datos para interactuar con la vista
        [ObservableProperty]
        private ObservableCollection<Producto> productoCollection=new ObservableCollection<Producto>();
       
        // Llamamos a la clase en donde configuramos la base de datos
        private readonly ProductoService productoService;

        // Constructor
        public ProductoMainViewModels()
        {
            productoService = new ProductoService();
        }

        /// <summary>
        /// Muestra el listado de producto
        /// </summary>
        public void GetAll()
        {
            var getAll = productoService.GetAll();

            // Valido si la lista contiene registros
            if (getAll?.Count() > 0)
            {
                ProductoCollection.Clear();
                foreach (var producto in getAll)
                {
                    ProductoCollection.Add(producto);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la vista de agregar producto
        /// </summary>
        /// <returns>Vista de agregar producto</returns>
        [RelayCommand]
        private async Task goToaddProducto()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new addProducto());
        }

        /// <summary>
        /// Muestra las opciones al seleccionar un registro de producto
        /// </summary>
        /// <param name="producto">Objeto seleccionado para actualizar o eliminar</param>
        /// <returns></returns>
        [RelayCommand]
        private async Task SelectProducto(Producto producto)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        //TODO descomentar cuando se cree el view model para addProducto
                        await App.Current.MainPage.Navigation.PushAsync(new addProducto(producto));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR EMPLEADO", "¿Desea eliminar el registro de empleado?", "Si", "No");

                        if (respuesta)
                        {
                            int del = productoService.Delete(producto);

                            if (del > 0)
                            {
                                ProductoCollection.Remove(producto);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Muestra un mensaje de alerta personalizado
        /// </summary>
        /// <param name="Titulo">Titulo de la alerta, por ejemplo, ERROR, ADVERTENCIA, etc</param>
        /// <param name="Mensaje">Mensaje a mostrar en la alerta</param>
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
    }
}
