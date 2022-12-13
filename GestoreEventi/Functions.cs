using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi {
    static class Functions {
        public static void StampaListaEvento(List<Evento> lista) {
            foreach (var evento in lista) {
                Console.WriteLine(evento);
            }
            Console.WriteLine();
        }
        public static int FiltroListaNome(List<Evento> lista,string input) {
            foreach (var Evento in lista) {
                if (Evento.GetTitolo() == input) {
                    return lista.IndexOf(Evento);
                }
            }return -1;
        }
    }
}
