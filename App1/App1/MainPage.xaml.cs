using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<Film> Films { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Films = new List<Film>();
            Films.Add(new Film { Titolo = "Le invenzioni di Homer", Immagine = "simpson.png", Link = "https://www.youtube.com/watch?v=ALFAZ4CIqiE" });
            Films.Add(new Film { Titolo = "Skywalker Becomes Darth Vader", Immagine = "dartvader.png", Link = "https://www.youtube.com/watch?v=0KYxYOo2RnA" });
            Films.Add(new Film { Titolo = "Capitan America", Immagine = "scudo.png", Link = "https://www.youtube.com/watch?v=QP8l6J_H38g" });
        

            lvDati.ItemsSource = Films;
        }

        async private void btnOpenVideo(object sender, EventArgs e)
        {
            // Il record corrente passato con . , è dentro all'attributo "CommandParameter"
            // il quale è dentro al Button...
            // Button ci arriva come object e va fatto un cast con l'operatore as
            // Se l'operatore as torna null, qualcosa è andato storto... meglio non fare nulla
            Button m = sender as Button;
            if( m != null )
            {
                // Anche CommandParameter è un object e serve un cast a Film
                Film f = m.CommandParameter as Film;
                if( f != null )
                {
                    await Browser.OpenAsync(f.Link, BrowserLaunchMode.SystemPreferred);
                }
            }
        }
    }
}
