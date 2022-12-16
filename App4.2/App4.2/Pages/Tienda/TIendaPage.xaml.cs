using App4_2.Models;
using App4_2.Services;
using App4_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4_2.Pages.Tienda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TIendaPage : ContentPage
    {
        TiendaViewModel CurrentViewModel { get { return (TiendaViewModel)this.BindingContext; } }
        
        public TIendaPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TiendaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            //marcaPicker.SelectedItem = marcaList.Where(p => p.Id == CurrentViewModel.IdMarca).FirstOrDefault();
        }

        public void LoadData(TiendaModel tienda)
        {
            CurrentViewModel.IdTienda = tienda.IdTienda;
            CurrentViewModel.Nombre = tienda.Nombre;
            CurrentViewModel.Direccion = tienda.Direccion;
            CurrentViewModel.Telefono = tienda.Telefono;
            CurrentViewModel.Latitud = tienda.Latitud != null ? (decimal)tienda.Latitud: 0;
            CurrentViewModel.Longitud = tienda.Longitud !=null ? (decimal)tienda.Longitud: 0;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            TiendaModel tienda = new TiendaModel();

            tienda.IdTienda = CurrentViewModel.IdTienda;
            tienda.Nombre = CurrentViewModel.Nombre;
            tienda.Direccion = CurrentViewModel.Direccion;
            tienda.Telefono = CurrentViewModel.Telefono;
            tienda.Latitud = (decimal)CurrentViewModel.Latitud;
            tienda.Longitud = (decimal)CurrentViewModel.Longitud;

           
            TiendaService service = new TiendaService();

            bool result = false;

            if (tienda.IdTienda == 0)
                result = await service.TiendaInsertAsync(tienda);
            else
                result = await service.TiendaUpdateAsync(tienda);

            if (result)
            {
                await this.Navigation.PopAsync();
            }
        }
    }
}