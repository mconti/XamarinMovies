using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace App1.Models
{
    public class Film
    {
        public string Immagine { get; set; }
        public string Titolo { get; set; }
        public string Link { get; set; }
    }

    public class Films : ObservableCollection<Film>
    {
        public Films() 
        {
            //Add(new Film { Titolo = "Le invenzioni di Homer", Immagine = "simpson.png", Link = "https://www.youtube.com/watch?v=ALFAZ4CIqiE" });
            //Add(new Film { Titolo = "Skywalker Becomes Darth Vader", Immagine = "dartvader.png", Link = "https://www.youtube.com/watch?v=0KYxYOo2RnA" });
            //Add(new Film { Titolo = "Capitan America", Immagine = "scudo.png", Link = "https://www.youtube.com/watch?v=QP8l6J_H38g" });
        }

        public void Load()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fileName = Path.Combine(path, "films.csv");

                if (File.Exists(fileName))
                {
                    StreamReader sr = new StreamReader(fileName);
                    while( !sr.EndOfStream)
                    {
                        string riga = sr.ReadLine();
                        string[] colonne = riga.Split(';');
                        Film f = new Film { Titolo = colonne[0], Immagine = colonne[1], Link = colonne[2] };
                        Add(f);
                    }
                    sr.Close();
                }
            }
            catch (Exception errore) { }

        }
        public void Save()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fileName = Path.Combine(path, "films.csv");

                StreamWriter sw = new StreamWriter(fileName);

                foreach ( Film f in this )
                {
                    sw.WriteLine( $"{f.Titolo};{f.Immagine};{f.Link}" );
                }
                sw.Close();
            }
            catch (Exception errore) { }

        }

    }
}
