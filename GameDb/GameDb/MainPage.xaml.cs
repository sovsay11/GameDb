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
using System.Globalization;

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
         * 
         * Maybe I could also create a content view or something with a label and an image tied to it
         */

        List<string> names = new List<string>();

        public MainPage()
        {
            InitializeComponent();

            LoadPokemon();
        }

        // grab the pokemon names
        private void LoadPokemon()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream sr = assembly.GetManifestResourceStream("GameDb.pokemon.txt");

            using (StreamReader reader = new StreamReader(sr))
            {
                while (!reader.EndOfStream)
                {
                    // capitalize the first letter of the pokemon name
                    string pokeName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reader.ReadLine().ToLower());

                    names.Add(pokeName);

                    //Label label = new Label { Text = pokeName };

                    //SLPokemon.Children.Add(label);
                }
            }

            LstViewPokemon.ItemsSource = names;
        }

        /// <summary>
        /// Filter pokemon by entry box
        /// </summary>
        private void FilterPokemon()
        {
            string search = EntName.Text;
            // new tempAccount list, local in scope
            List<string> tempNames = new List<string>();
            // clear it just in case
            tempNames.Clear();
            // populate the list and show the details using the current search text
            foreach (var name in names)
            {
                if (name.ToLower().Contains(search.ToLower()))
                {
                    tempNames.Add(name);
                }
            }
            LstViewPokemon.ItemsSource = tempNames;
        }

        /// <summary>
        /// Open new details window using selected pokemon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPokeDetails_Clicked(object sender, EventArgs e)
        {
            if (LstViewPokemon.SelectedItem != null)
            {
                DetailsPage detailsPage = new DetailsPage(LstViewPokemon.SelectedItem.ToString());

                Navigation.PushAsync(detailsPage, true);
            }
            else
            {
                DisplayAlert("Error", "Please select a pokemon", "Close");
            }
        }

        private void EntName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPokemon();
        }

        private void BtnPokeTypes_Clicked(object sender, EventArgs e)
        {
            if (LstViewPokemon.SelectedItem != null)
            {
                DetailsPage detailsPage = new DetailsPage(LstViewPokemon.SelectedItem.ToString());

                Navigation.PushAsync(new TypesPage(detailsPage.pokeTypes), true);
            }
            else
            {
                Navigation.PushAsync(new TypesPage());
            }
        }
    }
}
