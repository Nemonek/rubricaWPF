using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    public enum TipoContatto
    {
        email,
        numero,
        web,
        instagram,
        nessuno
    }
    public class Contatto
    {
        private int _PK;
        private string _nome;
        private TipoContatto _tipo;
        private string _valore;

        public int PK { get => this._PK; }
        public string Nome { get => this._nome; }
        public TipoContatto Tipo { get => this._tipo; }
        public string Valore { get => this._valore; }

        public Contatto(string r)
        {
            string[] values = r.Split(';');
            this._PK = (int.TryParse(values[0], out int n)) ? n : 0 ;
            this._nome  = values[1];
            this._tipo = (Enum.TryParse(values[2], out TipoContatto t)) ? t : TipoContatto.nessuno;
            this._valore = values[3];
        }
    }
}
