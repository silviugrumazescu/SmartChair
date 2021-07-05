# SmartChair
Smart chair este o husa inteligenta pentru scaun, ce are rolul de a monitoriza durata pe care utilizatorul o petrece pe acesta in fiecare zi
si de a-l alerta in cazul in care pozitia sa nu este corecta ( spatele nu este lipit de spatar ).
In acest proiect se vor gasi:
* aplicatia windows suport pentru dispozitiv ( dezvoltata in C# )
* fisierul .ino si header-urile acestui pentru programarea microcontroller-ului Arduino Mega

![Imagine1](https://user-images.githubusercontent.com/74622515/124475963-ff292f00-ddaa-11eb-93be-7486de347cdc.jpg)

**Descrierea dispozitivului:**   
SmartChair se foloseste de 6 senzori de forta: 5 pozitionati in zona omoplatilor si in zona lombara, si 1 pentru sezut ( pentru a detecta prezenta utilizatorului ).
In cazul in care senzorul pentru sezut este activ (persoana se afla pe scaun) dar ceilalti sensori pentru spate determina ca acesta se afla intr-o pozitie incorecta, 
dispozitivul va alerta utilizatorul pana acesta isi corecteaza postura. In paralel, SmartChair inregistreaza o serie de statistici organizate pe zile, cum ar fi: 
perioada petrecuta la calculator, numarul de alerte, timpul petrecut in pozitie incorecta si duratele de activare a fiecarui senzor. 

<img width="548" alt="Schita-husa" src="https://user-images.githubusercontent.com/74622515/124475854-e02a9d00-ddaa-11eb-9e69-847bc0cc13dd.png">

**Componente utilizate:**
* Arduino Mega
* x6 sensori de forta
* Modul adaptor SD ( pentru scrierea si citirea datelor statistice )
* Modul bluetooth HC-05 ( ce asigura comunicarea bluetooth cu aplicatia windows )
* Modul Real-Time Clock DS3231 ( pentru inregistrarea corect cronologica a evenimentelor stocate)
* Sonerie ( pentru alertarea utilizatorului )

**Moduri de functionare:**
* Modul bluetooth:
Acest mod necesita folosierea unei aplicatii suport pentru windows ce se va conecta prin bluetooth la dispozitiv si va primi informatii in timp real despre pozitia utilizatorului.
In plus, aplicatia poate solicita de la dispozitiv toate datele statistice inregistrate pe cardul SD, pe care le v-a afisa utilizatorului prin intermediul a mai multor grafice. 
In cazul in care utilizatorul nu se afla in pozitie corecta pe scaun, alerta va consta in aparitia unei ferestre de atentionare ce va bloca activitatea utilizatorului pana la 
corectarea posturii.

* Modul fara bluetooth:
Acest modul nu necesita folosirea aplicatiei suport, datele statistice inca fiind inregistrate, dar alertarea fiind facuta prin intermediul unei sonerii integrate in dispozitiv.

## Aplicatia pentru Windows

![Prezentare-aplicatie](https://user-images.githubusercontent.com/74622515/124477078-449a2c00-ddac-11eb-9789-3ca16ba57eff.gif)












