

using GestoreEventi;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.ComponentModel;

Console.WriteLine("Inserire titolo del programma");
string titoloProgramma = Console.ReadLine();
ProgrammaEventi ProgrammaEventi = new(titoloProgramma);

Console.WriteLine("Quanti eventi vuoi creare?");
int NumeroEventi = int.Parse(Console.ReadLine());
for (int i = 0; i < NumeroEventi; i++) {
    while (true) {
        try {


            Console.Write("Inserire un titolo: ");
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

var result = ProgrammaEventi.GetListaEventi().Where(o => o.GetTitolo() == input);
ProgrammaEventi.GetListaEventi().IndexOf()
ProgrammaEventi.EmptyList();
