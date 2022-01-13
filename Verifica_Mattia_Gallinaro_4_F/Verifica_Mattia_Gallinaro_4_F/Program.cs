//Mattia Gallinaro 4 F
using System;

namespace Verifica_Mattia_Gallinaro_4_F
{
    class Treni//classe padre
    {
        
        public string codtreno { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public double costo;
        public Treni()//assegna i valori di codtreno, tipo, nome e costo
        {
            costo = 0;//lo mette pari a 0 perché viene calcolato in seguito il costo del mezzo
        }
        public virtual double CostoMezzo()//funzione che calcola il costo del mezzo e ne ritorna il valore
        {
            costo = 100000;
            return costo; 
        }
        public virtual int CostoUtilizzo(int km) { return km; }//ritorna 
        public override string ToString()//ritorna una stringa con i valori dei dati (non ritorna anche il costo perché quando devono 
        {
            return $"Codtreno: {codtreno} \nTipo: {tipo}\nNome: {nome}";
        }
    }

    //classe Passeggeri
    //classe figlia della classe Treni ed eredita le variabili:codtreno,tipo,nome,costo
    //e i metodi CostoMezzo, CostoUtilizzo e ToString
    class Passeggeri : Treni
    {
        //variabili con metodi get e set affinché possa modificarle nel main
        public int numvagoni { get; set; }
        public string alimentazione { get; set; }
        public Passeggeri() : base()
        {
        }
        public override double CostoMezzo()//funzione del padre che calcola il prezzo del treno passeggeri
        {
            costo = (base.CostoMezzo() * 1.25);
            return costo;
        }
        public override int CostoUtilizzo(int km)//funzione del padre che calcola il costo per il km effettuati
        {
            return km*150;
        }
        public override string ToString()//ritorna una strina con i dati del treno passeggeri
        {
            return base.ToString() + $"\nNumero di vagoni : {numvagoni}\nTipo di alimentazione : {alimentazione}";
        }
    }
    //classe Merci
    //classe figlia della classe Treni ed eredita le variabili:codtreno,tipo,nome,costo
    //e i metodi CostoMezzo, CostoUtilizzo e ToString
    class Merci : Treni
    {
        //variabili con metodi get e set affinché possa modificarle nel main
        public int numvagoni { get; set; }
        public string alimentazione { get; set; }
        public Merci() : base()
        {
        }
        public override double CostoMezzo()//funzione del padre che calcola il prezzo del treno passeggeri
        {
            costo = (base.CostoMezzo() * 1.35);
            return costo;
        }
        public override int CostoUtilizzo(int km)//funzione del padre che calcola il costo per il km effettuati
        {
            return km*100;
        }
        public override string ToString()//ritorna una strina con i dati del treno merci
        {
            return base.ToString() + $"\nNumero di vagoni : {numvagoni}\nTipo di alimentazione : {alimentazione}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int nvagoni = 0;
            double costo = 0;
            int km;
            Passeggeri passeggeri = new Passeggeri();//istanza della classe Passeggeri 
            Merci merci = new Merci();//istanza della classe Merci

            //input treno passeggeri
            Console.WriteLine("Inserisci il codtreno del treno passeggeri");
            passeggeri.codtreno = Console.ReadLine();
            Console.WriteLine("Inserisci il tipo del treno passeggeri");
            passeggeri.tipo = Console.ReadLine();
            while(passeggeri.tipo != "regionale" && passeggeri.tipo != "nazionale" && passeggeri.tipo != "internazionale")//si ripete fino a quando l'utente non inserisce uno dei tre tipi
            {
                Console.WriteLine("Inserisci il tipo del treno passeggeri");
                passeggeri.tipo = Console.ReadLine();
            }
            Console.WriteLine("Inserisci il nome del treno passeggeri");
            passeggeri.nome = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di vagoni del treno passeggeri");
            bool controllo = int.TryParse(Console.ReadLine(), out nvagoni);//variabile booleana che riceve valore false se il valore inserito dall'utente non é un intero, true se il valore inserito dall'utente é un intero e viene asseggnato alla variabile nvagoni
            while(!controllo || nvagoni <= 0)
            {
                Console.WriteLine("Inserisci il numero di vagoni del treno passeggeri");
                controllo = int.TryParse(Console.ReadLine(), out nvagoni);
            }
            passeggeri.numvagoni = nvagoni;
            Console.WriteLine("Inserisci l'alimentazione del treno passeggeri");
            passeggeri.alimentazione = Console.ReadLine();

            //input treno merci
            Console.WriteLine("Inserisci il codtreno del treno merci");
            merci.codtreno = Console.ReadLine();
            Console.WriteLine("Inserisci il tipo del treno merci");
            merci.tipo = Console.ReadLine();
            while (merci.tipo != "regionale" && merci.tipo != "nazionale" && merci.tipo != "internazionale")//si ripete fino a quando l'utente non inserisce uno dei tre tipi
            {
                Console.WriteLine("Inserisci il tipo del treno passeggeri");
                merci.tipo = Console.ReadLine();
            }
            Console.WriteLine("Inserisci il nome del treno merci");
            merci.nome = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di vagoni del treno merci");
            controllo = int.TryParse(Console.ReadLine(), out nvagoni);
            while (!controllo || nvagoni <= 0)//ripeto fino a quando l'utente non inserisce un numero maggiore di 0
            {
                Console.WriteLine("Inserisci il numero di vagoni del treno merci");
                controllo = int.TryParse(Console.ReadLine(), out nvagoni);
            }
            merci.numvagoni = nvagoni;
            Console.WriteLine("Inserisci l'alimentazione del treno merci");
            merci.alimentazione = Console.ReadLine();

            Console.WriteLine("Ecco i dati inseriti");
            Console.WriteLine("Dati treno passeggeri \n"+passeggeri);//richiama la funzione ToString della classe Passeggeri per l'istanza passeggeri
            Console.WriteLine("Dati treno merci \n" + merci);//richiama la funzione ToString della classe Merci per l'istanza merci
            Console.WriteLine("Inserisci i km effettuati dal treno passeggeri");
            controllo = int.TryParse(Console.ReadLine(), out km);
            while (!controllo || km < 0)//si ripete fino a quando controllo ha valore false e km é un numero negativo
            {
                Console.WriteLine("Inserisci i km effettuati dal treno passeggeri");
                controllo = int.TryParse(Console.ReadLine(), out km);
            }
            Console.WriteLine($"Costo treno passeggeri {passeggeri.CostoMezzo()}");
            costo += passeggeri.CostoMezzo();
            Console.WriteLine($"Costo km effettuati del treno passeggeri: {passeggeri.CostoUtilizzo(km)}");
            costo += passeggeri.CostoUtilizzo(km);//richiama la funzione CostoUtilizzo della classe Passeggeri passando come valore km 
            Console.WriteLine("Inserisci i km effettuati dal treno merci");
            controllo = int.TryParse(Console.ReadLine(), out km);
            while (!controllo || km < 0)//si ripete fino a quando controllo ha valore false e km é un numero negativo
            {
                Console.WriteLine("Inserisci i km effettuati dal treno merci");
                controllo = int.TryParse(Console.ReadLine(), out km);
            }
            Console.WriteLine($"Costo treno merci {merci.CostoMezzo()}");
            costo += merci.CostoMezzo();
            Console.WriteLine($"Costo km effettuati del treno merci:{merci.CostoUtilizzo(km)}");
            costo += merci.CostoUtilizzo(km);//richiama la funzione CostoUtilizzo della classe Merci passando come valore km
            Console.WriteLine($"Costo totale dei mezzi:{costo}");

        }
    }
}
