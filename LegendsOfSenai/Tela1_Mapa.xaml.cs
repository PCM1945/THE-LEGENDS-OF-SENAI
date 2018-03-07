using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
            public Tela1_Mapa()
            {
                this.InitializeComponent();
            pointers = new Dictionary<uint, Pointer>();
         
            
            // Declare the pointer event handlers.
        /*    Target.PointerPressed +=
                new PointerEventHandler(Target_PointerPressed);
            Target.PointerEntered +=
                new PointerEventHandler(Target_PointerEntered);
            Target.PointerReleased +=
                new PointerEventHandler(Target_PointerReleased);
            Target.PointerExited +=
                new PointerEventHandler(Target_PointerExited);
            Target.PointerCanceled +=
                new PointerEventHandler(Target_PointerCanceled);
            Target.PointerCaptureLost +=
                new PointerEventHandler(Target_PointerCaptureLost);
            Target.PointerMoved +=
                new PointerEventHandler(Target_PointerMoved);
            Target.PointerWheelChanged +=
                new PointerEventHandler(Target_PointerWheelChanged);
                */
          
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.GoBack();

        }

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           
            e.Handled = true;

            PointerPoint ptrPt = e.GetCurrentPoint(mapa);

             Debug.WriteLine("pos X: " + ptrPt.Position.X);

             Debug.WriteLine("pos Y: " + ptrPt.Position.Y);

        }

        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }
    }
    
}
