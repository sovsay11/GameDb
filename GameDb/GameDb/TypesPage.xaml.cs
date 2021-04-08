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
        public TypesPage(List<string> pokeTypes)
        {
            InitializeComponent();

            // adding labels to the new grid
            int i = 0;
            foreach (var item in pokeTypes)
            {
                Label tempType = new Label { Text = item };
                GridMainTypes.Children.Add(tempType);
                Grid.SetRow(tempType, 0);
                Grid.SetColumn(tempType, i);
                i += 1;
            }
        }
    }
}