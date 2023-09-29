# Piredda.Riccardo.4i.rubricaWPF

## Cosa chiede l'esercizio

## Il principio dell'incapsulamento
Uno dei 4 principi fondamentalli della programmazione ad oggetti è l'incapsulamento (information hiding): secondo questo principio tutti i campi di una classe dovrebbero essere privati, non accessibili direttamente, ma solo tramite predisposti (dal programmatore) metodi <i>getter</i> e <i>setter</i>.

## Lo standard Microsoft per la nomenclatura dei campi privati
Secondo la convenzione diffusa ed usata da Microsoft i nomi dei campi privati di una classe devono iniziare con il trattino basso (underscore _) ed il nome effettivo del campo deve iniziare con una lettera minuscola (lower case).
Per quanto riguarda le proprietà associate ai vari campi, queste devono iniziare con lettera maiuscola (upper case).


## L'esercizio
### Creazione della classe e dei suoi campi
Il primo passo fatto è la creazione della classe contatto:
```C#
internal class Contatto
```
Poi si creano i 3 campi privati:
```C#
// Notare come la nomenclatura dei campi si stata fatta seguendo la convenzione Microsoft
private string _nome;
private string _cognome;
private string _numero;
```
Infine, creiamo le 3 property per rendere accessibili i campi:
```C#
// Anche in questo caso è stata seguita la convenzione Microsoft
public string Nome { get => _nome; set => _nome = value; }
public string Cognome { get => _cognome; set => _cognome = value; }
public string Numero { get => _numero; set => _numero = value; }
```
### Creazione di un oggetto Contatto
Per il momento non è implementato il costruttore, quindi viene usato quello di default. <br><br>
Per creare un oggetto contatto si possono usare le seguenti sintassi:<br>
Sintassi classica, e probabilmente anche la più diffusa.
```C#
Contatto c = new Contatto();
```
Sintassi probabilemte meno diffusa, in vigore da C# 9 e chiamata Target-typed new: con questa sintassi il compilatore risale automaticamente al tipo dichiarato per la variabile, ed evita la ripetizione del tipo, che, nel caso di classi con nomi molto lunghi, poteva essere ripetitivo e poco comprensibile.
```C#
Contattoo c = new();
```

### Modificare il valore dei campi dell'oggetto c
Per modificare il valore contenuto nei campi di un istanza di <i>Contatto</i> si scrive
```C#
c.Nome = "Riccardo";
c.Cognome = "Piredda";
c.Numero = "3452782655";  // Numero fittizio
```
