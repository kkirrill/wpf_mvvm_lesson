using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_lesson.ViewModels.Base;

namespace wpf_mvvm_lesson.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    { 
        private string _Title = "Анализ статистики CV19";

        /// <summary>Заголовок окна</summary>
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
    }
}
