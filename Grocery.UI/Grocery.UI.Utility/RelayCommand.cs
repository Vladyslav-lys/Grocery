using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Grocery.UI.Utility
{
    public class RelayCommand : ICommand
    {
        public Action execute;
        public Predicate<object> canExecute;

        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("There is no command to execute!");
            this.canExecute = canExecute;
        }

        //Вызывается при изменении условий, указывающий, может ли команда выполняться
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Может ли команда выполняться
        public virtual bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        //Выполняет команду
        public virtual void Execute(object parameter)
        {
            this.execute();
        }
    }
}
