using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.maps.mapa_geral.Controls
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


        public int Metrica(float tamX , float tamY, int fator = 5, float sizeCanvas = 1000) //CALCULO PARA QUANTIDADE DE QUADRADOS NO MAPA
        {
            return 0;
        }

        public Mapa InciarMapa()//iniciar o back do mapa
        {

            Mapa mapa = new Mapa();
            Random rnd = new Random();//utilizar o rnd ao criar um item no mapa
            //logica de criacao do mapa
            return mapa;
        }

        

    }
}
