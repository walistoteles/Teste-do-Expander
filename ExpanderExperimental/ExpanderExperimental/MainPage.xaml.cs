using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ExpanderExperimental
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myEvents = GetEvents();
            this.BindingContext = this;
        }

        public ObservableCollection<Event> myEvents { get; set; }


        private ObservableCollection<Event> GetEvents()
        {
            return new ObservableCollection<Event>
            {
                new Event{Title = "Curso de Culinaria", image = "https://www.primecursos.com.br/arquivos/uploads/2018/06/gastronomia-basica.jpg", Venue = "Register Online", Duration = "07:30 UTC - 00:00 UTC", Description = "Teste", Date = new DateTime(2008, 5, 1, 8, 30, 52)},
                new Event{Title = "Curso de Informatica", image = "https://www.cursosabeline.com.br/webroot/cur_cache/curso-com-certificado-de-informatica-basica-1567603559-870-810b01c8.jpg", Venue = "Register Presencial", Duration = "07:30 UTC - 00:00 UTC", Description = "Teste 03" , Date =  new DateTime(2008, 5, 1, 8, 30, 52)},
                new Event{Title = "Curso de Engenharia", image = "https://www.pravaler.com.br/wp-content/uploads/2020/01/curso-de-engenharia-saiba-tudo-sobre-o-curso-e-como-se-tornar-engenheiro-capa-principal.jpg", Venue = "Sem Registro", Duration = "07:30 UTC - 00:00 UTC", Description = "Teste 02 " , Date =  new DateTime(2008, 5, 1, 8, 30, 52)}
            };
        }


        private async Task OpenAnimation(View view, uint lenght = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, lenght);
            await view.RotateXTo(0, lenght);
        }

        private async Task CloseAnimation(View view, uint lenght = 250)
        {
            _ = view.FadeTo(0, lenght);
            await view.RotateXTo(-90, lenght);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DetailsView");

            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(imgView);
                await CloseAnimation(detailsView);
            }
        }
    }




    public class Event
    {
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string image { get; set; }

        public DateTime Date { get; set; }

    }
}
