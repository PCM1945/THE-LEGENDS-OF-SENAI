using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class Jogador 
    {
        public Int64 Gold { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public List<Item.Item> Inventario { get; set; }//Iobservable collection
       // public IObservable<Item.Item> Inventario { get; set; }//Iobservable collection
        public int VidaCastelo { get; set; }
        public List<Personagem> Personagens { get; set; }
        public List<Castelo> Castelos {get; set;}
        public int Turno_movimento { get; set; }
        public int GoldTurno { get; set; }
        public int QntdMinas { get; set; }
        public Jogador()
        {
            Gold = 100;
            Castelos = new List<Castelo>();
            Personagens = new List<Personagem>();
            Inventario = new List<Item.Item>();
            VidaCastelo = 100;
            GoldTurno = 10 + (50 * QntdMinas);
        }

        public void ResetarPerson()
        {
            foreach (Personagem person in Personagens)
            {
                person.MovUsados = person.MovRange;
                person.Imagem.Opacity = 1;
                person.VidaAtual -= 10;
            }
        }
    }
}
