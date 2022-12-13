using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi {
    public class Evento {
        private string titolo;
        private DateTime data;
        private int CapienzaMax;
        private int PostiPrenotati;

        public Evento(string titolo, string data, int CapienzaMax) {

            SetTitolo(titolo);
            SetData(data);
            this.CapienzaMax=CapienzaMax;
            PostiPrenotati = 0;

        }
        public string GetTitolo() {
            return titolo;
        }
        public void SetTitolo(string titolo) {
            if (string.IsNullOrWhiteSpace(titolo)) {
                throw new Exception("Il titolo inserito non va bene");
            } else {
                this.titolo = titolo;
            }
        }

        public string GetData() {

            return data.ToShortDateString();
        }

        public void SetData(string data) {
            if (DateTime.Parse(data) < DateTime.Now) {
                throw new Exception("Data inserita non valida");
            }
            
            this.data = DateTime.Parse(data);
        }
        public int GetCapienzaMax() {
            return CapienzaMax;
        }

        public int GetPostiPrenotati() {
            return PostiPrenotati;
        }

        public void PrenotaPosti(int Prenotazione) {

            if (PostiPrenotati == CapienzaMax) {
                throw new Exception("siamo al completo");
            } else if (Prenotazione < 0) {
                throw new Exception("non puoi prenotare meno di 0");
            } else if ((PostiPrenotati + Prenotazione) > CapienzaMax) {
                throw new Exception("Mi dispiace non ci sono abbastanza posti");
            } else {
                PostiPrenotati += Prenotazione;
            }
        }
        public int PostiDisponibili() {
            return CapienzaMax - PostiPrenotati;
        }
        public void DisdirePrenotazione(int disdire) {
            PostiPrenotati-= disdire;
        }
        public override string ToString() {
            string print = "Data: " + GetData()+"\n";
            print += "Titolo: " + GetTitolo();
            return print;
        }
    }
}
