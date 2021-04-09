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

        private void AddTypeLabels(List<PokeType> pokeTypes, string attribute)
        {
            Grid generalGrid;
            if (attribute == "v")
            {
                generalGrid = GridVulnerableTypes;
            }
            else if (attribute == "s")
            {
                generalGrid = GridStrongTypes;
            }
            else if (attribute == "r")
            {
                generalGrid = GridResistantTypes;
            }
            else
            {
                generalGrid = GridWeakTypes;
            }

            // adding labels to the new grid
            int row = 0;
            int column = 0;
            foreach (var type in pokeTypes)
            {
                foreach (var attrCategory in type.GetAttribute(attribute))
                {
                    Label tempType = new Label
                    {
                        Text = $"{attrCategory.Key} ×{attrCategory.Value}",
                        BackgroundColor = type.GetColor(attrCategory.Key),
                        TextColor = Color.White,
                        FontSize = 15,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Padding = 10,
                        Margin = 10,
                    };
                    Grid.SetRow(tempType, row);
                    Grid.SetColumn(tempType, column);
                    if (column == 2)
                    {
                        column = 0;
                        row += 1;
                    }
                    else
                    {
                        column += 1;
                    }
                    generalGrid.Children.Add(tempType);
                }
            }
        }

        private void ShowVulnerableTypes(List<PokeType> pokeTypes)
        {
            AddTypeLabels(pokeTypes, "v");
        }

        private void ShowStrongTypes(List<PokeType> pokeTypes)
        {
            AddTypeLabels(pokeTypes, "s");
        }

        private void ShowResistantTypes(List<PokeType> pokeTypes)
        {
            AddTypeLabels(pokeTypes, "r");
        }

        private void ShowWeakTypes(List<PokeType> pokeTypes)
        {
            AddTypeLabels(pokeTypes, "w");
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