using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLayer.Business;
using ModelLayer.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DaoPays vmDaoPays;
        private DaoFromage vmDaoFromage;
        private ICommand updateCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;
        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();

        private Fromage monFromage = new Fromage(1, "Rebloch");

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }

        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...

        public string Name
        {
            get => activeFromage.Name;
            set
            {
                if (activeFromage.Name != value)
                {
                    activeFromage.Name = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }

        public Pays Origin
        {
            get 
            {
                if (activeFromage.Origin == null)
                {
                    activeFromage.Origin = null;
                    return null;    
                } 

                else
                {
                    return activeFromage.Origin;
                }
            }
            set
            {
                if (activeFromage.Origin != value)
                {
                    activeFromage.Origin = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Origin");
                }
            }
        }

        public DateTime Creation
        {
            get => activeFromage.Creation;
            set
            {
                if (activeFromage.Creation!= value)
                {
                    activeFromage.Creation = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Creation");
                }
            }
        }


        public Fromage SelectedFromage
        {
            get => selectedFromage;
            set
            {
                if (selectedFromage != value)
                {
                    selectedFromage = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedFromage");
                    ActiveFromage = selectedFromage;
                }
            }
        }

        public Fromage ActiveFromage
        {
            get => activeFromage;
            set
            {
                if (activeFromage != value)
                {
                    activeFromage = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
                }
            }
        }

        //déclaration du contructeur de viewModelFromage
        public viewModelFromage(DaoPays thedaopays, DaoFromage thedaofromage)
        {
            vmDaoPays = thedaopays;

            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());

            vmDaoFromage = thedaofromage;

            listFromages = new ObservableCollection<Fromage>(thedaofromage.SelectAll());

            foreach (Fromage F in ListFromages)
            {
                foreach (Pays P in ListPays)
                {
                    if (F.Origin.Name == P.Name)
                    {
                        F.Origin = P;
                    }
                }
            }
        }

        //Méthode appelée au click du bouton UpdateCommand
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateFromage(), () => true);
                }
                return this.updateCommand;
            }

        }

        private void UpdateFromage()
        {
            this.vmDaoFromage.Update(this.activeFromage);     
        }
    }
}
