using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi {
    public class ProgrammaEventi {
        string Titolo;
        List<Evento> eventi;

        public ProgrammaEventi(string Titolo) {
            this.Titolo= Titolo;
            eventi= new List<Evento>();
        }

        public void AddEvento(Evento evento) {
            eventi.Add(evento);
        }
        public List<Evento> GetListaEventi() {
            return eventi;
        }

        public int EventiCount() {
            return eventi.Count;
        }
        public void EmptyList() {
            eventi.Clear();
        }

        public void GetEventi() {
            Console.WriteLine(Titolo + ":");
            for(int i=0;i<EventiCount();i++) {
                int posizione = i+1;
                Console.WriteLine(posizione+ "° Evento " +eventi[i]);
            }
            Console.WriteLine() ;
        }
    }
}
