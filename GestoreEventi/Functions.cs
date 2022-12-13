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
    }
}
