

using GestoreEventi;
using static System.Net.Mime.MediaTypeNames;

/*try {
    Evento test = new("le balene", "10/12/22", 12);
}catch(Exception e) {
    Console.WriteLine(e);
}*/
try {
    Evento test = new("le balene", "14/12/2022", 12);
    Console.WriteLine(test.GetData());
    Console.WriteLine(test);
}
catch (Exception e) {
    Console.WriteLine(e);
}