# Piredda.Riccardo.4i.rubricaWPF

## Cosa chiede l'esercizio

## Il principio dell'incapsulamento
Uno dei 4 principi fondamentalli della programmazione ad oggetti è l'incapsulamento (information hiding): secondo questo principio tutti i campi di una classe dovrebbero essere privati, non accessibili direttamente, ma solo tramite predisposti (dal programmatore) metodi <i>getter</i> e <i>setter</i>.

## Lo standard Microsoft per la nomenclatura dei campi privati
Secondo la convenzione diffusa ed usata da Microsoft i nomi dei campi privati di una classe devono iniziare con il trattino basso (underscore _) ed il nome effettivo del campo deve iniziare con una lettera minuscola (lower case).
Per quanto riguarda le proprietà associate ai vari campi, queste devono iniziare con lettera maiuscola (upper case).


## L'esercizio
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
Infine, creaiamo le 3 property per rendere accessibili i campi:
```C#
// Anche in questo caso è stata seguita la convenzione Microsoft
public string Nome { get => _nome; set => _nome = value; }
public string Cognome { get => _cognome; set => _cognome = value; }
public string Numero { get => _numero; set => _numero = value; }
```
