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
            string attribute2;
            // remember that v goes with r and s goes with w
            // setting grids
            Grid generalGrid;
            if (attribute == "v")
            {
                generalGrid = GridVulnerableTypes;
                attribute2 = "r";
            }
            else if (attribute == "s")
            {
                generalGrid = GridStrongTypes;
                attribute2 = "w";
            }
            else if (attribute == "r")
            {
                generalGrid = GridResistantTypes;
                attribute2 = "v";
            }
            else
            {
                generalGrid = GridWeakTypes;
                attribute2 = "s";
            }

            // assuming single type
            if (pokeTypes.Count == 1)
            {
                // adding labels to the new grid
                int row = 0;
                int column = 0;
                foreach (var attrCategory in pokeTypes[0].GetAttribute(attribute))
                {
                    Label tempType = new Label
                    {
                        Text = $"{attrCategory.Key} ×{attrCategory.Value}",
                        BackgroundColor = pokeTypes[0].GetColor(attrCategory.Key),
                        TextColor = Color.White,
                        FontSize = 15,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Padding = 10,
                        Margin = 10,
                    };

                    if (attrCategory.Value == 4 || attrCategory.Value == 0 || attrCategory.Value == .25)
                    {
                        tempType.TextColor = Color.Black;
                    }

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
            // dual types
            else
            {
                Dictionary<string, double> combinedAttributes = pokeTypes[0].GetCombinedAttributes(pokeTypes[0], pokeTypes[1], attribute, attribute2);

                // adding labels to the new grid
                int row = 0;
                int column = 0;
                foreach (var attrCategory in combinedAttributes)
                {
                    Label tempType = new Label
                    {
                        Text = $"{attrCategory.Key} ×{attrCategory.Value}",
                        BackgroundColor = pokeTypes[0].GetColor(attrCategory.Key),
                        TextColor = Color.White,
                        FontSize = 15,
                        FontAttributes = FontAttributes.Bold,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Padding = 10,
                        Margin = 10,
                    };

                    if (attrCategory.Value == 4 || attrCategory.Value == 0 || attrCategory.Value == .25)
                    {
                        tempType.TextColor = Color.Black;
                    }

                    Grid.SetRow(tempType, row);
                    Grid.SetColumn(tempType, column);

                    AddToGrid(generalGrid, tempType, attribute, attrCategory, ref column, ref row);

                    //generalGrid.Children.Add(tempType);

                }
            }
        }

        private void AddToGrid(Grid generalGrid, Label tempType, string attribute, KeyValuePair<string, double> attrCategory, ref int column, ref int row)
        {
            if (attrCategory.Value != 1)
            {
                if (attrCategory.Value == 0)
                {
                    if (attribute == "r" || attribute == "w")
                    {
                        generalGrid.Children.Add(tempType);

                        if (column == 2)
                        {
                            column = 0;
                            row += 1;
                        }
                        else
                        {
                            column += 1;
                        }
                    }
                }
                else
                {
                    generalGrid.Children.Add(tempType);

                    if (column == 2)
                    {
                        column = 0;
                        row += 1;
                    }
                    else
                    {
                        column += 1;
                    }
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