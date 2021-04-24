namespace ViewModel.Commands
{
    using DataModel;

    using SmallApplicationFramework.Command;

    public class SaveCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            bool hasChanges = DatabaseContext.Instance.DataSet.HasChanges();
            return hasChanges;
        }

        public override void Execute(object parameter)
        {
            DatabaseContext.Instance.Save();
        }
    }
}