using FeriaMaipoGrande.ViewModels;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FeriaMaipoGrande;

namespace FeriaMaipoGrande.ViewModels
{
    public class ModeloVistaPrincipal : ModeloVistaBase
    {
        private ModeloVistaBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ICommand MostrarVistaContratos { get; }
        public ICommand MostrarVistaPersonas { get; }
        public ICommand MostrarVistaUsuarios { get; }
        public ICommand MostrarVistaSubastas { get; }

        public ModeloVistaBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        public ModeloVistaPrincipal()
        {
            MostrarVistaContratos = new VistaModeloComandos(PerformExecuteMostrarVistaSubastasComandos);
            MostrarVistaPersonas = new VistaModeloComandos(PerformExecuteMostrarVistaPersonasComandos);
            MostrarVistaUsuarios = new VistaModeloComandos(PerformExecuteMostrarVistaUsuariosComandos);
            MostrarVistaSubastas = new VistaModeloComandos(PerformExecuteMostrarVistaSubastasComandos);

            PerformExecuteMostrarVistaUsuariosComandos(null);
        }

        //private void ExecuteMostrarVistaContratosComandos(object obj)
       // {
        //    CurrentChildView = new ModeloVistaContratos();
        //    Caption = "Gestión de contratos";
       //     Icon = IconChar.FileContract;
       // }

        //private void ExecuteMostrarVistaPersonasComandos(object obj)
       // {
        //    CurrentChildView = new VistaGestionPersonas();
        //    Caption = "Gestión de Personas";
        //    Icon = IconChar.IdCard;
       // }

        //private void ExecuteMostrarVistaUsuariosComandos(object obj)
      //  {
        //    CurrentChildView = new VistaGestionUsuarios();
       //     Caption = "Gestión de usuarios";
        //    Icon = IconChar.User;
       // }

        //private void ExecuteMostrarVistaSubastasComandos(object obj)
       // {
       //     CurrentChildView = new ModeloVistaSubasta();
       //     Caption = "Gestión de subastas";
       //     Icon = IconChar.Briefcase;
       // }

        private VistaModeloComandos executeMostrarVistaPersonasComandos;

        public ICommand ExecuteMostrarVistaUsuariosComandos
        {
            get
            {
                if (executeMostrarVistaPersonasComandos == null)
                {
                    executeMostrarVistaPersonasComandos = new VistaModeloComandos(PerformExecuteMostrarVistaUsuariosComandos);
                }

                return executeMostrarVistaPersonasComandos;
            }
        }

        private void PerformExecuteMostrarVistaUsuariosComandos(object commandParameter)
        {
            CurrentChildView = new VistaGestionUsuarios();
            Caption = "Gestión de usuarios";
            Icon = IconChar.User;
        }

        private VistaModeloComandos executeMostrarVistaPersonasComandos1;

        public ICommand ExecuteMostrarVistaPersonasComandos
        {
            get
            {
                if (executeMostrarVistaPersonasComandos1 == null)
                {
                    executeMostrarVistaPersonasComandos1 = new VistaModeloComandos(PerformExecuteMostrarVistaPersonasComandos);
                }

                return executeMostrarVistaPersonasComandos1;
            }
        }

        private void PerformExecuteMostrarVistaPersonasComandos(object commandParameter)
        {
            CurrentChildView = new VistaGestionPersonas();
            Caption = "Gestión de personas";
            Icon = IconChar.IdCard;
        }

        private VistaModeloComandos executeMostrarVistaSubastasComandos;

        public ICommand ExecuteMostrarVistaSubastasComandos
        {
            get
            {
                if (executeMostrarVistaSubastasComandos == null)
                {
                    executeMostrarVistaSubastasComandos = new VistaModeloComandos(PerformExecuteMostrarVistaSubastasComandos);
                }

                return executeMostrarVistaSubastasComandos;
            }
        }

        private void PerformExecuteMostrarVistaSubastasComandos(object commandParameter)
        {
            CurrentChildView = new ModeloVistaSubasta();
            Caption = "Gestión de subastas";
            Icon = IconChar.Briefcase;
        }

        private VistaModeloComandos executeMostrarVistaContratosComandos;

        public ICommand ExecuteMostrarVistaContratosComandos
        {
            get
            {
                if (executeMostrarVistaContratosComandos == null)
                {
                    executeMostrarVistaContratosComandos = new VistaModeloComandos(PerformExecuteMostrarVistaContratosComandos);
                }

                return executeMostrarVistaContratosComandos;
            }
        }

        private void PerformExecuteMostrarVistaContratosComandos(object commandParameter)
        {
            CurrentChildView = new ModeloVistaContratos();
            Caption = "Gestión de contratos";
            Icon = IconChar.FileContract;
        }
    }
}
