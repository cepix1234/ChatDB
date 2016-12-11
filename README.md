# ChatDB
Blaž Ocepek 63140179 

Tjaž Špegel 63130246

Pri izdlavi registracije in prijave mi je največ problemov delalo samo branje iz baze. Malo problemov sem imel tudi s preverjanjem pravilnosti gesla, ki si ga izbere uporabnik pri registraciji, nato pa sem za preverjanje pravilnosti gesla napravil tri pomožne metode,ki gredo čez celetono geslo črko po črko (char po char) in če se črka ujema z določein pogojem povečam števec, ki ga nakoncu tudi vrnem. Če je ta števec primeren potem se dodajanje izvede drugače se javi napaka.

Delovanje strani Chat je podprto s SqlDataSource preko katerega pridobimo celoten pogovor ter ga shranjujemo v bazo.
Imel sem kar precej težav s pridobivanjem podatkov najprej, po kratkem brskanju po internetu sem našel rešitev, enke težave sem imel pri shranjevaju.

Blaž Ocepek: Jaz sem sprogramiral Chat stran, ter postavil Github.

Tjaž Špegel: Jaz sem postavil bazo, ter sprogramiral Log in stran

//vnesi 2 uporabnika v bazo s katerima se lahko prijavimo
