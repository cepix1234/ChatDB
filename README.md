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
  
Blaž Ocepek: Jast sem sprogramiral Spletno stran, service in Administracijsko konzolo

Tjaž Špegel: Jast sem postavil bazo, ter sprogramiral Log in stran
