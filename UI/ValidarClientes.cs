using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace UI
{
    public class ValidarClientes : ObservableObjects, IDataErrorInfo
    {
        string pNombre, pApellido, sApellido, dui, direccion, telefono, correo;

        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        
        public string this[string name]   
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "PRIMERNOMBRE":
                        if (string.IsNullOrWhiteSpace(PRIMERNOMBRE))
                            result = "Campo obligatorio";
                        break;
                    case "PRIMERAPELLIDO":
                        if (string.IsNullOrWhiteSpace(PRIMERAPELLIDO))
                            result = "Campo obligatorio";
                        break;
                    case "SEGUNDOAPELLIDO":
                        if (string.IsNullOrWhiteSpace(SEGUNDOAPELLIDO))
                            result = "Campo obligatorio";
                        break;
                    case "DUI":
                        if (string.IsNullOrWhiteSpace(DUI))
                            result = "Campo obligatorio";
                        else if (buscarDui(DUI) == "No se ha encontrado dui")
                            result = "DUI inválido";
                        break;
                    case "DIRECCION":
                        if (string.IsNullOrWhiteSpace(DIRECCION))
                            result = "Campo obligatorio";
                        break;
                    case "TELEFONO":
                        if (string.IsNullOrWhiteSpace(TELEFONO))
                            result = "Campo obligatorio";
                        break;
                    case "CORREO":
                        if (buscaCorreo(CORREO)== "No se ha encontrado correo")
                            result = "Correo inválido";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public string PRIMERNOMBRE
        {
            get { return pNombre; }
            set
            {
                OnPropertyChanged(ref pNombre, value);
                
            }
        }


        public string PRIMERAPELLIDO
        {
            get { return pApellido; }
            set
            {
                OnPropertyChanged(ref pApellido, value);
            }
        }
        public string SEGUNDOAPELLIDO
        {
            get { return sApellido; }
            set
            {
                OnPropertyChanged(ref sApellido, value);
                
            }
        }
        public string DUI
        {
            get
            {
                return dui;
            }
            set
            {
                OnPropertyChanged(ref dui, value);
                
            }
        }
        public string DIRECCION
        {
            get { return direccion; }
            set
            {
                OnPropertyChanged(ref direccion, value);
                
            }
        }
        public string TELEFONO
        {
            get { return telefono; }
            set
            {
                OnPropertyChanged(ref telefono, value);
               
            }
        }
        public string CORREO
        {
            get { return correo; }
            set
            {
                OnPropertyChanged(ref correo, value);
            }
        }

       
    }
}
