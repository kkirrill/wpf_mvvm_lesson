using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_mvvm_lesson.Infrastructure.Commands;
using wpf_mvvm_lesson.ViewModels.Base;


namespace wpf_mvvm_lesson.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        /// <summary> Заголовок окна </summary>
        private string _Title = "Анализ статистики CV19";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
            /*{
                //if (Equals(_Title, value)) return;
                //_Title = value;
                //OnPropertyChanged();
                Set(ref _Title, value);
            } */
        }
        #endregion

        #region Status : string - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status
        { 
            get => _Status; 
            set => Set(ref _Status, value); 
        }

        #endregion

        #region Команды

        #region CloseApplicationCommand 

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }



        #endregion
        #endregion
        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }

        
    }
}
