using FreeGameHunter.Models.Entidades;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeGameHunter.Views
{
    public partial class XboxGames : ContentPage
    {
        public XboxGames()
        {
            InitializeComponent();
            ObtenerXboxGames();
        }

        public void ObtenerXboxGames()
        {
            List<EJuegos> prueba = new List<EJuegos>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.trueachievements.com/free/games/xbox-one");
            HtmlNodeCollection imgs = new HtmlNodeCollection(document.DocumentNode.ParentNode);
            imgs = document.DocumentNode.SelectNodes("//img");

            foreach (HtmlNode text in imgs)
            {
                HtmlAttribute texttt = text.Attributes["alt"];
                HtmlAttribute src = text.Attributes[@"src"];
                prueba.Add(new EJuegos() { nombrejuego = texttt.Value, urlfoto = src.Value });
            }

            lsv_imagenes.ItemsSource = prueba;
        }
    }
}