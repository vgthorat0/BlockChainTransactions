using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Commands
{
    /// <summary>
    /// Interface for commands 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the commands for povided arguments
        /// </summary>
        /// <returns>Result of command execution</returns>
        public string Execute();
    }
}
