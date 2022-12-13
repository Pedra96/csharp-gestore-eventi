

using GestoreEventi;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.ComponentModel;
using System;

Console.WriteLine("Inserire titolo del programma");
string titoloProgramma = Console.ReadLine();
if (string.IsNullOrEmpty(titoloProgramma)) {
    titoloProgramma = "Default";
}
ProgrammaEventi ProgrammaEventi = new(titoloProgramma);

int NumeroEventi = 0;
while(true) {
    try {
        Console.WriteLine("Quanti eventi vuoi creare?");
        NumeroEventi = int.Parse(Console.ReadLine());
        break;
    }
    catch (Exception) {
        Console.WriteLine("Valore Errato");
    }
}

for (int i = 0; i < NumeroEventi; i++) {
    while (true) {
        try {
            int count = i + 1;
            Console.Write("Inserire titolo dell "+count+"° evento: ");
            string titolo = Console.ReadLine();
            Console.Write("Inserire data (dd/MM/yyyy): ");
            string data = Console.ReadLine();
            Console.Write("Capienza massima: ");
            string capienza = Console.ReadLine();
            Evento evento = new(titolo, data, int.Parse(capienza));
            ProgrammaEventi.AddEvento(evento);
            break;
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Errore riprovare");
        }
    }
}

Console.WriteLine("Numero di eventi programmati: " + ProgrammaEventi.EventiCount() + "\n");
Console.WriteLine("Gli eventi programmati sono: ");
ProgrammaEventi.GetEventi();

Console.WriteLine("Desideri filtrare la lista per data? si/no");
string input=Console.ReadLine();
if (input.ToLower() == "si"){
    Console.Write("Inserisci una data per cui vuoi filtrare (dd/MM/yyyy): ");
    input = Console.ReadLine();
    List<Evento> ListaFiltrata = new();

    Console.WriteLine("Gli eventi in data " + input + " sono:");
    foreach (var evento in ProgrammaEventi.GetListaEventi()) {
        if (DateOnly.Parse(evento.PrintData()) == DateOnly.Parse(input)) {
            ListaFiltrata.Add(evento);
        }
    }
    Functions.StampaListaEvento(ListaFiltrata);
}

Console.WriteLine("---Bonus---");

while (true) {
    int NumeroConferenze = 0;
    try {
        Console.WriteLine("Quante Conferenze vuoi creare?");
        NumeroConferenze = int.Parse(Console.ReadLine());
        break;
    }
    catch (Exception) {
        Console.WriteLine("Valore Errato");
    }

    for (int i = 0; i < NumeroConferenze; i++) {
        while (true) {
            try {
                int count = i + 1;
                Console.Write("Inserire titolo dell " + count + "° evento: ");
                string titolo = Console.ReadLine();
                Console.Write("Inserire data (dd/MM/yyyy): ");
                string data = Console.ReadLine();
                Console.Write("Capienza massima: ");
                string capienza = Console.ReadLine();
                Console.Write("Inserire Relatore: ");
                string relatore = Console.ReadLine();
                Console.Write("Prezzo: ");
                string prezzo = Console.ReadLine();
                Conferenza Conferenza = new(relatore, double.Parse(prezzo), titolo, data, int.Parse(capienza));
                ProgrammaEventi.AddEvento(Conferenza);
                break;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                Console.WriteLine("Errore riprovare");
            }
        }
    }

    ProgrammaEventi.GetEventi();
    Console.WriteLine("Per quale evento vorresti prenotare?");
    input = Console.ReadLine();
    int FindEvento = Functions.FiltroListaNome(ProgrammaEventi.GetListaEventi(), input);
    if (FindEvento < 0) {
        Console.WriteLine("elemento non trovato");
    } else {
        try {
            var EventoFiltrato = ProgrammaEventi.GetListaEventi()[FindEvento];
            Console.WriteLine("Posti Disponibili: " + EventoFiltrato.PostiDisponibili());
            Console.Write("Quanti posti vuoi prenotare?: ");
            input = Console.ReadLine();
            EventoFiltrato.PrenotaPosti(int.Parse(input));
            Console.WriteLine("Posti Disponibili: " + EventoFiltrato.PostiDisponibili());
        }
        catch (Exception ex) { Console.WriteLine(ex); }
    }
    Console.WriteLine("Per quale evento vorresti disdire?");
    input = Console.ReadLine();

    FindEvento = Functions.FiltroListaNome(ProgrammaEventi.GetListaEventi(), input);

    if (FindEvento < 0) {
        Console.WriteLine("elemento non trovato");
    } else {
        try {
            var EventoFiltrato = ProgrammaEventi.GetListaEventi()[FindEvento];
            Console.WriteLine("Posti prenotati: " + EventoFiltrato.GetPostiPrenotati());
            Console.Write("Quanti posti vuoi disdire?: ");
            input = Console.ReadLine();
            EventoFiltrato.DisdirePrenotazione(int.Parse(input));
            Console.WriteLine("Posti Disponibili: " + EventoFiltrato.PostiDisponibili());
        }
        catch (Exception ex) { Console.WriteLine(ex); }
    }
    ProgrammaEventi.EmptyList();
}