# Service Chat
Blaž Ocepek 63140179 

Tjaž Špegel 63130246


![Alt text](http://image.prntscr.com/image/0367e45c20544857a80d9a74da5f3a00.png)
Prikaz administratorskega vmesnika
![Alt text]()

Pri posedobovanju strani za azure ni bilo veliko težav, ker sem delal isto kot pri prejšnji nalogi.
Največja težava je bila pri datomu in času, ko sem ga moral preoblikovati da je v pravilnem formatu za SQl bazo, tukaj je nastopila težava ker je stran preko spleta dobila drugačen format časa in sem dobival napako "index aout of bounds". Po ugotovotvi izvora napake te ni bilo teško odpraviti.

Posodobitev baze je bila lahka ker sem moral dodati samo polja tabelama kar pa je v VisualStudiju zelo olajšano.

Celotna chat stran je že prej delovala samo posodobiti sem moral, da podatke pridobi in piše v bazo na azure strežnik.
Administracijsko konzolo sem naredil tako da prikaže vse uporabnike v DataView, ki pridobi podatke iz sqlDataSource, potem so zraven 3-je gumbi, ki ali odstrani izbranega uporabnika in vsa sporočila njegova ali ga naredi administratorja ali navadnega uporabnika.

![Alt text](http://image.prntscr.com/image/cb9d7944da6748519d77198180b6c0d8.png)
Prikaz obeh tabel baze levo Uporabniki in desno Pogovor. 
pomen stolpca v vsaki tabeli:

  Uporabnik:
  
    *username: uporabniško ime uporabnika
    
    *ime: ime uporabnika
    
    *priimek: priimek uporabnika
    
    *geslo: hashed geslo ki ga je nastavil uporabnik
    
    *stSporocil: število sporočil, ki jih je uporabnik napisal
    
    *admin: ali ima uporabnik administratorske pravice
    
  Pogovor:
  
  *id: zaporedna številka sporočila
  
  *username: uporabniško ime uoporabnika, ki je povezan s tabelo Uporabnik, s tem vemo kdo je napisal sporočilo
  
  *besedilo: kaj je oseba napisala
  
  *casSporocila: kdaj je oseba to sporočilo napisala
  

// SLIKA

Večji težav pr izdelavi Android aplikacije nisem imel, saj sem pri predmetu Elektronsko in mobilno poslovanje izdelal še malce bolj kompleksno aplikacijo, kot je bila ta. Največ problemov sem imel z urejanje izpisa in samim pošiljanjem novih sporočil.

Najprej sem se lotil prijavne strani, ki je vidna na zgorni sliki. Iz dveh "TextFieldov" sem prebrav uporabniško ime in geslo, ki ga vnese uporabnik. Najprej sem preveril, da katero izmed polji ni prazno (če je katero izmed polji prazno se izpiše opozorilo), nato pa sem na Azure poslal zahtevo po servisu, ki vrne vrednost true če je uporabnik registriran in če je geslo pravilno ali false v nasprotnem primeru. To vrednost sem dobil v jason formatu, iz katerega sem nato dobil boolean vrednost. V primeru, da je bila vrednost true, se aktivira preusmeritev na "Chat" stran, kamor se tudi pošlje uporabniško ime in geslo (preko intenta), v nasprotnem primeru se izpiše obvestilo o napaki.

Ob uspešni prijavi se uporabniki izpišejo vsa stara spročila. Vsa sporočila dobim tako, da na Azure pošljem zahtevo po vseh sporočilih, ki jih pridobim v jason formatu, iz katerega nato vrstico po vrstico izpišem na zaslon. V temu koraku je nastal prvi večji problem, saj je bilo v samem izpisu veliko nepotrebnih znakov, ki jih nisem znal zbrisati. Nakoncu sem uporabil File.separator, ki je zamenjal znak z "/". Nato sem odpravil še vse nepotrebne "/". Shranjeval sem tudi indeks zadnjega izpisanega sporočila, in tako sem omogočil, da se ob kliku na gumb "Osveži" dodajo samo nova sporočila.

Zadnja stvari, ki sem jo omogočil je pošiljanje sporočil. Tukaj sem imel največ težav, saj sva service za dodajanje teksta naredila tako, da se text pošilja preko URL-ja in to mi preko POST metode ni uspelo narediti. Dobil sem error 405, ki ga nisem znal odpraviti, zato sem spremenil taktiko in uporabil WebView. WebView sem skril v ozadnje tako, da je uporabniki neviden in se samo poveže na zahtevano stran. Tako se doda novo sporočilo.

// SLIKA
  
Blaž Ocepek: Jaz sem sprogramiral Spletno stran, service in Administracijsko konzolo

Tjaž Špegel: Jaz sem postavil in posodobil bazo in izdelal Android aplikacijo.
