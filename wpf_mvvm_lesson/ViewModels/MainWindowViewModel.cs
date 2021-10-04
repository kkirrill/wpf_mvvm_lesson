using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_mvvm_lesson.Infrastructure.Commands;
using wpf_mvvm_lesson.ViewModels.Base;
using wpf_mvvm_lesson.Models;
using System.Collections.ObjectModel;
using wpf_mvvm_lesson.Models.Decant;

namespace wpf_mvvm_lesson.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /*-------------------------------------------------------------------------------------*/

        public ObservableCollection<Group> Groups { get; set; }

        public object[] CompositeCollection { get; }

        #region выбранный элемент с неизвестным типом

        private object _SelectedCompositeValue;

        public object SelectedCompositeValue { get => _SelectedCompositeValue; set => Set(ref _SelectedCompositeValue, value); }

        #endregion

        #region Выбранная группа

        private Group _SelectedGroup;

        #endregion

        #region Индекс выбранной группы

        public Group SelectedGroup { get => _SelectedGroup; set => Set(ref _SelectedGroup, value);  }

        #endregion

        #region Тестовые данные для графика

        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints; set => Set(ref _TestDataPoints, value); }

        #endregion

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

        /*-------------------------------------------------------------------------------------*/

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

        /*-------------------------------------------------------------------------------------*/

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion


            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * to_rad);
                data_points.Add( new DataPoint { XValue = x, YValue = y });

            }

            TestDataPoints = data_points;

            var students_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {students_index}",
                Surname = $"Surname {students_index}",
                Patronomic = $"Patronomic {students_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            }) ;

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);

            var data_list = new List<object>();
            data_list.Add("hello world");
            data_list.Add(123);
            var group = Groups[1];
            data_list.Add(group);
            data_list.Add(group.Students[0]);

            CompositeCollection = data_list.ToArray();
             

        }

        
    }
}
