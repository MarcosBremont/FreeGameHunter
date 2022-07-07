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
    public partial class EpicGames : ContentPage
    {
        ItemsViewModel _viewModel;

        public EpicGames()
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
            string prueba1 = "";
            List<EJuegos> prueba = new List<EJuegos>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://store.steampowered.com/search/?sort_by=Released_DESC&maxprice=free&genre=Free+to+Play");
            HtmlNodeCollection imgs = new HtmlNodeCollection(document.DocumentNode.ParentNode);
            imgs = document.DocumentNode.SelectNodes("//span[@class='title']");

            foreach (HtmlNode text in imgs)
            {
                string textttttt = text.InnerText;
                //HtmlAttribute texttt = text.Attributes["alt"];
                //HtmlAttribute src = text.Attributes[@"src"];
                prueba.Add(new EJuegos() { nombrejuego = textttttt/* urlfoto = "https://freegames.codes" + src.Value */ });
            }


            imgs = document.DocumentNode.SelectNodes("//img[@class='col search_capsule']");

            foreach (HtmlNode text in imgs)
            {
                //string textttttt = text.InnerText;
                //HtmlAttribute texttt = text.Attributes["alt"];
                HtmlAttribute src = text.Attributes[@"src"];
                prueba.Add(new EJuegos() { urlfoto = src.Value });
            }
            lsv_imagenes.ItemsSource = prueba;

        }
    }
}