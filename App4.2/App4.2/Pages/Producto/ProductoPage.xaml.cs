using App4._2.ViewModels;
using App4_2.Models;
using App4_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4._2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        ProductoViewModel CurrentViewModel { get { return (ProductoViewModel)this.BindingContext; } }

        List<Item> marcaList { get; set; }

        public ProductoPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.ProductoViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await InitPickers();

            marcaPicker.SelectedItem = marcaList.Where(p => p.Id == CurrentViewModel.IdMarca).FirstOrDefault();
        }

        public async Task InitPickers()
        {
            Service service = new Service();

            var marcas = await service.MarcaQueryAsync();

            marcaList = marcas.Select(p =>
            new Item
            {
                Id = p.IdMarca,
                Description = p.Descripcion
            }).ToList();

            marcaPicker.ItemsSource = marcaList;
        }

        public void LoadData(Producto producto)
        {
            CurrentViewModel.IdProducto = producto.IdProducto;
            CurrentViewModel.Descripcion = producto.Descripcion;
            CurrentViewModel.IdMarca = producto.IdMarca;
            CurrentViewModel.Activo = producto.Activo;
        }

        private  async void saveButton_Clicked(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.IdProducto = CurrentViewModel.IdProducto;
            producto.Descripcion = CurrentViewModel.Descripcion;            
            producto.Activo = CurrentViewModel.Activo;

            //producto.IdMarca = 3;

            Item itemMarca = marcaPicker.SelectedItem as Item;

            if (itemMarca != null)
                producto.IdMarca = itemMarca.Id;

            Service service = new Service();

            bool result = false;

            if(producto.IdProducto == 0)
                result = await service.ProductoInsertAsync(producto);
            else
                result = await service.ProductoUpdateAsync(producto);

            if (result)
            {
                await this.Navigation.PopAsync();
            }
        }
    }
}