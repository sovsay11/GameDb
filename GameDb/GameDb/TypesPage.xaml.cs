﻿using System;
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
        List<PokeType> customTypes = new List<PokeType>();
        bool customSwitch = false;

        Dictionary<string, PokeType> typeDict = new Dictionary<string, PokeType>
        {
            { "Normal", new Normal() },
                { "Fire", new Fire() },
                { "Water", new Water() },
                { "Electric", new Electric() },
                { "Grass", new Grass() },
                { "Ice", new Ice() },
                { "Fighting", new Fighting() },
                { "Poison", new Poison() },
                { "Ground", new Ground() },
                { "Flying", new Flying() },
                { "Psychic", new Psychic() },
                { "Bug", new Bug() },
                { "Rock", new Rock() },
                { "Ghost", new Ghost() },
                { "Dragon", new Dragon() },
                { "Dark", new Dark() },
                { "Steel", new Steel() },
                { "Fairy", new Fairy() },
        };

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
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Padding = 10,
                        Margin = 5,
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
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Padding = 10,
                        Margin = 5,
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
            List<string> typeList = new List<string>
            {
                { "Normal" },
                { "Fire" },
                { "Water" },
                { "Electric" },
                { "Grass" },
                { "Ice" },
                { "Fighting" },
                { "Poison" },
                { "Ground" },
                { "Flying" },
                { "Psychic" },
                { "Bug" },
                { "Rock" },
                { "Ghost" },
                { "Dragon" },
                { "Dark" },
                { "Steel" },
                { "Fairy" },
            };

            if (pokeTypes.Count == 2)
            {
                PckrType1.ItemsSource = typeList;
                PckrType2.ItemsSource = typeList;

                PckrType1.SelectedItem = pokeTypes[0].name;
                PckrType1.BackgroundColor = pokeTypes[0].color;

                PckrType2.SelectedItem = pokeTypes[1].name;
                PckrType2.BackgroundColor = pokeTypes[1].color;

                customSwitch = true;
            }
            else
            {
                PckrType2.IsEnabled = false;

                PckrType1.ItemsSource = typeList;
                PckrType1.SelectedItem = pokeTypes[0].name;
                PckrType1.BackgroundColor = pokeTypes[0].color;

                Grid.SetColumnSpan(PckrType1, 2);

                customSwitch = true;
            }

            // adding labels to the new grid
            //int i = 0;
            //foreach (var item in pokeTypes)
            //{
            //    Label tempType = new Label
            //    {
            //        Text = item.name,
            //        BackgroundColor = item.color,
            //        TextColor = Color.White,
            //        FontSize = 18,
            //        VerticalTextAlignment = TextAlignment.Center,
            //        HorizontalTextAlignment = TextAlignment.Center,
            //        Padding = 10,
            //        Margin = 10,
            //    };
            //    GridMainTypes.Children.Add(tempType);
            //    Grid.SetRow(tempType, 0);
            //    Grid.SetColumn(tempType, i);
            //    i += 1;
            //}
        }

        private PokeType CreateType(string text)
        {
            PokeType poke;
            foreach (var item in typeDict)
            {
                if (text == item.Key)
                {
                    poke = item.Value;
                    return poke;
                }
            }
            return new Normal();
        }

        private void PckrType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customSwitch)
            {
                if (PckrType2.SelectedIndex > -1)
                {
                    string chosenType1 = PckrType1.SelectedItem.ToString();
                    string chosenType2 = PckrType2.SelectedItem.ToString();

                    PokeType type1 = CreateType(chosenType1);
                    PokeType type2 = CreateType(chosenType2);

                    customTypes = new List<PokeType>();

                    customTypes.Add(type1);
                    customTypes.Add(type2);

                    Navigation.PopAsync();

                    Navigation.PushAsync(new TypesPage(customTypes));
                }
                else
                {
                    string chosenType = PckrType1.SelectedItem.ToString();

                    PokeType type1 = CreateType(chosenType);

                    customTypes.Add(type1);

                    Navigation.PopAsync();

                    Navigation.PushAsync(new TypesPage(customTypes));
                }
            }
        }

        private void PckrType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customSwitch)
            {
                string chosenType1 = PckrType1.SelectedItem.ToString();
                string chosenType2 = PckrType2.SelectedItem.ToString();

                PokeType type1 = CreateType(chosenType1);
                PokeType type2 = CreateType(chosenType2);

                customTypes = new List<PokeType>();

                customTypes.Add(type1);
                customTypes.Add(type2);

                Navigation.PopAsync();

                Navigation.PushAsync(new TypesPage(customTypes));
            }
        }
    }
}