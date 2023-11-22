# Piredda.Riccardo.4i.rubricaWPF

## Caratteristiche del programma
* visualizzazione dei contatti su interfaccia grafica
* importazione di contatti tramite file CSV
* identificatore numerico univoco per ogni contatto

## Il principio dell'incapsulamento
Uno dei 4 principi fondamentali della programmazione ad oggetti è l'incapsulamento (information hiding): secondo questo principio tutti i campi di una classe dovrebbero essere privati, non accessibili direttamente, ma solo tramite predisposti (dal programmatore) metodi <i>getter</i> e <i>setter</i>.

## Lo standard Microsoft per la nomenclatura dei campi privati di una classe
Secondo la convenzione diffusa ed usata da Microsoft i nomi dei campi privati di una classe devono iniziare con il trattino basso (underscore _) ed il nome effettivo del campo deve iniziare con una lettera minuscola (lower case).
Per quanto riguarda le proprietà associate ai vari campi, queste devono iniziare con lettera maiuscola (upper case).

## Importazione di contatti da un file CSV
### Il file
Il file per essere valido ed essere riconosciuto deve trovarsi nella stessa cartella dell'eseguibile e deve avere il nome 'Dati.csv'; ogni sua riga a parte la prima, che specifica il contenuto di ogni campo, deve rispettare la seguente sintassi:
<b>PK;Nome;Cognome;Telefono;Email;</b><br>
Se in un qualsiasi caso questa sintassi non fosse rispettata il contatto non verrebbe considerato valido e non sarebbe mostrato.

## La classe Contatto
### Attributi
```C#
private int _PK;
```
Identificatore univoco per ogni contatto: è contenuto nella prima colonna del file CSV e deve essere un numero intero. Se il sistema non riesce a convertire il numero da stringa a intero il suo valore verrà impostato a 0, ed il contatto non conterrà informazioni.
```C#
private string _cognome;
private string _nome;
```
Campi per il contenimento di nome e cognome: se anche solo uno di questi campi è vuoto, il valore di _PK viene settato a 0, ed il contatto non conterrà informazioni.
```C#
private string _telefono;
private string _Email;
```
Contengono il numero di telefono e l'email: come per il nome ed il cognome NON possono essere vuoti.

### Costruttori
```C#
public Contatto()
```
Costruttore di default, viene chiamato dal programma per inizializzare gli elementi dell'array di contatti che non hanno una corrispondenza con una riga nel file CSV o la cui riga contiene valori non validi.
```C#
public Contatto(string r)
```
Costruttore che accetta come parametro una stringa estratta dal file CSV: la stringa deve contenere almeno 5 informazioni per contatto (non vuote) ed un identificatore valido: se l'identificatore non è valido verrà inizializzato a 0, ed il contatto non conterrà informazioni.
### Uso dei costruttori
Per usare il costruttore di default basta usare la sintassi più classica
```C#
Contatto c = new Contatto();
```
Oppure si può usare una sintassi probabilmente meno diffusa, in vigore da C# 9 e chiamata Target-typed new: con questa sintassi il compilatore risale automaticamente al tipo dichiarato per la variabile, e ne evita la ripetizione nella chiamata al costruttore, cosa che, nel caso di classi con nomi molto lunghi, poteva essere ripetitivo e poco comprensibile.
```C#
Contatto c = new();
```

### Property
Esiste una property per ogni attributo della classe, e tutti, a parte la property per il campo '_PK' che permette solo il 'get', consentono le operazioni di estrazione e di modifica del dato. 

### Modificare il valore dei campi dell'oggetto c
Per modificare il valore contenuto nei campi di un istanza di <i>Contatto</i> si scrive
```C#
c.Nome = "Riccardo";
c.Cognome = "Piredda";
c.Numero = "3452782655";  // Numero fittizio
```

## XAML
```XAML
<DataGrid x:Name="gdDati" LoadingRow="gdDati_LoadingRow">
```
In questa griglia saranno mostrati i contatti caricati dal file CSV.

## Come sono memorizzati e gestiti i contatti a runtime
I contatti, che siano caricati o non caricati da un file CSV, vengono collocati all'interno di un array di tipo Contatto di dimensione pari alla costante MAX (vedi paragrafo successivo).<br>
Questo array è poi collegato come sorgente dei contenuti alla DataGrid dichiarata nello XAML (vedi paragrafo precedente per definizione di DataGrid e paragrafo successivo collegamento dell'array a DataGrid).

## Il caricamento delle informazioni sulla schermata
Tutta la logica di caricamento delle informazioni nell'interfaccia grafica è contenuta nell'evento 
```C#
private void Window_Loaded(object sender, RoutedEventArgs e)
```
che viene chiamato non appena si ha finito di carica la finestra principale.<br>
In questo evento la prima cosa che viene fatta è inizializzare 2 variabili fondamentali per il programma:
- la prima, una costante, si chiama MAX, ed è usata per definire il numero massimo di contatti che è possibile usare.
- la seconda si chiama idx, ed è usata come indice.
```C#
const int MAX = 100;
int idx = 0;
```
Dopo queste variabili si entra in uno statement 'Try - Catch', dentro il quale si tenta di aprire il file 'Dati.csv', e, dopo la creazione dell'array di contatti, se ci sono dei contatti all'interno del file si tenta di caricare questi contatti. Una volta che i contatti nel file sono finiti, tutti gli altri contatti dell'array vengono inizializzati con il costruttore di default.
```C#
while (!sr.EndOfStream && idx < MAX)
{
    riga = sr.ReadLine();
    Contatti[idx] = new(riga);
    //Contatti[idx].Numero = idx+1;
    idx++;
}

while(idx < MAX)
    Contatti[idx++] = new();
```
Nel caso in cui venga sollevata una qualsiasi eccezione dall'apertura del file o dall'elaborazione dei dati in esso contenuti l'eccezione verrà gestita e verrà mostrato all'utente una finestra con il messaggio dell'eccezione e quale riga del file CSV l'ha causata. 
## Accortezze in fase di compilazione
1) Per non dover copiare a mano il file CSV nella directory di output del file eseguibile inserire nel file NomeProgetto.csproj le seguenti righe di codice:
    ```XML
    <ItemGroup>
    <None Update="Dati.csv">
        <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
    </ItemGroup>
    ```
    Questo permetterà al compilatore di capire l'azione che deve eseguire sul file in fase di compilazione.
2) Ad ogni modifica del file CSV il programma ha bisogno di essere ricompilato, in modo che la nuova versione del file sia copiata nella cartella dell'eseguibile.