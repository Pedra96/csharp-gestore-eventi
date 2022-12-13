

using GestoreEventi;
using static System.Net.Mime.MediaTypeNames;


Console.WriteLine("Inserire titolo del programma");
string titoloProgramma=Console.ReadLine();
ProgrammaEventi EventiProgrammati = new(titoloProgramma);

Console.WriteLine("Quanti eventi vuoi creare?");
int NumeroEventi=int.Parse(Console.ReadLine());
for (int i = 0; i < NumeroEventi; i++) {

    Console.Write("Inserire un titolo: ");
    string titolo = Console.ReadLine();


    Console.Write("Inserire data (gg/MM/yyyy): ");
    string data = Console.ReadLine();
    Console.Write("Capienza masssima: ");
    string capienza = Console.ReadLine();

    Evento evento = new(titolo, data, int.Parse(capienza));
    EventiProgrammati.AddEvento(evento);
}
/*
try {
    Console.WriteLine("Posti prenotati " + evento.GetPostiPrenotati());
    Console.WriteLine("Posti disponibili " + evento.PostiDisponibili());
    Console.WriteLine("Vuoi prenotare? si/no");
    string input = Console.ReadLine();
    while (input.ToLower() == "si") {
        Console.WriteLine("Quanti posti vuoi prenotare?");
        string Prenotazione = Console.ReadLine();
        evento.PrenotaPosti(int.Parse(Prenotazione));
        Console.WriteLine("Posti prenotati vuoi prenotarne altri? si/no");
        input = Console.ReadLine();
    }
    Console.WriteLine("Posti ancora disponibili: " + evento.PostiDisponibili());
    if (!string.IsNullOrEmpty(input)) {
        Console.WriteLine("Vuoi disdire dei posti prenotati? si/no");
        input = Console.ReadLine();
        while (input.ToLower() == "si") {
            Console.WriteLine("Quanti posti prenotati vuoi disdire?");
            input = Console.ReadLine();
            evento.DisdirePrenotazione(int.Parse(input));
            Console.WriteLine("Posti prenotati disdetti, vuoi disdirne altri? si/no");
            input = Console.ReadLine();

        }
        Console.WriteLine("Posti ancora disponibili: " + evento.PostiDisponibili());
    }
    
    Console.WriteLine(evento);
}
catch (Exception e) {
    Console.WriteLine(e);
}*/
EventiProgrammati.GetEventi();