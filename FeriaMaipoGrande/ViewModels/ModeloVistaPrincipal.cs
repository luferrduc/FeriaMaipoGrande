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

        public ModeloVistaPrincipal()
        {
            MostrarVistaContratos = new VistaModeloComandos(ExecuteMostrarVistaContratosComandos);
            MostrarVistaPersonas = new VistaModeloComandos(ExecuteMostrarVistaPersonasComandos);
            MostrarVistaUsuarios = new VistaModeloComandos(ExecuteMostrarVistaUsuariosComandos);
            MostrarVistaSubastas = new VistaModeloComandos(ExecuteMostrarVistaSubastasComandos);
        }

        private void ExecuteMostrarVistaContratosComandos(object obj)
        {
            CurrentChildView = new ModeloVistaContratos();
            Caption = "Gestión de contratos";
            Icon = IconChar.FileContract;
        }

        private void ExecuteMostrarVistaPersonasComandos(object obj)
        {
            CurrentChildView = new VistaGestionPersonas();
            Caption = "Gestión de Personas";
            Icon = IconChar.IdCard;
        }

        private void ExecuteMostrarVistaUsuariosComandos(object obj)
        {
            CurrentChildView = new VistaGestionUsuarios();
            Caption = "Gestión de usuarios";
            Icon = IconChar.User;
        }

        private void ExecuteMostrarVistaSubastasComandos(object obj)
        {
            CurrentChildView = new ModeloVistaSubasta();
            Caption = "Gestión de subastas";
            Icon = IconChar.Briefcase;
        }

        public ModeloVistaBase CurrentChildView
        {   get
            { 
                return _currentChildView;
            }  
            set
            { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }  
        }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); }  }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); }  }

        public ICommand MostrarVistaContratos { get; }
        public ICommand MostrarVistaPersonas { get; }
        public ICommand MostrarVistaUsuarios { get; }
        public ICommand MostrarVistaSubastas { get; }
    }
}
