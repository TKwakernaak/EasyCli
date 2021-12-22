using System.Threading.Tasks;

namespace EasyCli.Menu
{
    public interface ICliAction
    {
        /// <summary>
        /// Description of the action to perform
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Execute an cli action.
        /// </summary>
        Task RunAsync();
    }
}