using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Commands
{
    /// <summary>
    /// Get the matching command for arguments passed
    /// </summary>
    public class CommandInvoker
    {
        ICommand cmd = null;

        /// <summary>
        /// Retruens the command object for specified arguments
        /// </summary>
        /// <param name="args">Command line argument list</param>
        /// <returns>Command object belogs to command invoked</returns>
        public ICommand GetCommand(string[] args)
        {
            switch (args[0])
            {
                case "--read-inline":
                    return new ReadInlineCommand(args);
                case "--read-file":
                    return new ReadFileCommand(args);
                case "--nft":
                    return new NftCommand(args);
                case "--wallet":
                    return new WalletCommand(args);
                case "—-reset":
                    return new ResetCommand();
                default:
                    // invalid command
                    return null;
            }

        }
    }
}
