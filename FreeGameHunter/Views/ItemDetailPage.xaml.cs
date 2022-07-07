using FreeGameHunter.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FreeGameHunter.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}