using Acr.UserDialogs;
using FreeGameHunter.Models.Entidades;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeGameHunter.Views
{
    public partial class XboxGames : ContentPage
    {
        List<EJuegos> XboxGamesList = new List<EJuegos>();

        public XboxGames()
        {
            InitializeComponent();
            ObtenerXboxGames();
        }

        public void ObtenerXboxGames()
        {
            
            EJuegos eJuegos = new EJuegos();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.trueachievements.com/free/games/xbox-one");
            HtmlNodeCollection imgs = new HtmlNodeCollection(document.DocumentNode.ParentNode);
            imgs = document.DocumentNode.SelectNodes("//img");

            foreach (HtmlNode text in imgs)
            {
                HtmlAttribute texttt = text.Attributes["alt"];
                HtmlAttribute src = text.Attributes[@"src"];
                if (src.Value.Contains("https://www.trueachievements.com"))
                {
                    XboxGamesList.Add(new EJuegos() { nombrejuego = texttt.Value.ToUpper(), urlfoto = src.Value });
                }

            }

            lsv_imagenes.ItemsSource = XboxGamesList;
        }

        private void JuegosSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var JuegosMenu = XboxGamesList.Where(c => c.nombrejuego.Contains(JuegosSearchBar.Text.ToUpper()));
            lsv_imagenes.ItemsSource = JuegosMenu;
        }
    }
}