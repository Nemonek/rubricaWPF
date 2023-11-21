using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    internal class Contatto
    {
        // The microsoft convention for the private attributes of a class is:
        // for privates member use the underscore before the name;
        // for the property use the first letter lower case.
        //private string _nome;
        private int _PK;
        private string _cognome;
        private string _telefono;
        private string _Email;

        public Contatto() { }

        // Il costruttore è meglio che passi anche lui dal getter e dal setter, per evitare che assegni direttamente un valore non consono.
        //public Contatto(string nom, string cog, int num, string e, string Tel)
        //{
        //    Nome = nom;
        //    Cognome = cog;
        //    Numero = num;
        //    Email = e;
        //    Telefono = Tel;
        //}

        public Contatto(string r)
        {
            string[] values = r.Split(';');
            if(values.Length >= 5) {
                if(int.TryParse(values[0], out int res)) {
                    this._PK = res;
                    this.Nome = values[1];
                    this.Cognome = values[2];
                    this.Telefono = values[3];
                    this.Email = values[4];
                }
                else
                {
                    //throw new ArgumentException($"L'argomento passato al costruttore ({values[0]}) per il campo intero PK non è un numero valido.");
                    this._PK = 0;
                }
            }
        }

        /*
         * 04/10/2023
         * La differenza tra le due property scritte così, a livello di compilazione, non cambia nulla, l'assembly generato è uguale.
         * Quella di default è la seconda versione.
         * visibilità tipo nome aperta get set chiusa => struttura della property.
         * Nei get e set è possibile inserire del codice:
            get {
                // Corpo del get
            }
         * 
         * Esempio:
            public string Nome {
                get { 
                    return _nome;  
                } 
                set { 
                    _nome = value;
                } 
            }
         * 
         * Possiamo operare nel get e nel set come se fosse una funzione.
         * Se modificassimo il getter di numero con 
            public int Numero {
                get { 
                    _numero++;          // Qua avremmo una modifica effettiva del campo privato, che passerebbe da 0 a 1, salvo modifiche fatte dal main.
                    return _numero + 1; // Qua non viene modificato il campo privato.
                } 
                set { 
                    _numero = value;
                } 
            }
         * 
         * Alla chiamata del setter, quindi facendo per esempio Numero = 3;
         * il valore assegnato alla property, quindi in sto caso 3, sarà considerato parametro implicito del setter, e prenderà il nome di 'value'.
            set { 
                 _numero = value;
            } 
         * 
         * Se scriviamo c.Numero++;
         * Il setter è costretto a richiamare il getter, che ritorna al setter il valore del campo, poi il setter incrementa il valore passato con il ++ AL DI FUORI DELLA CLASSE (modifica il parametro value)
         * poi lo inserisce nel campo privato.
         * 
         * Per evitare che l'utente isnerisca un valore che non rispetta i parametri di validità, siccome il get ed il set possono avere un corpo, come un metodo/funzione, si 
         * può inserire un controllo, che nel caso di una tentata assegnazione di un valroe non consono, sollevi un eccezione
         * 
         * Un altro modo per scrivere la property è:
            public Nome { set; get; }
         * In questo caso non c'è bisogno di esplicitare l'esistenza del campo privato, poichè verrà creata automaticamente; NON sarà accessibile e/o visualizzabile
         * come se fosse un campo privato.
         * 
         * NOTA BENE: si possono creeare property di sola lattura così:
            public Nome { private set; get; }
         *
         *
         *
         *
         *
         *

        */

        public int PK { get => this._PK; }
        public string Nome { set; get; }
        public string Cognome { 
            get => _cognome; 
            set => _cognome = value; 
        }

        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
