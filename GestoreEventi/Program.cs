﻿

using GestoreEventi;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.ComponentModel;
using System;

Console.WriteLine("Inserire titolo del programma");
string titoloProgramma = Console.ReadLine();
ProgrammaEventi ProgrammaEventi = new(titoloProgramma);

Console.WriteLine("Quanti eventi vuoi creare?");
int NumeroEventi = int.Parse(Console.ReadLine());
for (int i = 0; i < NumeroEventi; i++) {
    while (true) {
        try {
            int count = i + 1;
            Console.Write("Inserire titolo dell "+count+"° evento: ");
            string titolo = Console.ReadLine();
            Console.Write("Inserire data (dd/MM/yyyy): ");
            string data = Console.ReadLine();
            Console.Write("Capienza masssima: ");
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

Console.WriteLine("Desidera filtrare la lista per data? si/no");
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

Console.WriteLine("Quante Conferenze vuoi creare?");
int NumeroConferenze = int.Parse(Console.ReadLine());
for (int i = 0; i < NumeroConferenze; i++) {
    while (true) {
        try {
            int count = i + 1;
            Console.Write("Inserire titolo dell " + count + "° evento: ");
            string titolo = Console.ReadLine();
            Console.Write("Inserire data (dd/MM/yyyy): ");
            string data = Console.ReadLine();
            Console.Write("Capienza masssima: ");
            string capienza = Console.ReadLine();
            Console.Write("Inserire Relatore: ");
            string relatore = Console.ReadLine();
            Console.Write("Prezzo: ");
            string prezzo = Console.ReadLine();
            Conferenza Conferenza = new(relatore,double.Parse(prezzo),titolo, data, int.Parse(capienza));
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

ProgrammaEventi.EmptyList();
