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
        public TypesPage(List<PokeType> pokeTypes)
        {
            InitializeComponent();

            ShowVulnerableTypes(pokeTypes);

            ShowStrongTypes(pokeTypes);

            ShowMainTypes(pokeTypes);

            ShowResistantTypes(pokeTypes);

            ShowWeakTypes(pokeTypes);
        }

        private void ShowVulnerableTypes(List<PokeType> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.name,
                    BackgroundColor = item.color,
                    TextColor = Color.White,
                    FontSize = 18,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 10,
                    Margin = 10,
                };
                GridVulnerableTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }

        private void ShowStrongTypes(List<PokeType> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.name,
                    BackgroundColor = item.color,
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

        private void ShowResistantTypes(List<PokeType> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.name,
                    BackgroundColor = item.color,
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

        private void ShowWeakTypes(List<PokeType> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.name,
                    BackgroundColor = item.color,
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

        private void ShowMainTypes(List<PokeType> pokeTypes)
        {
            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label
                {
                    Text = item.name,
                    BackgroundColor = item.color,
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