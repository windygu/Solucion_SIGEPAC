using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UI
{
    public class ObservableObjects
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        internal string buscaCorreo (string correo) //juan.mario@gmail.com
        {
            string pattern = @"(\w+.)?\w+@\w+[.]\w+";
            Regex rg = new Regex(pattern);
            if (correo != null)
            {
                if (rg.IsMatch(correo) == true) return "Se ha encontrado";
                else if (correo.Length>0) return "No se ha encontrado correo";
            }
            return null;
        }

        internal string buscarDui (string dui)  // 45544554-4
        {
            string pattern = @"\d{8}[-]\d";
            Regex rg = new Regex(pattern);
            if (dui != null)
            {
                if ((rg.IsMatch(dui) == true)) return "Se ha encontrado";
                else if (dui.Length>0) return "No se ha encontrado dui";
            }
            return null;
        }
    }
   
}
