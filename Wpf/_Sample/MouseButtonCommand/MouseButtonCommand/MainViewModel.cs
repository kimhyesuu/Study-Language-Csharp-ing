using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MouseButtonCommand
{
    public class MainViewModel : INotifyPropertyChanged, IWindowResources
    {
        public MainViewModel()
        {
            DragMoveCommand = new DelegateCommand(OnDrag);
        }


        private void OnDrag()
        {
            DrageMove?.Invoke();
        }

        // 1
        public Action DrageMove { get; set; }

        private RelayCommand _mouseMoveCommand;
        public RelayCommand MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand is null) return _mouseMoveCommand = new RelayCommand(param => ExecuteMouseMove(param as MouseEventArgs));
                return _mouseMoveCommand;
            }
            set { _mouseMoveCommand = value; }
        }

        public DelegateCommand DragMoveCommand { get; private set; }

        private void ExecuteMouseMove(MouseEventArgs e)
        {
          
            Debug.WriteLine("Mouse Move : " + e.GetPosition((IInputElement)e.Source));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }


    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private string _displayText;

        public static List<string> Log = new List<string>();
        private Action<object> action;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : this(execute, canExecute, "")
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, string displayText)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
            _displayText = displayText;
        }


        public string DisplayText
        {
            get { return _displayText; }
            set { _displayText = value; }
        }

        #endregion // Constructors

        #region ICommand Members

 
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            
            _execute(parameter);
        }

        #endregion // ICommand Members
    }
}
