using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class Jogador 
    {
        public String Nome;
        public Int64 Gold { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        //    public List<Item.Item> Inventario { get; set; }//Iobservable collection
        public  ObservableCollection<Item.Item> Inventario { get; set; }
        // public IObservable<Item.Item> Inventario { get; set; }//Iobservable collection
        public int VidaCastelo { get; set; }
        public List<Personagem> Personagens { get; set; }
        public List<Castelo> Castelos {get; set;}
        public int Turno_movimento { get; set; }
        public int GoldTurno { get; set; }
        public String Aligment;//Identificador da equipe dele
       
        public Jogador(String nome,String Alig)
        {
            Nome = nome;
            Gold = 500;
            Castelos = new List<Castelo>();
            Personagens = new List<Personagem>();
            Inventario = new ObservableCollection<Item.Item> ();
            VidaCastelo = 100;
            GoldTurno = 10;
            Aligment = Alig;
            
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
