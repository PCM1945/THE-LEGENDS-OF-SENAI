using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.maps.mapa_geral.Controls
{
    public class MainMapControl
    {
         private bool PodeAndar(int posX, int posY)
        {
            if (1 == 1)
                return true;
            else
                return false;
        }//checar se a casa pode ser ocupada Na geracao

         private Item GeraItem(int posX, int posY)
        {
            if (PodeAndar(posX, posY)==true)
                return new Item();
            else
                return null;
        }

         public float Metrica(int fator = 5, float sizeCanvas = 1000) //CALCULO PARA TAMANHO DAS CASAS NO MAPA
        {
            float size_canvas_casa = sizeCanvas / fator;

            return size_canvas_casa;
        }

        public Mapa InciarMapa(float metrica)
        {
            Mapa mapa = new Mapa();
            //logica de criacao do mapa
            return mapa;
        }

        

    }
}
