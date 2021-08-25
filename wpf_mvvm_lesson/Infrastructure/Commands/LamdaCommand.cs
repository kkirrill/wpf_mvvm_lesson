using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_lesson.Infrastructure.Commands.Base;

namespace wpf_mvvm_lesson.Infrastructure.Commands
{
    internal class LamdaCommand: Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LamdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            Execute = _Execute ?? throw new ArgumentNullException(nameof(Execute));
            CanExecute = _CanExecute;

        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);

    }
}
