using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Functionality
{
   public class DataWithForeignKey : DatabaseClass
    {
        public DataWithForeignKey(LgSchoolEntities lgSdatabase)
            :base(lgSdatabase)
        {

        }
        public List<MaterialyForAllView> PobierzMaterialy()
        {
            return
                (
                   from item in lgSdatabase.Materialy
                   select new MaterialyForAllView
                   {
                       MaterialID = item.materialID,
                       Tytul = item.tytul,
                       GatunekNazwa = item.Gatunek.nazwa,
                       PoziomNazwa = item.Poziom.nazwa,
                       AutorNazwa = item.Autor.imie + " " + item.Autor.nazwisko,
                       TypNazwa = item.TypyMaterialow.nazwa
                   }
                ).ToList();
        }
        public List<GrupyForAllView> PobierzGrupy()
        {
            return
                (
                   from item in lgSdatabase.Grupa
                   select new GrupyForAllView
                   {
                      GrupaID = item.grupaID,
                      Numer = item.grupaNumer,
                      Nazwa = item.nazwa,
                      Opis = item.opis,
                      PoziomNazwa = item.Poziom.nazwa,
                      UczenNazwa = item.Uczen.imie + item.Uczen.nazwisko,
                      KursNazwa = item.Kurs.nazwa
                   }
                ).ToList();
        }
        public List<KursyForAllView> PobierzKursy()
        {
            return
                (
                   from item in lgSdatabase.Kurs
                   select new KursyForAllView
                   {
                       KursID = item.kursID,
                       Nazwa = item.nazwa,
                       Opis = item.opis,
                       PoziomNazwa = item.Poziom.nazwa,
                       PracownikNazwa = item.Pracownik.nazwisko + " " + item.Pracownik.imie
                   }
                ).ToList();
        }
        public List<CennikiForAllView> PobierzCennik()
        {
            return
                (
                   from item in lgSdatabase.Cennik
                   select new CennikiForAllView
                   {
                       CennikID = item.cennikID,
                       KursNazwa = item.Kurs.nazwa,
                       KursPoziom = item.Kurs.Poziom.nazwa,
                       Cena = item.cena,
                       Opis = item.opis                       
                   }
                ).ToList();
        }
        public List<UczniowieForAllView> PobierzUczniow()
        {
            return
                (
                   from item in lgSdatabase.Uczen
                   select new UczniowieForAllView
                   {
                       UczenID = item.uczenID,
                       Imie = item.imie,
                       Nazwisko = item.nazwisko,
                       DataUrodzenia = item.dataUrodzenia,
                       Pesel = item.pesel,
                       Telefon = item.telefon,
                       TelefonOpiekuna = item.telefonOpiekuna,
                       Email = item.email,
                       //GrupaID = item.Grupa.grupaID,
                       StatusNazwa = item.Status.nazwa
                   }
                ).ToList();
        }
        public List<PracownicyForAllView> PobierzPracownikow()
        {
            return
                (
                   from item in lgSdatabase.Pracownik
                   select new PracownicyForAllView
                   {
                       PracownikID = item.pracownikID,
                       Imie = item.imie,
                       Nazwisko = item.nazwisko,
                       DataUrodzenia = item.dataUrodzenia,
                       Pesel = item.pesel,
                       Ulica = item.ulica,
                       Numer = item.numer,
                       KodPocztowy = item.kodPocztowy,
                       Miejscowosc = item.miejscowosc,                       
                       Telefon = item.telefon,
                       Email = item.email,
                       StanowiskoNazwa = item.Stanowisko.nazwaStanowiska,
                       DataZatrudnienia = item.dataZatrudnienia,
                       DataZwolnienia = item.dataZwolnienia
                   }
                ).ToList();
        }
        //public List<FakturyForAllView> PobierzFaktury()
        //{
        //    return
        //        (
        //           from item in lgSdatabase.Faktura
        //           select new FakturyForAllView
        //           {
        //              FakturaID = item.fakturaID,
        //              NumerFaktury = item.numerFaktury,
        //              FirmaNazwa = item.Firma.nazwa,
        //              FirmaNip = item.Firma.nip,
        //              RodzajPlatnosciNazwa = item.RodzajPlatnosci.nazwaPlatnosci,
        //              DataWystawienia = item.dataWystawienia,
        //              TerminPlatnosci = item.terminPlatnosci,
        //              DataWplaty = item.terminPlatnosci
        //           }
        //        ).ToList();
        //}
        public List<WplatyForAllView> PobierzWplaty()
        {
            return
                (
                   from item in lgSdatabase.Wplata
                   select new WplatyForAllView
                   {
                       WplataID = item.wplataID,
                       UczenImie = item.Uczen.imie,
                       UczenNazwisko = item.Uczen.nazwisko,
                       FirmaNazwa = item.Firma.nazwa,
                       DataWplaty = item.data,
                       RodzajPlatnosciNazwa = item.RodzajPlatnosci.nazwaPlatnosci
                   }
                ).ToList();
        }
        public List<UzytkownicyForAllView> PobierzUzytkownikow()
        {
            return
                (
                   from item in lgSdatabase.Uzytkownik
                   select new UzytkownicyForAllView
                   {
                       UzytkownikID = item.uzytkownikID,
                       Login = item.login,
                       Haslo = item.haslo
                   }
                ).ToList();
        }
        public List<OcenyForAllView> PobierzOceny()
        {
            return
                (
                   from item in lgSdatabase.Ocena
                   select new OcenyForAllView
                   {
                       OcenaID = item.ocenaID,
                       Nazwa = item.nazwa,
                       Opis = item.opis,
                      // UczenID = item.uczenID
                   }
                ).ToList();
        }
        public List<TytulyWplatForAllView> PobierzTytulyWplat()
        {
            return
                (
                   from item in lgSdatabase.TytulWplaty
                   select new TytulyWplatForAllView
                   {
                       TytulWplatyID = item.tytulWplatyID,
                       WplataNumer = item.Wplata.numerWplaty,
                       KursNazwa = item.Kurs.nazwa,
                       Cena = item.cena,
                       IloscGodzin = item.iloscGodzin
                   }
                ).ToList();
        }
        public List<FirmyForAllView> PobierzFirmy()
        {
            return
                (
                   from item in lgSdatabase.Firma
                   select new FirmyForAllView
                   {
                       FirmaID = item.firmaID,
                       Nazwa = item.nazwa,
                       Opis = item.opis,
                       Nip = item.nip,
                       Regon = item.regon,
                       Telefon1 = item.telefon1,
                       Telefon2 = item.telefon2,
                       Fax = item.fax,
                       Email = item.email,
                       OsobaKontaktowa = item.osobaKontaktowa
                   }
                ).ToList();
        }
        public List<ListaDoGrupyForAllView> PobierzListyDoGrup()
        {
            return
                (
                   from lista in lgSdatabase.ListaDoGrup
                   select new ListaDoGrupyForAllView
                   {
                       GrupaNumer = lista.Grupa.grupaNumer,
                       GrupaNazwa = lista.Grupa.nazwa,
                       UczenImie = lista.Uczen.imie,
                       UczenNazwisko = lista.Uczen.nazwisko,
                       UczenPesel = lista.Uczen.pesel
                   }
                ).ToList();
        }
        public List<OcenyUczniaForAllView> PobierzListyDoUczniow()
        {
            return
                (
                   from lista in lgSdatabase.OcenyUcznia
                   select new OcenyUczniaForAllView
                   {
                       UczenImie = lista.Uczen.imie,
                       UczenNazwisko = lista.Uczen.nazwisko,
                       OcenaID = lista.ocenaID,
                       OcenaNazwa = lista.Ocena.nazwa,
                       OcenaOpis = lista.Ocena.opis,
                       //KategoriaNazwa = lista.KategoriaOcen.nazwa,
                       //DataWpisu = lista.data,
                       //PracownikNazwa = lista.Pracownik.imie + " " + lista.Pracownik.nazwisko
                   }
                ).ToList();
        }
    }
}