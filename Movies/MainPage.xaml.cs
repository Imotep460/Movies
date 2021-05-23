using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Movies.Data;
using Movies.Managers;

namespace Movies
{
    public partial class MainPage : ContentPage
    {
        private MovieManager movieManager = new MovieManager();
        public MainPage()
        {
            InitializeComponent();
        }

        public async void GetAll()
        {
            var result = await movieManager.GetAllMovies();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAll();
        }
    }
}
