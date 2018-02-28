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
            if (PodeAndar(posX, posY))
                return new Item();
            else
                return null;
        }

         public int Metrica(float tamX , float tamY, int fator = 5, float sizeCanvas = 1000) //CALCULO PARA QUANTIDADE DE QUADRADOS NO MAPA
        {
            return 0;
        }

        public Mapa InciarMapa()//iniciar o back do mapa
        {
            Mapa mapa = new Mapa();
            //logica de criacao do mapa
            return mapa;
        }

        

    }
}
