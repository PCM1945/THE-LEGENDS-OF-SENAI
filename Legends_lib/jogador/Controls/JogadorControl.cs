using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ClassePOG para facilitar o acesso do jogador em outras telas 
 * sem precisar passar no parâmetro 
 * 
 * */
namespace Legends_lib.jogador.Controls
{
    public static class JogadorControl
    {
        private static List<Jogador> listaJogadores = new List<Jogador>();

        public static void AddPlayer(Jogador jogador)
        {
            listaJogadores.Add(jogador);
        }

        public static List<Jogador> getPlayerList()
        {
            return listaJogadores;
        }

        public static Jogador GetJogadorByKey(int index)
        {
            return listaJogadores.ElementAt(index);
        }

    }
}
