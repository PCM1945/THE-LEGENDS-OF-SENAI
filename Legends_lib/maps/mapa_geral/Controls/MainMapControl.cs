using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class MainMapControl
    {
        private const int ProbilidadeItem = 30;

        public List<int[]> CasasNaoAndaveis = new List<int[]>() {
        new int[2] { 0,9}, new int[2] { 2,9},new int[2] { 2,10},new int[2] { 4,10},new int[2] { 4,9},
        new int[2] { 5,9}, new int[2] { 6,9},new int[2] { 6,8},new int[2] { 7,8},new int[2] { 9,8},
        new int[2] { 9,9}, new int[2] { 10,9},new int[2] { 12,9},new int[2] { 12,8},new int[2] { 14,8},
        new int[2] { 15,8}, new int[2] { 15,9},new int[2] { 16,9},new int[2] { 18,9},new int[2] { 19,9}
        };


        private bool PodeAndar(int posX, int posY, Mapa mapa)
        {
            return mapa.Casa.ElementAt(posX).ElementAt(posY).Andavel;
        }//checar se a casa pode ser ocupada Na geracao


        private Item GeraItem(int posX, int posY, Mapa mapa)
        {
            if (PodeAndar(posX, posY, mapa))
                return new Item();
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
            //Mapa mapa = new Mapa(); FALTA PEGAR AS DIMENSOES DE MAPA
            Random rnd = new Random();//utilizar o rnd ao criar um item no mapa
            //logica de criacao do mapa
            return mapa;

        }

        private void GerarCasas(Mapa mapa)
        {
            for (int x = 0; x < mapa.DimX; x++)
            {
                for (int y = 0; y < mapa.DimY; y++)
                {

                    mapa.Casa[x][y] = new Casa(EhAdavel(x, y, new List<int[]>()), x, y);
                }
            }



        }
        private bool EhAdavel(int x, int y, List<int[]> lista)
        {

            int[] coord = new int[2];
            coord[0] = y;
            coord[1] = x;
            return lista.Contains(coord);

        }

        private void TESTE()
        {
            CasasNaoAndaveis.Add(new int[2] { 1, 2 });
        }
    }
}
