using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //bool _isPlaying;
        public MainPage()
        {
            this.InitializeComponent();
          //  PlayOpening();
        }

        //private async void Play()
        //{
        //    _isPlaying = await PlayOpening();
        //}

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Tela1_Mapa));
            
        }

        private async void PlayOpening()
        {
            
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");

            Windows.Storage.StorageFolder soundsAndVideos = await folder.GetFolderAsync("sounds_videos");
            Windows.Storage.StorageFile file = await soundsAndVideos.GetFileAsync(@"Intro Template.mp4");

            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            mysong.AutoPlay = true;
            mysong.Volume = 100;

            mysong.Play();

            await Task.Delay(22800);
            MainCanvas.Children.Remove(mysong);
            Start_Button.Opacity = 100;
        }

    }
}
