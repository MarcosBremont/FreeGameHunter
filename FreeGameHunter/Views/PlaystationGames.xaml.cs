using Acr.UserDialogs;
using FreeGameHunter.Models;
using FreeGameHunter.Models.Entidades;
using FreeGameHunter.ViewModels;
using FreeGameHunter.Views;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeGameHunter.Views
{
    public partial class PlaystationGames : ContentPage
    {
        ItemsViewModel _viewModel;
        List<EJuegos> Playstation = new List<EJuegos>();

        public PlaystationGames()
        {
            InitializeComponent();
            ObtenerJuegosDePS();
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }


        public void ObtenerJuegosDePS()
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://psdeals.net/us-store/collection/free_to_play?platforms=ps4");
            HtmlNodeCollection imgs = new HtmlNodeCollection(document.DocumentNode.ParentNode);
            imgs = document.DocumentNode.SelectNodes("//img[@itemprop]");

            foreach (HtmlNode text in imgs)
            {
                HtmlAttribute texttt = text.Attributes["alt"];
                HtmlAttribute src = text.Attributes[@"data-src"];
                Playstation.Add(new EJuegos() { nombrejuego = texttt.Value, urlfoto = src.Value });
            }

            lsv_imagenes.ItemsSource = Playstation;

        }

        private void JuegosSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var JuegosMenu = Playstation.Where(c => c.nombrejuego.Contains(JuegosSearchBar.Text.ToUpper()));
            lsv_imagenes.ItemsSource = JuegosMenu;
        }
    }
}