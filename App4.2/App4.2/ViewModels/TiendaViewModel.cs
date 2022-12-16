using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4_2.ViewModels
{
    public class TiendaViewModel: BindableObject
    {
        int idTienda; public int IdTienda { get { return IdTienda; } set { idTienda = value; OnPropertyChanged("IdTienda"); } }
        string nombre; public string Nombre { get { return nombre; } set { nombre = value; OnPropertyChanged("Nombre"); } }
        string direccion; public string Direccion { get { return direccion; } set { direccion = value; OnPropertyChanged("Direccion"); } }
        string telefono; public string Telefono { get { return telefono; } set { telefono = value; OnPropertyChanged("Telefono"); } }
        decimal? latitud; public decimal Latitud { get { return (decimal)latitud; } set { latitud = value; OnPropertyChanged("Latitud"); } }
        decimal? longitud; public decimal Longitud { get { return (decimal)longitud; } set { longitud = value; OnPropertyChanged("Longitud"); } }
    }
}
