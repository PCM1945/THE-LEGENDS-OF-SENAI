using Legends_lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Legends_lib.maps.mapa_geral.Controls;
using Legends_lib.Item;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI.Xaml.Navigation;
using Legends_lib.jogador.Controls;
using Legends_lib.Batalha;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {
        
        public Mapa Map = new MainMapControl().InciarMapa();
        public Personagem selecionado;
        public bool selecionou;
        Queue<Jogador> FilaJogador;
        Jogador JogadorAtual;
        Casa casaSelecionado;
        private String RecrutSelec { get; set; }
        public List<Item> Itens = //LISTA DE ITENS DISPONÍVEIS PARA SEREM COLOCADOS NA CASA
            new List<Item>() {
                /** para a primeira entrega manter apenas um item não utilizavel */
               // new Item.Item { Descricao = "DESCRIÇÃO 1", Nome = "NOME 1", Tipo = EItens.Consumivel},
               // new Item.Item { Descricao = "DESCRIÇÃO 2", Nome = "NOME 2", Tipo = EItens.Equipavel},
                 new Item { Descricao = "Não utilizável", Nome = "PEDRA", Tipo = EItens.NaoUtilizavel, UrlImage = "ms-appx:///Assets/itens/pedra.png"},
            };

        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
        public Tela1_Mapa()
        {
            selecionou = false;
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            pointers = new Dictionary<uint, Pointer>();
            FilaJogador = new Queue<Jogador>();
            FilaJogador.Enqueue(new Jogador());
            FilaJogador.Enqueue(new Jogador());
            JogadorAtual = FilaJogador.Dequeue();
            foreach(Jogador a in FilaJogador)
            {
                JogadorControl.AddPlayer(a);
            }
           // BtnPlayWav();
            IniciarCastelos();
            PosicionarItens();

            //Setando o data biding


            Invetario_list.ItemsSource = JogadorAtual.Inventario;
            Player_info.ItemsSource = new List<Jogador>() { JogadorAtual };

           
        }
        private async void BtnPlayWav()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("MusicaMain.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
           
           mysong.Volume = 100;
            mysong.Play();
        }
        private void IniciarCastelos()
        {
            Debug.WriteLine("Iniciando Castelos");

            JogadorAtual.Castelos.Add(new Castelo(1,7));
            JogadorAtual.Castelos.Add(new Castelo(2,7));
            JogadorAtual.Castelos.Add(new Castelo(1,8));
            JogadorAtual.Castelos.Add(new Castelo(2,8));

            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();

            JogadorAtual.Castelos.Add(new Castelo(17,7));
            JogadorAtual.Castelos.Add(new Castelo(18,7));
            JogadorAtual.Castelos.Add(new Castelo(17,8));
            JogadorAtual.Castelos.Add(new Castelo(18,8));

            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();
        }

        private void PosicionarItens()
        {
            //Debug.WriteLine("ANTES DO FOREACH");
            foreach (Casa c in this.Map.casa)
            {
                //Debug.WriteLine("ITEM: (DENTRO DO FOREACH)" + c.Item.Nome);
                if (c.Item != null)
                {
                    Debug.WriteLine("DENTRO DO IF DO FOREACH");
                    c.Item.CriarImagem();
                    mapa.Children.Add(c.Item.Imagem);
                    Canvas.SetLeft(c.Item.Imagem, c.Item.PosX * 40);//posiciona X
                    Canvas.SetTop(c.Item.Imagem, c.Item.PosY * 40);//posiciona Y
                }
            }
        }
      

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            e.Handled = true;

            PointerPoint ptrPt = e.GetCurrentPoint(mapa);
          /*  Debug.WriteLine("pos X: " + ptrPt.Position.X);

            Debug.WriteLine("pos Y: " + ptrPt.Position.Y);
            Debug.WriteLine("POSICAO NA MATRIZ");
            Debug.WriteLine(calcCasa.getPosCasa((int)ptrPt.Position.X));
            Debug.WriteLine(calcCasa.getPosCasa((int)ptrPt.Position.Y));*/
           for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    if (Map.casa[i, j].Personagem != null)
                    {
                        Debug.WriteLine("personagem NA MATRIZ");
                        Debug.WriteLine(i);
                        Debug.WriteLine(j);
                    }
                }
            }
            if (!selecionou)//LEMBRAR DE TRATAR CLICKS FORA DA TELA!!!!!!!!!!!!!!!ATENÇÃO!!!!!!!!!!!IMPORTANTE!!!!
            {
                Debug.WriteLine("entrou");
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null)
                {
                    selecionou = true;
                    selecionado = Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem;
                    casaSelecionado = Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)];
                }
            }
            else
            {
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem == null && 
                    Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Andavel   &&
                    PodeMover(calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)))
                {
                    Debug.WriteLine(Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Andavel);
                    selecionou = false;
                    //Adiciona o personagem no back atual
                    Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem=selecionado;
                    //Remove o personagem do back na pos antiga
                   Map.casa[selecionado.PosX, selecionado.PosY].Personagem = null;
                    //Muda as cordenadas no Jogador
                    selecionado.PosX = calcCasa.getPosCasa((int)ptrPt.Position.X);
                    selecionado.PosY = calcCasa.getPosCasa((int)ptrPt.Position.Y);
                    //Reposiciona ele no canvas (passando a imagem dele, e a posicao relativa)
                    Canvas.SetLeft(selecionado.Imagem, (calcCasa.getPosCasa((int)ptrPt.Position.X)) * 40);
                    Canvas.SetTop(selecionado.Imagem, (calcCasa.getPosCasa((int)ptrPt.Position.Y)) * 40);
                    selecionado = null;
                    casaSelecionado.Personagem = null;
                    selecionado.turno_person = true;//passa e ser 'true', então o personagem não anda mais no turno
                }
                else if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null &&
                    !JogadorAtual.Personagens.Contains(Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem))
                {



                    ControleBatalha.ordenarBatalha(selecionado, Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem);
                    this.Frame.Navigate(typeof(BlankPage1));
                    selecionou = false;
                    ControleBatalha.vencedor = 1;
                    if (ControleBatalha.vencedor == 1)//colocar oq acontece quando a batalha termina- ta apagando pela lista de jogadores, mas lembrar que se der bug é pq ele fica na casa(n sei como ta esse tratamento de imagem, caso seja buscado a cada turno coloque um 'OK' ao lado desse comentario e me avise);
                    {
                        for(int aqd = 0; aqd < JogadorAtual.Personagens.Count; aqd++)
                        {
                            if (JogadorAtual.Personagens[aqd] == selecionado)
                            {
                                JogadorAtual.Personagens.Remove(JogadorAtual.Personagens[aqd]);
                                Debug.WriteLine("sholaaaaaaaaaa");
                            }

                        }

                        /*foreach(Personagem a in JogadorAtual.Personagens)
                        {
                            if (a == selecionado)
                            {
                               
                            }
                        }*/

                    }
                    else
                    {

                    }

                }
              
               
            }


        }
        /// <summary>
        /// Checa se o personagem eh do jogador atual e se ele tem Range para o movimento
        /// </summary>
        /// <returns></returns>
        private bool PodeMover(int cordx,int cordy) {
            Debug.WriteLine(JogadorAtual.Personagens.Contains(selecionado));
            return (JogadorAtual.Personagens.Contains(selecionado)  && ((Math.Abs(selecionado.PosX - cordx) <= (selecionado.MovRange)
                && (Math.Abs(selecionado.PosY - cordy) <= (selecionado.MovRange) ))));
        }

        private void Button_Mudar_Turno(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            for(int TamLista = 0; TamLista<JogadorAtual.Personagens.Count; TamLista++)
            {
                JogadorAtual.Personagens[TamLista].turno_person = false;//torna 'false' o turno de cada personagem
            }
            JogadorAtual.ResetarPerson();
            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();
            Invetario_list.ItemsSource = JogadorAtual.Inventario;
            JogadorAtual.Gold += JogadorAtual.GoldTurno;
            
        }

        private void Inventario_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Inventario.Opacity != 0) {
                Inventario.Opacity = 0;
            }
            else
            {
                Inventario.Opacity = 100;
            }
           
        }
        private void Recrutamento(object sender, RoutedEventArgs e)
        {


            foreach (Castelo cast in JogadorAtual.Castelos) {
              //Acessa as casas cujo o jogador pode add persongens
                if (Map.casa[cast.Cordx, cast.Cordy].Personagem == null)
                {//chca se a casa esta vazia
                    Personagem person = null;
                    //Selecionar o personagem, usando o Radio Box
                    switch (RecrutSelec)
                    {
                        case "Warrior":                            
                             person = new Guerreiro(cast.Cordx, cast.Cordy);
                            break;
                          
                    }

                    if (person != null) { 
                    person.CriarImagem();//Utiliza os metodos do Xaml (inicia o bitmap da imagem && coloca ele na imagem)
                    mapa.Children.Add(person.Imagem);//Adiciona no canvas
                    Canvas.SetLeft(person.Imagem, cast.Cordx * 40);//posiciona
                    Canvas.SetTop(person.Imagem, cast.Cordy * 40);
                    Map.casa[cast.Cordx, cast.Cordy].Personagem = person;//add no back
                    JogadorAtual.Personagens.Add(person);//add na lista do jogador
                    break;
                    }
                }
               
            }
        }

        private void ObtemItem(object sender, RoutedEventArgs e)
        {
            foreach(Casa c in this.Map.casa)
            {//
                if ((selecionado != null) && (c.PosX == selecionado.PosX && c.PosY == selecionado.PosY)  && JogadorAtual.Inventario.Count < 8) //O JOGADOR SÓ OBTEM O ITEM SE ESTIVER NA MESMA CASA QUE ELE
                {
                    JogadorAtual.Inventario.Add(Itens[0]); //NECESSÁRIO REFAZER PARA "DINAMICIDADE"
                                                           /*Invetario_list.ItemsSource = JogadorAtual.Inventario;*/
                  //  Debug.WriteLine("ITEM");
                  //  Debug.WriteLine(c.Item.Nome);
                    //c.Item.Imagem = null;   
                    c.Item = null;
                    return;
                }
            }
        }

       
        
        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null)
            {
                RecrutSelec = radio.Tag.ToString();

            }
            
        }
      

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Stats_Screen), JogadorAtual);
        }
    }
    
}
