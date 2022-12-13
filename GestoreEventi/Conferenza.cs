using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi {
    internal class Conferenza : Evento {
        private string relatore;
        private double prezzo;

        public Conferenza(string relatore, double prezzo, string titolo, string data, int CapienzaMax) : base(titolo, data, CapienzaMax) {
            this.relatore = relatore;
            this.prezzo = prezzo;
        }
        public void SetRelatore(string relatore) {
            if (string.IsNullOrEmpty(relatore)) {
                throw new Exception("Valore non valido");
            } else {
                this.relatore = relatore;
            }
        }
        public string GetRelatore() {
            return this.relatore;
        }
        public void SetPrezzo(double prezzo) {
            if (prezzo < 0) {
                throw new Exception("Prezzo non valido");
            } else {
                this.prezzo = Math.Round(prezzo, 2);
            }
        }
        public double GetPrezzo() {
            return this.prezzo;
        }
        public override string ToString() {
            string print = base.ToString();
            print += " - Relatore: " + GetRelatore() + " - Prezzo: " + GetPrezzo()+" euro";
            return print;
        }

    }
}
