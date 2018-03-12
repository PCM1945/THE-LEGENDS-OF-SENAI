using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Legends_lib;
using Legends_lib.maps.mapa_geral.Controls;
namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {

        public Mapa map= new MainMapControl().InciarMapa();
        public Personagem selecionado;
        public bool selecionou=false;
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
            public Tela1_Mapa()
            {
                this.InitializeComponent();
            pointers = new Dictionary<uint, Pointer>();
          

        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.GoBack();

        }

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           
            e.Handled = true;

            PointerPoint ptrPt = e.GetCurrentPoint(mapa);
            if (selecionou == false)
            {
                if (map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null)
                {
                    selecionou = true;
                    selecionado = map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem;
                   // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }
            else
            {
                if (map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem == null)
                {
                    selecionou =false;
                    map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem=selecionado;
                    // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }
           
             Debug.WriteLine("pos X: " + ptrPt.Position.X);

             Debug.WriteLine("pos Y: " + ptrPt.Position.Y);

        }

        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }
    }
    
}
