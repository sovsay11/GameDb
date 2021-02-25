using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Reflection;

namespace GameDb
{
    public partial class MainPage : ContentPage
    {
        // transfer to flyout mvc control later
        /*
         * For now, focus on default landing page.
         * Purpose: Search pokemon using entry, display search
         * in a list. When an item is selected, navigate to
         * a new page with some basic details about the selected item (details include
         * name and type
         */

        public MainPage()
        {
            InitializeComponent();

            LoadPokemon();
        }

        private void EntName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        // grab the pokemon names
        private void LoadPokemon()
        {
            List<string> names = new List<string>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream sr = assembly.GetManifestResourceStream("GameDb.pokemon.txt");

            using (StreamReader reader = new StreamReader(sr))
            {
                while (!reader.EndOfStream)
                {
                    names.Add(reader.ReadLine());
                }
            }

            LstViewPokemon.ItemsSource = names;
        }

        private void SearchPokemon()
        {
            List<string> names = new List<string>();
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // offset is starting location
                    // limit is the number of entries
                    string jsonData = wc.DownloadString($@"https://pokeapi.co/api/v2/pokemon?offset=0&limit=20");

                    // method 1
                    JObject pokeDetails = JObject.Parse(jsonData);

                    // might need
                    int count = int.Parse(pokeDetails["count"].ToString());

                    foreach (var item in pokeDetails["results"])
                    {
                        names.Add(pokeDetails["name"].ToString());
                    }

                    LstViewPokemon.ItemsSource = names;

                    // method 2 of deserialization
                    //PokeDetails poke = JsonConvert.DeserializeObject<PokeDetails>(jsonData);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}
