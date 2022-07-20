using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel
{
    class Page1ViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Mensaje;
        string _Numero1;
        string _Numero2;
        string _Resultado;

        bool _Visible;

        #endregion

        #region CONSTRUCTOR
        public Page1ViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS
        public string Mensaje
        {
            get { return _Mensaje; }
            set
            {
                SetValue(ref _Mensaje, value);
            }
        }

        public string Numero1
        {
            get { return _Numero1; }
            set
            {
                SetValue(ref _Numero1, value);
            }
        }

        public string Numero2
        {
            get { return _Numero2; }
            set
            {
                SetValue(ref _Numero2, value);
            }
        }

        public string Resultado
        {
            get { return _Resultado; }
            set
            {
                SetValue(ref _Resultado, value);
            }
        }

        public bool Visible
        {
            get { return _Visible; }
            set
            {
                SetValue(ref _Visible, value);
            }
        }
        #endregion

        #region PROCESOS
        public async Task AlertaAsyncrono()
        {
            await DisplayAlert("Titulo", Mensaje, "OK");
        }

        public void Sumar()
        {
            if (string.IsNullOrEmpty(Numero1) || string.IsNullOrEmpty(Numero2))
            {
                Visible = false;
                return;
            }
            Visible = true;
            int suma = Convert.ToInt32(Numero1) + Convert.ToInt32(Numero2);
            Resultado = suma.ToString();
            
        }
        #endregion

        #region COMANDOS
        public ICommand AlertAsyncCommand => new Command(async () => await AlertaAsyncrono());
        public ICommand SumarCommand => new Command(Sumar);
        #endregion
    }
}
