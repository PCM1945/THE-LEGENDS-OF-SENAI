using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class MainMapControl
    {
        public const int DimX = 20;
        public const int DimY = 20;
        private const int ProbilidadeItem = 30;

        public List<int[]> CasasNaoAndaveis = new List<int[]>() {
        new int[2] { 0,9}, new int[2] { 2,9},new int[2] { 2,10},new int[2] { 4,10},new int[2] { 4,9},
        new int[2] { 5,9}, new int[2] { 6,9},new int[2] { 6,8},new int[2] { 7,8},new int[2] { 9,8},
        new int[2] { 9,9}, new int[2] { 10,9},new int[2] { 12,9},new int[2] { 12,8},new int[2] { 14,8},
        new int[2] { 15,8}, new int[2] { 15,9},new int[2] { 16,9},new int[2] { 18,9},new int[2] { 19,9}
        };

        public List<Item.Item> Itens = //LISTA DE ITENS DISPONÍVEIS PARA SEREM COLOCADOS NA CASA
            new List<Item.Item>() {
                /** para a primeira entrega manter apenas um item não utilizavel */
               // new Item.Item { Descricao = "DESCRIÇÃO 1", Nome = "NOME 1", Tipo = EItens.Consumivel},
               // new Item.Item { Descricao = "DESCRIÇÃO 2", Nome = "NOME 2", Tipo = EItens.Equipavel},
                 new Item.Item { Descricao = "Não Utilizável", Nome = "PEDRA", Tipo = EItens.NaoUtilizavel, UrlImage="ms-appx:///Assets/itens/pedra.png"},
            };


        private  bool PodeAndar(int posX, int posY, Mapa mapa)
        {
            return mapa.casa[posX,posY].Andavel;
            //return true;
        }//checar se a casa pode ser ocupada Na geracao


        private Item.Item GeraItem(int posX, int posY, Mapa mapa, int valorSorteado)
        {
            if (PodeAndar(posX, posY, mapa))
            {
               // return new Item.Item { Descricao = "Não Utilizável", Nome = "PEDRA", Tipo = EItens.NaoUtilizavel, UrlImage = "ms-appx:///Assets/itens/pedra.png" };
               if(valorSorteado == 2)
                    return new Item.Item { Descricao = "Não Utilizável", Nome = "PEDRA", Tipo = EItens.NaoUtilizavel, UrlImage = "ms-appx:///Assets/itens/pedra.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else if (valorSorteado == 3)
                    return new Item.Item { Descricao = "Recebe Dinheiro Ao Pegar", Nome = "DIAMANTE", Tipo = EItens.Gold, UrlImage = "ms-appx:///Assets/itens/minerais/diamante.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
               else if (valorSorteado == 4 || valorSorteado == 5)
                    return new Item.Item { Descricao = "Recebe Dinheiro Ao Pegar", Nome = "RUBI", Tipo = EItens.Gold, UrlImage = "ms-appx:///Assets/itens/minerais/rubi.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else if (valorSorteado == 6 || valorSorteado == 7)
                    return new Item.Item { Descricao = "Recebe Dinheiro Ao Pegar", Nome = "OURO", Tipo = EItens.Gold, UrlImage = "ms-appx:///Assets/itens/minerais/ouro.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else if (valorSorteado == 8)
                    return new Item.Item { Descricao = "POÇÃO", Nome = "POÇÃO", Tipo = EItens.Consumivel, UrlImage = "ms-appx:///Assets/itens/pocoes/poção_att+10.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else if (valorSorteado == 9 || valorSorteado == 10)
                    return new Item.Item { Descricao = "POÇÃO", Nome = "POÇÃO", Tipo = EItens.Consumivel, UrlImage = "ms-appx:///Assets/itens/pocoes/poção_def+10.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else if(valorSorteado%2 == 0)
                    return new Item.Item { Descricao = "Poção", Nome = "POÇÃO", Tipo = EItens.Consumivel, UrlImage = "ms-appx:///Assets/itens/pocoes/poção_att+5.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
                else
                    return new Item.Item { Descricao = "Poção", Nome = "POÇÃO", Tipo = EItens.Consumivel, UrlImage = "ms-appx:///Assets/itens/pocoes/poção_def+5.png" };//DEVE SER ALTERADO QUANDO TROCAR A COLEÇÃO
            }
            else
                return null;
        }

        private bool ProbabilidadeItem(Random rnd)
        {
            bool gera = false;
            int chance = rnd.Next(0, 100);

            if (chance <= ProbilidadeItem)
                gera = true;

            return gera;
        }

        public double MetricaX(int CasaAtual, double sizeCanvasX, double fator = 5) //CALCULO PARA O TAMANHO DAS CASAS NO MAPA(CANVAS) 
                                                                                    //E CALCULO DA POSIÇÃO 'X' RELATIVA NO CANVAS
        {
            CasaAtual = ObjetoDeJogo.DimXCasa;
            double tam_canvas_casa = sizeCanvasX / fator;
            double cordX = tam_canvas_casa * CasaAtual /*controllerX * tam_canvas_casa*/;
            return cordX;
        }

        public double MetricaY(int CasaAtual, double sizeCanvasY, double fator = 5)//CALCULO PARA O TAMANHO DAS CASAS NO MAPA(CANVAS) 
                                                                                   //E CALCULO DA POSIÇÃO 'Y' RELATIVA NO CANVAS
        {
            CasaAtual = ObjetoDeJogo.DimYCasa;
            double tam_canvas_casa = sizeCanvasY / fator;
            double cordY = tam_canvas_casa * CasaAtual;
            return cordY;
        }


        public Mapa InciarMapa()//iniciar o back do mapa
        {
            Mapa mapa = new Mapa();
            GerarCasas(mapa);
          
           
            //Random rnd = new Random();//utilizar o rnd ao criar um item no mapa
            return mapa;

        }

        private void GerarCasas(Mapa mapa)
        {
            foreach (int[] casa in CasasNaoAndaveis){
                Debug.WriteLine(" "+casa[0] + "  " + casa[1]);
            }
            Random valorSorteado = new Random();
            for (int x = 0; x < DimX; x++)
            {
                for (int y = 0; y < DimY; y++)
                {
                  
                    mapa.casa[x,y] = new Casa( x, y);
                    EhAdavel(mapa.casa[x,y],CasasNaoAndaveis);
                    GeraItemNaCasa(x, y, mapa,valorSorteado);
                }
            }

         
        }

        private void EhAdavel(Casa casa, List<int[]> lista)
        {
            int x = casa.PosX;
            int y = casa.PosY;
            foreach (int[] cord in lista)
            {
                if(y == cord[0] && x == cord[1])
                {
                    Debug.WriteLine("FALSEE");
                    casa.Andavel = false;
                    return;
                }
            }
            

        }

        public void GeraItemNaCasa(int x, int y, Mapa map, Random valorSorteado)
        {

            ///var valorSorteado = new Random().Next(0, 100);
            int VS = valorSorteado.Next(0, 100);
            if ( VS <= 10)
           // if ((valorSorteado < 35 &&valorSorteado>20 ) || (valorSorteado < 80 && valorSorteado > 60))
            {
                if(!((x==1 && y==7 ) || (x==1 && y==8) || (x == 2 && y == 7) || (x == 2 && y == 8)) &&
                    !((x == 17 && y == 7) || (x == 17 && y == 8) || (x == 18 && y == 7) || (x == 18 && y == 8)))
                {
                    map.casa[x, y].Item = GeraItem(x, y, map, VS);
                }
            }
        }
    }
}
