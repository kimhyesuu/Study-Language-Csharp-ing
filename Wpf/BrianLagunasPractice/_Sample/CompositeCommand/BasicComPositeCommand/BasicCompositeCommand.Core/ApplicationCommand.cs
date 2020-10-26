using Prism.Commands;

namespace BasicCompositeCommand.Core
{
    public interface IApplicationCommands
    {
         CompositeCommand SaveAllCommand { get; }
    }


    public class ApplicationCommands : IApplicationCommands
    {
        // private CompositeCommand _saveAllCommand = new CompositeCommand();

        public CompositeCommand SaveAllCommand { get; } =  new CompositeCommand();
    }
}
