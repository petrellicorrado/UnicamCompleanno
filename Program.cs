using System;

namespace UnicamCompleanno
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questo programma ti dice la tua eta' e il numero di giorni che restano al tuo compleanno");
            Console.WriteLine("Digita la tua data di nascita: ");
            string testoDigitatoDallUtente = Console.ReadLine();

            try {
                //Trasformo la stringa in oggetto di tipo DateTime
                DateTime dataDiNascita = DateTime.Parse(testoDigitatoDallUtente);
               
                //Se oggi è il compleanno
                if(dataDiNascita.Equals(DateTime.Today))
                    Console.WriteLine("Tanti Auguri!");
                else{

                    //Se la data è successiva ad oggi
                    if(dataDiNascita > DateTime.Today)
                        Console.WriteLine("Data successiva ad oggi!");
                    else{
                         //Memorizzo la giornata di oggi
                        DateTime oggi = DateTime.Today;
                        //Sottranno l'anno corrente per l'anno di nascita
                        int anniDiNascita = oggi.Year - dataDiNascita.Year;
                        //Se non hai compiuto ancora gli anni
                        if( dataDiNascita > oggi.AddYears(-anniDiNascita))
                            anniDiNascita--;
                        Console.WriteLine("Hai {0} anni",anniDiNascita);
                        
                        //NOTA BENE: NON FUNZIONA PER ANNI BISESTILI!
                        //Calcolo la data del prossimo compleanno
                        DateTime dataProssimoCompleanno = dataDiNascita.AddYears(oggi.Year - dataDiNascita.Year);
                        //Se ho già compiuto gli anni quest'anno
                        if (dataProssimoCompleanno < oggi)
                            dataProssimoCompleanno = dataProssimoCompleanno.AddYears(1);
                        //Calcolo il numero di giorni che mancano al mio compleanno
                        int numeroGiorni = (dataProssimoCompleanno - oggi).Days;                        
                        Console.WriteLine("Restano {0} giorni al tuo prossimo compleanno!",numeroGiorni);
               
                    }
                }
               
            } catch (Exception exc) {
                Console.WriteLine($"Non hai digitato una data valida, il programma ora terminera'. L'errore e' stato: {exc.Message}.");
            }
            Console.ReadKey();
        }
    }
}
