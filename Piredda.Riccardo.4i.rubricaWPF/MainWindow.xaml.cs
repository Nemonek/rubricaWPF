using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Tutta la roba va inserita all'interno dell'evento Loaded della MainWindow.
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            const int MAX = 100;
            int idx = 0;
            // Siccome l'apertura di un file può causare un eccezione per diversi motivi
            try
            {
                Contatto[] Contatti = new Contatto[MAX];

                // Per farlo copiare sempre nella cartella in cui il programma va a cercare si aprono le proprietà del file: tasto destro -> proprietà, poi su copia si mette 'copia sempre'
                StreamReader sr = new("Dati.csv");
                sr.ReadLine();
                string riga = string.Empty; // equivalente di ""

                // Non avendo 100 elementi inizializzati, ma messi a null, il binding cercava di visualizzzre oggetti null, e sollevava un exception; mettento 3, ed inizializzando 3, non ci sono problemi
                // Se volessimo ovviare a questo prpblemi basterebbe riempire tutta la lunghezza dell'array di contatti vuoti, senza nome cognome ecc..
                

                

                // Per leggere tutte le righe singolarmente possiamo ciclare con un while ogni riga una per una usando l'attributo endofstream, che definisce se siamo alla fine della stream o meno:
                // va negato perchè di default, se non siamo già alla fine della stream, il valore sarà false, e per ciclare deve essere true.
                // Quando poi arriveremmo alla fine endofstream passerà a true interrompendo il ciclo while.

                // Nel caso in cui abbiamo 3 righe vuote, poi la 4 ha qualcosa, le righe vuote prima di quella piena saranno considerate righe, tutto quello sotto, se sono righe vuote verrà ignorato.
                while (!sr.EndOfStream && idx < MAX)
                {
                    riga = sr.ReadLine();
                    Contatti[idx] = new(riga);
                    //Contatti[idx].Numero = idx+1;
                    idx++;
                }

                while(idx < MAX)
                    Contatti[idx++] = new();

                idx = 0;

                gdDati.ItemsSource = Contatti;



                //riga = sr.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nErrore alla riga: {idx}!");
            }


            //// Con la lista viene visuallizata nella datagrid una riga in più poichè consente di aggiungere manualmente elementi senza implementare il codice, ma è già implementato.         
            ////List<Contatto> Contatti = new();

            // In C# il valore di default alla creazione di un intero è 0, che viene assegnato automaticamente.
            //int valore;
        }

        private void gdDati_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            Contatto prova = e.Row.Item as Contatto;

            if(prova != null && (prova.PK == 0 || prova.Telefono[0] == '3'))
            {
                e.Row.Background = Brushes.Yellow;
            } 
        }
    }
}
