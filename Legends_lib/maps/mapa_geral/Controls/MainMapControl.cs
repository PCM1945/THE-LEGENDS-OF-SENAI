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

        private bool PodeAndar(int posX, int posY,Mapa mapa)
        {
            return mapa.Casa.ElementAt(posX).ElementAt(posY).Andavel;
        }//checar se a casa pode ser ocupada Na geracao


         private Item GeraItem(int posX, int posY, Mapa mapa)
        {
            if (PodeAndar(posX, posY,mapa))
                return new Item();
            else
                return null;
        }

        private bool ProbabilidadeItem(Random rnd)
        {
            bool gera=false;
            int chance = rnd.Next(0,100);

            if (chance <= ProbilidadeItem)
                gera = true;
            
            return gera;
        }

        public double MetricaX(int CasaAtual ,double sizeCanvasX, double fator = 5) //CALCULO PARA O TAMANHO DAS CASAS NO MAPA(CANVAS) 
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


        public  Mapa InciarMapa()//iniciar o back do mapa
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
            for(int x=0; x < mapa.DimX; x++)
            {
                for (int y = 0; y < mapa.DimY; y++)
                {
                    mapa.Casa[x][y] = new Casa(true, x, y);
                }
            }
            

   
        }

    }
}
