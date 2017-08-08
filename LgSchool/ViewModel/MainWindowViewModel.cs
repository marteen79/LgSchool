using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model;
using MVVMFirma.Pomocniczy;
using MVVMFirma.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //to jest kolekcja linkow ktore znajduja sie z lewej strony okna
        private ReadOnlyCollection<CommandViewModel> _Commands;
        //to jest kolekcja zakladek wywolujacych sie z prawej strony okna
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields

        #region Commands
        //tworzymy komendy do wywolywania zakladek z poziomu menu i paska narzedzi
        public ICommand AddStudent
        {
            get
            {
                return new BaseCommand(createListaUczniow);
            }
        }
        public ICommand AddGrade
        {
            get
            {
                return new BaseCommand(createListaOcen);
            }
        }
        public ICommand ShowGroupMembers
        {
            get
            {
                return new BaseCommand(showListaUczniow);
            }
        }
        public ICommand ShowAllGrades
        {
            get
            {
                return new BaseCommand(showListaOcen);
            }
        }
        public ICommand PokazUczniow
        {
            get
            {
                return new BaseCommand(showUczniowie);
            }
        }
        public ICommand DodajUcznia
        {
            get
            {
                return new BaseCommand(createUczniowie);
            }
        }
        public ICommand PokazFirmy
        {
            get
            {
                return new BaseCommand(showFirmy);
            }
        }
        public ICommand DodajFirme
        {
            get
            {
                return new BaseCommand(createFirmy);
            }
        }
        public ICommand PokazKursy
        {
            get
            {
                return new BaseCommand(showKursy);
            }
        }
        public ICommand PokazGrupy
        {
            get
            {
                return new BaseCommand(showGrupy);
            }
        }
        public ICommand PokazPracownicy
        {
            get
            {
                return new BaseCommand(showPracownicy);
            }
        }
        public ICommand PokazCennik
        {
            get
            {
                return new BaseCommand(showCenniki);
            }
        }
        public ICommand PokazMaterialy
        {
            get
            {
                return new BaseCommand(showMaterialy);
            }
        }
        public ICommand PokazFaktury
        {
            get
            {
                return new BaseCommand(showFaktury);
            }
        }
        public ICommand PokazWplaty
        {
            get
            {
                return new BaseCommand(showWplaty);
            }
        }
        public ICommand PokazUzytkownicy
        {
            get
            {
                return new BaseCommand(showUzytkownicy);
            }
        }
        public ICommand DodajUzytkownika
        {
            get
            {
                return new BaseCommand(createUzytkownicy);
            }
        }

        #endregion Commands

        #region Properties
        //to jest properties do kolekcji linkow
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get 
            {
                if (_Commands == null)
                {
                    //Jezeli zbior komend jest pusty
                    //tworze chwilowa liste, tylko po to by ja wypelnic
                    List<CommandViewModel> cmds = this.CreateCommands();
                    //i zrobic z niej kolekcje tylko do odczytu
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        public List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);

            return new List<CommandViewModel>
            {
                // wyświetlanie linków z menu bocznym

                  new CommandViewModel("Oceny",
                    new BaseCommand(()=>this.showOceny())),
                  new CommandViewModel("Kategorie ocen",
                    new BaseCommand(()=>this.showKategorie())),
                  new CommandViewModel("Poziomy",
                    new BaseCommand(()=>this.showPoziomy())),
                  new CommandViewModel("Wszyscy autorzy",
                    new BaseCommand(()=>this.showAutorzy())),
                  new CommandViewModel("Statusy",
                    new BaseCommand(()=>this.showStatusy())),
                  new CommandViewModel("Typy materiałów",
                    new BaseCommand(()=>this.showTypyMaterialow())),
                  //new CommandViewModel("Uczniowie w grupie",
                  //  new BaseCommand(()=>this.showListaUczniow())),
                  //new CommandViewModel("Dodaj do grupy",
                  //  new BaseCommand(()=>this.createListaUczniow())),
                  //new CommandViewModel("Oceny uczniów",
                  //  new BaseCommand(()=>this.showListaOcen())),
                  //new CommandViewModel("Dodaj oceny",
                  //  new BaseCommand(()=>this.createListaOcen())),



                  // TRIAL TABS

                  //new CommandViewModel("Tytuły wpłat",
                  //  new BaseCommand(()=>this.showTytulyWplat())),
                  //new CommandViewModel("Nowy tytuł wpłat",
                  //  new BaseCommand(()=>this.createTytulyWplat())),
                  //new CommandViewModel("Nowa grupa",
                  //  new BaseCommand(()=>this.createGrupy())),
            };
        }
        #endregion Properties

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.NewItems)
                {
                    workspace.RequestClose += this.OnWorkspaceRequestClose;
                }
            }
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.OldItems)
                {
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
                }
            }
        }
        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion Workspaces

        #region PrivateHelpers
        private void showPoziomy()
        {
            WszystkiePoziomyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkiePoziomyViewModel)
                as WszystkiePoziomyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkiePoziomyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createPoziomy()
        {
            NowyPoziomViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyPoziomViewModel)
                as NowyPoziomViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyPoziomViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showKategorie()
        {
            WszystkieKategorieOcenViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieKategorieOcenViewModel)
                as WszystkieKategorieOcenViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieKategorieOcenViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createKategorie()
        {
            NowaKategoriaOcenViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaKategoriaOcenViewModel)
                as NowaKategoriaOcenViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaKategoriaOcenViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createGatunki()
        {
            NowyGatunekViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyGatunekViewModel)
                as NowyGatunekViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyGatunekViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showGatunki()
        {
            WszystkieGatunkiViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieGatunkiViewModel)
                as WszystkieGatunkiViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieGatunkiViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createUslugi()
        {
            NowaUslugaViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaUslugaViewModel)
                as NowaUslugaViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaUslugaViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showUslugi()
        {
            WszystkieUslugiViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiViewModel)
                as WszystkieUslugiViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieUslugiViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showUzytkownicy()
        {
            WszyscyUzytkownicyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszyscyUzytkownicyViewModel)
                as WszyscyUzytkownicyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszyscyUzytkownicyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createUzytkownicy()
        {
            NowyUzytkownikViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyUzytkownikViewModel)
                as NowyUzytkownikViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyUzytkownikViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showStatusy()
        {
            WszystkieStatusyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyViewModel)
                as WszystkieStatusyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieStatusyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showAutorzy()
        {
            WszyscyAutorzyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszyscyAutorzyViewModel)
                as WszyscyAutorzyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszyscyAutorzyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createAutorzy()
        {
            NowyAutorViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyAutorViewModel)
                as NowyAutorViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyAutorViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showFirmy()
        {
            WszystkieFirmyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieFirmyViewModel)
                as WszystkieFirmyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieFirmyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createFirmy()
        {
            NowaFirmaViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaFirmaViewModel)
                as NowaFirmaViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaFirmaViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showUczniowie()
        {
            WszyscyUczniowieViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszyscyUczniowieViewModel)
                as WszyscyUczniowieViewModel;
            if (zakladka == null)
            {
                zakladka = new WszyscyUczniowieViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createUczniowie()
        {
            NowyUczenViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyUczenViewModel)
                as NowyUczenViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyUczenViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showPracownicy()
        {
            WszyscyPracownicyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszyscyPracownicyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createPracownicy()
        {
            NowyPracownikViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyPracownikViewModel)
                as NowyPracownikViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyPracownikViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showWplaty()
        {
            WszystkieWplatyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieWplatyViewModel)
                as WszystkieWplatyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieWplatyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createWplaty()
        {
            NowaWplataViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaWplataViewModel)
                as NowaWplataViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaWplataViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showKursy()
        {
            WszystkieKursyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieKursyViewModel)
                as WszystkieKursyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieKursyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createKursy()
        {
            NowyKursViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyKursViewModel)
                as NowyKursViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyKursViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showOceny()
        {
            WszystkieOcenyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieOcenyViewModel)
                as WszystkieOcenyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieOcenyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createOceny()
        {
            NowaOcenaViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaOcenaViewModel)
                as NowaOcenaViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaOcenaViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showCenniki()
        {
            WszystkieCennikiViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieCennikiViewModel)
                as WszystkieCennikiViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieCennikiViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createCenniki()
        {
            NowyCennikViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowyCennikViewModel)
                as NowyCennikViewModel;
            if (zakladka == null)
            {
                zakladka = new NowyCennikViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showGrupy()
        {
            WszystkieGrupyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieGrupyViewModel)
                as WszystkieGrupyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieGrupyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createGrupy()
        {
            NowaGrupaViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaGrupaViewModel)
                as NowaGrupaViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaGrupaViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showFaktury()
        {
            WszystkieFakturyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieFakturyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        //private void showFaktury()
        //{
        //    InvoiceViewModelAll zakladka =
        //        Workspaces.FirstOrDefault(vm => vm is InvoiceViewModelAll)
        //        as InvoiceViewModelAll;
        //    if (zakladka == null)
        //    {
        //        zakladka = new InvoiceViewModelAll();
        //        Workspaces.Add(zakladka);
        //    }
        //    setActiveWorkspace(zakladka);
        //}
        private void createFaktury()
        {
            NowaFakturaViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NowaFakturaViewModel)
                as NowaFakturaViewModel;
            if (zakladka == null)
            {
                zakladka = new NowaFakturaViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void showMaterialy()
        {
            WszystkieMaterialyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is WszystkieMaterialyViewModel)
                as WszystkieMaterialyViewModel;
            if (zakladka == null)
            {
                zakladka = new WszystkieMaterialyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        private void createMaterialy()
        {
            NoweMaterialyViewModel zakladka =
                Workspaces.FirstOrDefault(vm => vm is NoweMaterialyViewModel)
                as NoweMaterialyViewModel;
            if (zakladka == null)
            {
                zakladka = new NoweMaterialyViewModel();
                Workspaces.Add(zakladka);
            }
            setActiveWorkspace(zakladka);
        }
        //private void showRaportSprzedazy()
        //{
        //    RaportSprzedazyViewModel workspace =
        // Workspaces.FirstOrDefault
        // (vm => vm is RaportSprzedazyViewModel)
        // as RaportSprzedazyViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new RaportSprzedazyViewModel();
        //        Workspaces.Add(workspace);
        //    }
        //    setActiveWorkspace(workspace);
        //}

        private void createPozycjaFaktury()
        {
            NowaPozycjaFakturyViewModel workspace =
                new NowaPozycjaFakturyViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void showTypyMaterialow()
        {
            WszystkieTypyMaterialowViewModel workspace =
                new WszystkieTypyMaterialowViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        
            private void createTypyMaterialow()
        {
            NowyTypMaterialowViewModel workspace =
                new NowyTypMaterialowViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createStatusy()
        {
            NowyStatusViewModel workspace =
                new NowyStatusViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void showTytulyWplat()
        {
            WszystkieTytulyWplatViewModel workspace =
                new WszystkieTytulyWplatViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createTytulyWplat()
        {
            NowyTytulWplatyViewModel workspace =
                new NowyTytulWplatyViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void showKategorieOcen()
        {
            WszystkieKategorieOcenViewModel workspace =
                new WszystkieKategorieOcenViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createKategorieOcen()
        {
            NowaKategoriaOcenViewModel workspace =
                new NowaKategoriaOcenViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createListaDoGrupy()
        {
            NowaListaDoGrupyViewModel workspace =
                new NowaListaDoGrupyViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createListaDoOcen()
        {
            NowaListaDoUczniaViewModel workspace =
                new NowaListaDoUczniaViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void showListaUczniow()
        {
            WszystkieListyDoGrupViewModel workspace =
                new WszystkieListyDoGrupViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void showListaOcen()
        {
            WszystkieListyDoUczniaViewModel workspace =
                new WszystkieListyDoUczniaViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }

        private void createListaUczniow()
        {
            NewGroupListViewModel workspace =
                new NewGroupListViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }
        private void createListaOcen()
        {
            NewGradeListViewModel workspace =
                new NewGradeListViewModel();
            Workspaces.Add(workspace);
            setActiveWorkspace(workspace);
        }

        
        //private void showListaOcen()
        //{
        //    WszystkieListyOcenViewModel workspace =
        //        new WszystkieListyOcenViewModel();
        //    Workspaces.Add(workspace);
        //    setActiveWorkspace(workspace);
        //}
        //private void createListaOcen()
        //{
        //    NowaListaDoOcenViewModel workspace =
        //        new NowaListaDoOcenViewModel();
        //    Workspaces.Add(workspace);
        //    setActiveWorkspace(workspace);
        //}


        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }
        // to jest metoda która wywoła się po złapaniu Messengerem 
        // komunikatu typu string - mesenger jest zdefinjowany wyżej w 
        // CreateCommand , komunikat stringowy będzie przekazany 
        // do metody jako parametr wywołania z automatu. 
        private void open(string komunikat)
        {
            if (komunikat == "Poziomy Add")
                createPoziomy();
            if (komunikat == "Uzytkownicy Add")
                createUzytkownicy();
            if (komunikat == "Uzytkownicy Show")
                showUzytkownicy();
            if (komunikat == "Statusy Show")
                showStatusy();
            if (komunikat == "Uczniowie Show")
                showUczniowie();
            if (komunikat == "Uczniowie Add")
                createUczniowie();
            if (komunikat == "Pracownicy Add")
                createPracownicy();
            if (komunikat == "Pracownicy Show")
                showPracownicy();
            if (komunikat == "Wplaty Show")
                showWplaty();
            if (komunikat == "Wplaty Add")
                createWplaty();
            if (komunikat == "Firmy Show")
                showFirmy();
            if (komunikat == "PozycjeFaktury Show")
                createPozycjaFaktury();
            if (komunikat == "Materialy Add")
                createMaterialy();
            if (komunikat == "Typy materialow Add")
                createTypyMaterialow();
            if (komunikat == "Statusy Add")
                createStatusy();
            if (komunikat == "Faktury Add")
                createFaktury();
            if (komunikat == "Grupy Add")
                createGrupy();
            if (komunikat == "Cenniki Add")
                createCenniki();
            if (komunikat == "Materialy Add")
                createMaterialy();
            if (komunikat == "Oceny Add")
                createOceny();
            if (komunikat == "Kursy Add")
                createKursy();
            if (komunikat == "Kursy Show")
                showKursy();
            if (komunikat == "Kategorie ocen Show")
                showKategorieOcen();
            if (komunikat == "Kategorie ocen Add")
                createKategorieOcen();
            if (komunikat == "Firmy Show")
                showFirmy();
            if (komunikat == "Firmy Add")
                createFirmy();
            if (komunikat == "ListaGrupy Show")
                createListaDoGrupy();
            if (komunikat == "ListaOcen Show")
                createListaDoOcen();
            if (komunikat == "Autorzy Add")
                createAutorzy();




        }

        #endregion PrivateHelpers
    }
}
