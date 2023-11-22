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
            //Contatto c = new();

            //// Chiamate ai setter
            //c.Nome = "Riccardo";
            //c.Cognome = "Piredda";
            //c.Numero = 1;
            //c.Email = "Riccardo@gmail.com";
            //c.Telefono = "3516856899";

            //try
            //{
            //    c.Numero = 101;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //Contatti[0] = c;
            ////Contatti.Add(c);

            //// Costruttore implicito: non è neccessario avere un costruttore che supporta parametri per fare questo
            //Contatto c1 = new()
            //{
            //    Nome = "Riccardo",
            //    Cognome = "Piredda",
            //    Numero = 2,
            //    Email = "Riccardo@gmail.com",
            //    Telefono = "356856897"
            //};

            //Contatti[1] = c1;
            ////Contatti.Add(c1);

            //// Ulteriore uso della target typed new expression.
            //Contatti[2] = new()
            //{
            //    Nome = "Roberto",
            //    Cognome = "Bianchi",
            //    Numero = 3,
            //    Email = "Riccardo@gmail.com",
            //    Telefono = "3515879970222"
            //};

            ////Contatti.Add( new() {
            ////    Nome = "Roberto",
            ////    Cognome = "Bianchi",
            ////    Numero = 3
            ////});


            // In C# il valore di default alla creazione di un intero è 0, che viene assegnato automaticamente.
            int valore;
        }

        private void gdDati_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            Contatto prova = e.Row.Item as Contatto;

            if(prova != null && prova.PK == 0)
            {
                e.Row.Background = Brushes.Yellow;
            } 
        }
    }
}
