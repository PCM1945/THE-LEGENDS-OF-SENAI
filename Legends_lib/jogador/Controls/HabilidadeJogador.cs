using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class HabilidadeJogador
    {
        private const int MaxInvSize = 8;

        public static List<Habilidade> ListaHabilidadesJogador = new List<Habilidade>() 
        {
            new Habilidade{
                CustoGold = 100,
                Efeitos = new List<string>() { "AUMENTA O HP" },
                NivelHabilidade = 1,
                Nome = "BOOST DE HP",
                Status = true,
                Tipo = TipoHabilidade.Passiva
            },
            new Habilidade{
                CustoGold = 100,
                Efeitos = new List<string>() { "AUMENTA O DANO" },
                NivelHabilidade = 1,
                Nome = "BOOST DE DANO",
                Status = true,
                Tipo = TipoHabilidade.Passiva
            }

        };

        public void MudaNivelHabilidade(Jogador j, Habilidade habilidadeSelecionada, char activity) 
        {
            switch (activity)
            {
                case '+':
                    if(j.Gold >= habilidadeSelecionada.CustoGold)
                    {
                        j.Gold -= habilidadeSelecionada.CustoGold;
                        habilidadeSelecionada.NivelHabilidade += 1;
                        habilidadeSelecionada.CustoGold *= habilidadeSelecionada.NivelHabilidade; // CUSTO DE GOLD MULTIPLICA PELO NIVEL DA HABILIDADE, INICIA EM 100, NIVEL 2 = 200, NIVEL 3 = 400, NIVEL 4 = 1200...
                        habilidadeSelecionada.Status = true;
                        if (habilidadeSelecionada.Nome.Equals(ListaHabilidadesJogador[0].Nome))
                        {
                            j.VidaCastelo += 50;
                            foreach (var p in j.Personagens)
                            {
                                p.VidaMax += 20;
                                p.VidaAtual += 20;
                            }
                        }
                        else if (habilidadeSelecionada.Nome.Equals(ListaHabilidadesJogador[1].Nome))
                        {
                            foreach(var p in j.Personagens)
                            {
                                p.Atq += 5;
                                p.AtqRange += 1;
                            }
                        }
                    }
                    break;
            }
        }

        /** turno  será contado no jogo*/
        public int ContaTurno(Jogador j)
        {
            return j.Turno_movimento += 1;
        }

        public string GanhaGold(Jogador j, Personagem enemy)
        {
            j.Gold = enemy.Custo_Gold; //EXPERIÊNCIA DO OPONENTE É ADQUIRIDA PELO JOGADOR
                                               // INIMIGO CARREGA EXPERIÊNCIA EM SEUS ATRIBUTOS
            return "Adquiriu " + enemy.Custo_Gold;
        }

        public string GanhaItem(Jogador j, Item.Item i, Casa c)
        {
            if(j.Inventario.Count < MaxInvSize)
            {
                j.Inventario.Add(i);
                c.Item = null;
                return "Adquiriu " + i.Nome;
            }
            else
            {
                return "Inventário cheio";
            }
        }
    }
}
