using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TypesPage : ContentPage
    {
        public TypesPage(Dictionary<string, Color> pokeTypes)
        {
            InitializeComponent();

            ShowMainTypes(pokeTypes);

            ShowWeakTypes(pokeTypes);

            ShowResistantTypes(pokeTypes);

            ShowStrongTypes(pokeTypes);
        }

        private void ShowStrongTypes(Dictionary<string, Color> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.Key,
                    BackgroundColor = item.Value,
                    TextColor = Color.White,
                    FontSize = 18,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 10,
                    Margin = 10,
                };
                GridStrongTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }

        private void ShowResistantTypes(Dictionary<string, Color> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.Key,
                    BackgroundColor = item.Value,
                    TextColor = Color.White,
                    FontSize = 18,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 10,
                    Margin = 10,
                };
                GridResistantTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }

        private void ShowWeakTypes(Dictionary<string, Color> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.Key,
                    BackgroundColor = item.Value,
                    TextColor = Color.White,
                    FontSize = 18,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 10,
                    Margin = 10,
                };
                GridWeakTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }

        private void ShowMainTypes(Dictionary<string, Color> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.Key,
                    BackgroundColor = item.Value,
                    TextColor = Color.White,
                    FontSize = 18,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 10,
                    Margin = 10,
                };
                GridMainTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }
    }
}