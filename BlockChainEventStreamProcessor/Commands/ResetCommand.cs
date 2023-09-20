using Program.AppState;
using Program.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Program.Commands
{
    /// <summary>
    /// To handle --reset[file.json]
    /// </summary>
    public class ResetCommand : ICommand
    {
        public string Execute()
        {
            new BlockChainTransaction().Reset();

            return "Program was reset";
        }
    }
}
