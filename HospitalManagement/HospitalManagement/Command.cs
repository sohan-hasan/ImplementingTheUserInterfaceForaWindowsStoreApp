using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace HospitalManagement
{
    public class Command : ICommand
    {

        private Action methodToExecute = null;
        private Func<bool> mothodToDetectCanExecute = null;
        private DispatcherTimer canExecuteChangedEventTimer = null;
        public Command(Action methodToExecute, Func<bool> mothodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.mothodToDetectCanExecute = mothodToDetectCanExecute;
            this.canExecuteChangedEventTimer = new DispatcherTimer();
            this.canExecuteChangedEventTimer.Tick += canExecuteChangedEventTimer_Tick;
            this.canExecuteChangedEventTimer.Interval = new TimeSpan(0, 0, 1);
            this.canExecuteChangedEventTimer.Start();
        }
        void canExecuteChangedEventTimer_Tick(object sender, object e)
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            if (this.mothodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.mothodToDetectCanExecute();
            }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

    }
}
