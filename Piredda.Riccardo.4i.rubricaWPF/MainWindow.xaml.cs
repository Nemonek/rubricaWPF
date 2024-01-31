using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Contatto> _tutteLeInformazioni;
        private List<Contatto> _itemSourceContatti;
        private List<Persona> _itemSourcePersone;


        public List<Contatto> ItemSourceContatti { get => this._itemSourceContatti; }
        public List<Persona> ItemSourcePersone { get => this._itemSourcePersone; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            // Tutta la roba va inserita all'interno dell'evento Loaded della MainWindow.
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._itemSourceContatti = new();
            this._tutteLeInformazioni = new();
            this._itemSourcePersone = new();
            // Siccome l'apertura di un file può causare un eccezione per diversi motivi
            try
            {
                using ( StreamReader sr = new( "Contatti.csv" ) )
                {
                    sr.ReadLine();
                    string riga = string.Empty;
                
                    while (!sr.EndOfStream)
                        this._tutteLeInformazioni.Add(new Contatto(sr.ReadLine()));

                    sr.Close();
                }
                StatusBar.Text = $"Trovati {this._tutteLeInformazioni.Count} contatti";

                using ( StreamReader sr = new( "Persone.csv" ) )
                {
                    sr.ReadLine();
                    string riga = string.Empty;

                    while (!sr.EndOfStream)
                        this._itemSourcePersone.Add(new Persona(sr.ReadLine()));

                    sr.Close();
                }
                StatusBar.Text = $"Trovati {StatusBar.Text} contatti e {this._itemSourcePersone.Count} persone";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            GrigliaContatti.ItemsSource = this.ItemSourceContatti;
            GrigliaPersone.ItemsSource = this.ItemSourcePersone;
        }

        private void GrigliaContatti_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //StatusBar.Text = $"Contatto selezionato: {((Contatto)e.AddedItems[0]).Nome}";
        }
        private void GrigliaPersone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this._itemSourceContatti.Clear();
            Persona p = e.AddedItems[0] as Persona;
            this._itemSourceContatti = new List<Contatto>(this._tutteLeInformazioni.Where(t => t.PK == p.PK));

            GrigliaContatti.ItemsSource = this.ItemSourceContatti;
        }
    }
}
