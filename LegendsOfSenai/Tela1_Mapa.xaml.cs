﻿using Legends_lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Legends_lib.maps.mapa_geral.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Legends_lib.jogador.Controls;
using Legends_lib.Batalha;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using System.Linq;
using System.Threading.Tasks;
using Legends_lib.personagem;

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
        public int ContagemDeTurno = 1;
        public bool TrocaTurno = false;
        Casa casaSelecionado;
        List<Rectangle> Caminho;
        Rectangle UltimoRecSelecionado;
        private String RecrutSelec { get; set; }
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;

        public Tela1_Mapa()
        {
            selecionou = false;
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
          
            FilaJogador = new Queue<Jogador>();
            FilaJogador.Enqueue(new Jogador("Jogador 1","Order"));
            FilaJogador.Enqueue(new Jogador("Jogador 2","Chaos"));
            JogadorAtual = FilaJogador.Dequeue();
            foreach(Jogador a in FilaJogador)
            {
                JogadorControl.AddPlayer(a);
            }
            //apagaraqui
            BtnPlayWav();
            IniciarCastelos();
            PosicionarItens();

            Invetario_list.ItemsSource = JogadorAtual.Inventario;
           
            Caminho = new List<Rectangle>();
            JogadorAtualTxt.Text = JogadorAtual.Nome;

        }

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e) { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private async void BtnPlayWav()
        {
            MediaElement mysong = new MediaElement();
            
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");

            Windows.Storage.StorageFolder soundsAndVideos = await folder.GetFolderAsync("sounds_videos");
            Windows.Storage.StorageFile file = await soundsAndVideos.GetFileAsync("ingame_2.mp3");

            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            mysong.IsLooping = true;
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
                    //Debug.WriteLine("DENTRO DO IF DO FOREACH");
                    c.Item.CriarImagem();
                    mapa.Children.Add(c.Item.Imagem);
                    Canvas.SetLeft(c.Item.Imagem, c.PosX * 40);//posiciona X
                    Canvas.SetTop(c.Item.Imagem, c.PosY * 40);//posiciona Y
                }
            }
        }


        
        /// <summary>
        /// Checa se o personagem eh do jogador atual e se ele tem Range para o movimento
        /// </summary>
        /// <returns></returns>
        private bool PodeMover(int cordx,int cordy) {
            if (selecionado.PodeMover)//verifica se o turno do personagem é 'true', se for, pode andar
            {
                Debug.WriteLine(JogadorAtual.Personagens.Contains(selecionado));
                return (JogadorAtual.Personagens.Contains(selecionado) && ((Math.Abs(selecionado.PosX - cordx) <= (selecionado.MovRange)
                    && (Math.Abs(selecionado.PosY - cordy) <= (selecionado.MovRange)))));
            }
            return false;
        }

        private bool EstruturaCastelo(object sender, int atq, int vida, Jogador jogadorAlvo)//função para ser chamada a hora do ataque caso o alvo seja o castelo
        {
            bool VitoriaJogo;
            jogadorAlvo.VidaCastelo = AtkController.Atacar(atq, vida, jogadorAlvo);
            VitoriaJogo = AtkController.Conquista(vida, jogadorAlvo);
            if (VitoriaJogo)
            {
                Debug.WriteLine("Castelo inimigo destruido! Vitória!");
                return true;
            }
            return false;
        }

        private void Button_Mudar_Turno(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (TrocaTurno)
            {
                ContagemDeTurno++;
                TrocaTurno = false;
            }
            else
                TrocaTurno = true;
            TxtTurno.Text = "Turno " + ContagemDeTurno;
            for(int numb = 0; numb < JogadorAtual.Personagens.Count; numb++)
            {
                JogadorAtual.Personagens[numb].PodeMover = true;//todos os personagems da lista tem o turno 'true'
              //  JogadorAtual.Personagens[numb].MovUsados = JogadorAtual.Personagens[numb].MovRange;
            }
            JogadorAtual.ResetarPerson();
            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();
            Invetario_list.ItemsSource = JogadorAtual.Inventario;
            selecionado = null;
            selecionou = false;
        

            JogadorAtual.Gold += JogadorAtual.GoldTurno;
            JogadorAtualTxt.Text = JogadorAtual.Nome;

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

        RadioButton radio;
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
                          /*  if (JogadorAtual.Gold < person.Custo_Gold)
                            {
                                radio.IsEnabled = false;
                            }
                            else
                            {*/ 
                            if(JogadorAtual.Aligment == "Order" ) {
                                
                                person = new Guerreiro(cast.Cordx, cast.Cordy);
                                
                            }
                            else if(JogadorAtual.Aligment == "Chaos")
                            {
                                person = new Esqueleto(cast.Cordx, cast.Cordy);
                                
                            }
                            // }
                            break;

                        case "Mage":

                            if (JogadorAtual.Aligment == "Order")
                            {

                                person = new Mago(cast.Cordx, cast.Cordy);

                            }
                            else if (JogadorAtual.Aligment == "Chaos")
                            {
                                person = new Necromancer(cast.Cordx, cast.Cordy);

                            }
                            
                            break;

                        case "Archer":

                            if (JogadorAtual.Aligment == "Order")
                            {

                                person = new Arqueiro(cast.Cordx, cast.Cordy);

                            }
                            else if (JogadorAtual.Aligment == "Chaos")
                            {
                                person = new Hunter(cast.Cordx, cast.Cordy);

                            }

                            break;

                    }
                    if (person != null) { 
                        if (JogadorAtual.Gold - person.Custo_Gold > 0)
                        JogadorAtual.Gold -= person.Custo_Gold;
                       else
                        person = null;//Checando se tem gold pra recrutar
                    }
                    if (person != null) { 
                    person.CriarImagem();//Utiliza os metodos do Xaml (inicia o bitmap da imagem && coloca ele na imagem)
                        person.PodeMover = false;
                        
                        person.Imagem.ContextFlyout = (FlyoutBase) this.Resources["PersonFly"];   
                        FlyoutBase.SetAttachedFlyout(person.Imagem, (FlyoutBase)this.Resources["PersonFly"]);
                        person.Imagem.Tapped += SelecionarPersonagem;
                        person.Imagem.RightTapped += SelecionarPersonagemRightTapped;        
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
            if (selecionado == null)
            {
                Debug.WriteLine("PERSONAGEM ESTA SAINDO NULO");
                return;
            }
            Casa c = Map.casa[selecionado.PosX, selecionado.PosY];
                
                if ((selecionado != null) && (c.Item!=null)  && JogadorAtual.Inventario.Count < 16) //O JOGADOR SÓ OBTEM O ITEM SE ESTIVER NA MESMA CASA QUE ELE
                {
                if (c.Item.Tipo == EItens.Gold )
                {
                    switch (c.Item.Nome)
                    {
                        case ("RUBI"):
                            JogadorAtual.Gold += 300;
                            JogadorAtual.GoldTurno += 20;
                            break;
                        case ("DIAMANTE"):
                            JogadorAtual.Gold += 200;
                            JogadorAtual.GoldTurno += 15;
                            break;
                        case ("OURO"):
                            JogadorAtual.Gold += 100;
                            JogadorAtual.GoldTurno += 10;
                            break;
                    }
                   
                }
                    JogadorAtual.Inventario.Add(c.Item); //NECESSÁRIO REFAZER PARA "DINAMICIDADE"
                  /*Invetario_list.ItemsSource = JogadorAtual.Inventario;*/
                  //  Debug.WriteLine("ITEM");
                  //  Debug.WriteLine(c.Item.Nome);
                  //  c.Item.Imagem = null;   
                  mapa.Children.Remove(c.Item.Imagem);
                    c.Item = null;
                
                selecionado = null;
                    return;
                }
            
        }

    
        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            radio = sender as RadioButton;
            if (radio != null)
            {
               
                RecrutSelec = radio.Tag.ToString();
               

            }
            
        }
      

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Stats_Screen), JogadorAtual);
        }

        private void SelecionarPersonagemRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Image Pers = sender as Image;
            if (JogadorAtual.Personagens.Contains(Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(Pers)), calcCasa.getPosCasa((int)Canvas.GetTop(Pers))].Personagem))
            {
                selecionado = Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(Pers)), calcCasa.getPosCasa((int)Canvas.GetTop(Pers))].Personagem;
            }
            else
            {
               // Pers.ContextFlyout.clos
            }
         }

        

        private void SelecionarPersonagem(object sender, TappedRoutedEventArgs e)
        {
            Caminho.Clear();

            Image Pers = sender as Image;
            if(selecionado != null)
            {
                RemoverGridMovimento();
                selecionado = null;
            }
            //Selecionando o personagem q vai se mover
            if(JogadorAtual.Personagens.Contains(Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(Pers)), calcCasa.getPosCasa((int)Canvas.GetTop(Pers))].Personagem))
            {

            
            selecionou = true;
            selecionado = Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(Pers)), calcCasa.getPosCasa((int)Canvas.GetTop(Pers))].Personagem;
            casaSelecionado = Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(Pers)), calcCasa.getPosCasa((int)Canvas.GetTop(Pers))];
                if (selecionado.PodeMover)//se o persongem nao tiver movido
                {
                    GerarGridMovimento();
                }
                else//caso ja tenha movido
                {
                    selecionado = null;
                    selecionou = false;
                    casaSelecionado = null;
                }
            
            }
        }

        private void GerarGridMovimento()
        {


            foreach (Casa casa in MovimentoController.CasasAndaveis(selecionado, Map))
            {
                Rectangle rec = new Rectangle();
                rec.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                rec.Width = ObjetoDeJogo.DimXCasa;
                rec.Height = ObjetoDeJogo.DimYCasa;
                rec.Opacity = 0.4;
                rec.AccessKey = "Yellow";
                rec.AllowFocusOnInteraction = true;
                rec.PointerEntered += MudarCorDoGrid;
                rec.Tapped += MoverPersonagem;
                rec.IsRightTapEnabled = true;
                rec.RightTapped += CancelarMovimento;

                mapa.Children.Add(rec);
                Canvas.SetLeft(rec,casa.PosX*40);
                Canvas.SetTop(rec, casa.PosY * 40);
                selecionado.GridMovimento.Add(rec);

                
            }
            //selecionado.

        }

      

        // Funcao para ver o caminho cuja o persongem vai fazer
        private void MudarCorDoGrid(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rec = sender as Rectangle;
            int posx = calcCasa.getPosCasa((int)Canvas.GetLeft(rec));
            int posy = calcCasa.getPosCasa((int)Canvas.GetTop(rec));
            if ((posx == calcCasa.getPosCasa((int)Canvas.GetLeft(selecionado.Imagem)) && posy == calcCasa.getPosCasa((int)Canvas.GetTop(selecionado.Imagem))) || Caminho.Count==0)
            {
                if(rec.AccessKey != "Red")
                {
                    rec.AccessKey = "Red";
                    rec.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                    UltimoRecSelecionado = rec;
                    Caminho.Add(rec);
                }
            }
            //checar se o retangulo esta em volta
            else if ((posx >= calcCasa.getPosCasa((int)Canvas.GetLeft(Caminho.Last()))-1 && 
                posx <= calcCasa.getPosCasa((int)Canvas.GetLeft(Caminho.Last())) + 1 && 
                posy >= calcCasa.getPosCasa((int)Canvas.GetTop(Caminho.Last())) - 1 &&
                posy <= calcCasa.getPosCasa((int)Canvas.GetTop(Caminho.Last())) + 1) ) { 
            if (rec.AccessKey != "Red" && selecionado.MovUsados > 0)
                { 

            rec.AccessKey = "Red"; 
            rec.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            UltimoRecSelecionado = rec;
             Caminho.Add(rec);
                    selecionado.MovUsados--;
                }
            else{

                UltimoRecSelecionado.AccessKey = "Yellow";
                UltimoRecSelecionado.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                UltimoRecSelecionado = rec;
                    Caminho.Remove(Caminho.Last());
                    selecionado.MovUsados++;
                }
            //   throw new NotImplementedException();
        }
        }



        private void RemoverGridMovimento()
        {
            if (selecionado != null) { 
            foreach (Rectangle rec in selecionado.GridMovimento)
            {
                mapa.Children.Remove(rec);
            }

            selecionado.GridMovimento.Clear();
            }
        }

        private async void MoverPersonagem(object sender, TappedRoutedEventArgs e)
        {
            Rectangle rec = sender as Rectangle;
            if (rec.AccessKey == "Yellow")
                return;
            RemoverGridMovimento();
            MovimentoController.PersonagemMoveu(selecionado);

            //Adiciona o personagem no back atual
            //posição final back
            Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(rec)), calcCasa.getPosCasa((int)Canvas.GetTop(rec))].Personagem = selecionado;
            //Remove o personagem do back na pos antiga
            Map.casa[selecionado.PosX, selecionado.PosY].Personagem = null;
            //Muda as cordenadas no Jogador
            selecionado.PosX = calcCasa.getPosCasa((int)Canvas.GetLeft(rec));
            selecionado.PosY = calcCasa.getPosCasa((int)Canvas.GetTop(rec));
            //Reposiciona ele no canvas (passando a imagem dele, e a posicao relativa)
            //Map.casa[selecionado.PosX, selecionado.PosY].Personagem = selecionado;//POSIÇÃO 
            List<Rectangle> CaminhoCpy = new List<Rectangle>();
            Personagem selecionadoCpy = selecionado;
            Casa casaSelecionadoCpy = casaSelecionado;
            selecionado = null;
            selecionou = false;
            casaSelecionado = null;

            foreach (Rectangle cas in Caminho)
            {
                CaminhoCpy.Add(cas);
            }

            RemoverGridMovimento();
            Caminho.Clear();

            foreach (Rectangle cas in CaminhoCpy)

            {
                //TODA A PARTE DA ANIMACAO EM TESE VEM AQUI
                //posição final 
               
                    Canvas.SetLeft(selecionadoCpy.Imagem, (calcCasa.getPosCasa((int)Canvas.GetLeft(cas))) * 40);
                    Canvas.SetTop(selecionadoCpy.Imagem, (calcCasa.getPosCasa((int)Canvas.GetTop(cas))) * 40);
                
                await Task.Delay(250);
            }


            
           //     Canvas.SetLeft(selecionado.Imagem, (calcCasa.getPosCasa((int)Canvas.GetLeft(rec))) * 40);
             //   Canvas.SetTop(selecionado.Imagem, (calcCasa.getPosCasa((int)Canvas.GetTop(rec))) * 40);
          
          

           
            selecionadoCpy.Imagem.Opacity = 0.7;
            selecionadoCpy.PodeMover = false; 
          //  selecionado = null;
          
            if (casaSelecionadoCpy!=null)
            {
                casaSelecionadoCpy.Personagem = null;
            }
            casaSelecionadoCpy = null;
          
        }

        private void CancelarMovimento(object sender, RightTappedRoutedEventArgs e)
        {
            Caminho.Clear();
            RemoverGridMovimento();
            selecionado.MovUsados = selecionado.MovRange;
            selecionado = null;
            selecionou = false;
            casaSelecionado = null;
        }

        private void GerarGridAtq(object sender, RoutedEventArgs e)
        {
            if(selecionado.PodeAtacar == false)
            {
                return;
            }

            foreach (Casa casa in ControleBatalha.PersonAtacaveis(selecionado,JogadorAtual, Map,FilaJogador.First().Castelos))
            {
                bool Iscastle = false;
                
                foreach(Castelo castelo in FilaJogador.First().Castelos)
                {
                    if(casa.PosX == castelo.Cordx && casa.PosY == castelo.Cordy)
                    {


                        Rectangle rec1 = new Rectangle();
                        rec1.Fill = new SolidColorBrush(Windows.UI.Colors.Orange);
                        rec1.Width = ObjetoDeJogo.DimXCasa;
                        rec1.Height = ObjetoDeJogo.DimYCasa;
                        rec1.Opacity = 0.4;
                        rec1.Tapped += AtacarCastelo;
                        rec1.IsRightTapEnabled = true;
                        rec1.RightTapped += CancelarAtaque;
                        mapa.Children.Add(rec1);
                        Canvas.SetLeft(rec1, casa.PosX * 40);
                        Canvas.SetTop(rec1, casa.PosY * 40);
                        selecionado.GridMovimento.Add(rec1);
                        Iscastle = true;
                    }
                }

                if (!Iscastle){ 
                Rectangle rec = new Rectangle();
                rec.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                rec.Width = ObjetoDeJogo.DimXCasa;
                rec.Height = ObjetoDeJogo.DimYCasa;
                rec.Opacity = 0.4;
                rec.Tapped += AtacarPersonagem;
                rec.IsRightTapEnabled = true;
                rec.RightTapped += CancelarAtaque;
                mapa.Children.Add(rec);
                Canvas.SetLeft(rec, casa.PosX * 40);
                Canvas.SetTop(rec, casa.PosY * 40);
                selecionado.GridMovimento.Add(rec);
                }
                Iscastle =false;
            }

            return;
        }

        private void AtacarCastelo(object sender, TappedRoutedEventArgs e)
        {
            Rectangle rec = sender as Rectangle;
            if (selecionado.PodeAtacar) { 
            FilaJogador.First().VidaCastelo -= selecionado.Atq ;
               selecionado.PodeAtacar = false;
            }
            if (FilaJogador.First().Aligment == "Order")
            {
                GoodBar.Value = FilaJogador.First().VidaCastelo;
            }
            else
            {
                BadBar.Value = FilaJogador.First().VidaCastelo;
            }
            if(FilaJogador.First().VidaCastelo <= 0)
            {
                this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
                this.Frame.Navigate(typeof(MainPage));
            }
            RemoverGridMovimento();
            selecionado = null;
        }


        private void AtacarPersonagem(object sender, TappedRoutedEventArgs e)
        {
            Rectangle rec = sender as Rectangle;
            ControleBatalha.ordenarBatalha(selecionado, Map.casa[calcCasa.getPosCasa((int)Canvas.GetLeft(rec)), calcCasa.getPosCasa((int)Canvas.GetTop(rec))].Personagem);
            this.Frame.Navigate(typeof(BlankPage1), mapa);
            HabilidadeJogador Hab=new HabilidadeJogador();
            if(ControleBatalha.BuscarVencedor() == 1)
            {
                JogadorAtual.Gold += 100;
            }
            else if(ControleBatalha.BuscarVencedor() == 2)
            {
                FilaJogador.First().Gold += 100;
            }
            RemoverGridMovimento();
           /* if (ControleBatalha.vencedor == 1)
            {
                //Hab.GanhaGold(JogadorAtual, ControleBatalha.personagem2);
                JogadorAtual.Gold += 100;

            }
            else if (ControleBatalha.vencedor == 2)
            {
                //Hab.GanhaGold(FilaJogador.First(), ControleBatalha.personagem1);
                FilaJogador.First().Gold += 100;
                
            }*/
            

        }

        private void CancelarAtaque(object sender, RightTappedRoutedEventArgs e)
        {
            
            RemoverGridMovimento();
            selecionado = null;
            selecionou = false;
            casaSelecionado = null;
        }

    }


    }


    
    

