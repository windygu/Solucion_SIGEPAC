using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ValidarMarcas : ObservableObjects, IDataErrorInfo
    {
        string pNombre, pComentario;

        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "NOMBRE":
                        if (string.IsNullOrWhiteSpace(NOMBRE))
                            result = "Campo obligatorio";
                        break;
                    case "COMENTARIO":
                        if (string.IsNullOrWhiteSpace(COMENTARIO))
                            result = "Campo obligatorio";
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

        public string NOMBRE
        {
            get { return pNombre; }
            set
            {
                OnPropertyChanged(ref pNombre, value);

            }
        }

        public string COMENTARIO
        {
            get { return pComentario; }
            set
            {
                OnPropertyChanged(ref pComentario, value);
            }
        }
    }
}

