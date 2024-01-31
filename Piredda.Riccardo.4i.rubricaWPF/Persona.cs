using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    public class Persona
    {
        private int _PK;
        private string _nome;
        private string _cognome;

        public int PK { get => this._PK; }
        public string Nome { get => this._nome; }
        public string Cognome { get => this._cognome; }

        public Persona(string input)
        {
            string[] tmp = input.Split(';');
            if(tmp.Length < 3)
            {
                this._PK = (int.TryParse(tmp[0], out int n)) ? n : 0;
                this._nome = "";
                this._cognome = "";
            }
            else
            {
                this._PK = (int.TryParse(tmp[0], out int n)) ? n : 0;
                this._nome = tmp[1];
                this._cognome = tmp[2];
            }
        }
    }
}
