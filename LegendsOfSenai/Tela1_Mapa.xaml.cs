using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {
            public Tela1_Mapa()
            {
                this.InitializeComponent();
            }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
    
}
