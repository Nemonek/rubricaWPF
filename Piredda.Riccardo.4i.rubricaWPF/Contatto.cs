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
        private string _nome;
        private string _cognome;
        private string _numero;

        //public Contatto(string nom, string cog, string num)
        //{
        //    Nome = nom;
        //    Cognome = cog;
        //    Numero = num;
        //}

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string Numero { get => _numero; set => _numero = value; }
    }
}
