﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Start_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("aaaaaaaaaaaa");

            CoreApplicationView newCoreView = CoreApplication.CreateNewView();
            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
             CoreDispatcherPriority.Normal,
             () =>
                 {
             newAppView = ApplicationView.GetForCurrentView();
                 Window.Current.Content = new Frame();
                (Window.Current.Content as Frame).Navigate(typeof(Tela1_Mapa));
            Window.Current.Activate();
        });  
        }

        private async void anyEVent(object sender, RoutedEventArgs e)
        {
            var a = new Legends_lib.Personagem();

            a.Nome = "NAME";
            a.Classe = "Classe";

            var b = new Legends_lib.maps.mapa_geral.Controls.MainMapControl();
            b.MetricaX(this.ActualWidth);


        }
    }
}
