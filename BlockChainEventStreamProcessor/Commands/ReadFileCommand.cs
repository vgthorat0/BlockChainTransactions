using Newtonsoft.Json;
using Program.BusinessObjects;
using Program.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Commands
{
    /// <summary>
    /// To handle --read-file [file.json]
    /// </summary>
    internal class ReadFileCommand :ICommand
    {

        /// <summary>
        /// Argument initialization
        /// </summary>
        string[] Args { get; set; }
        /// <summary>
        /// Constructor for argument initialization
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public ReadFileCommand(string[] args) 
        {
            Args = args;
        }

        public string Execute()
        {
            if (Args.Length < 2)
                throw new ArgumentException("Transaction data not provided!");

            if(!File.Exists(Args[1]))
                throw new FileNotFoundException($"File not found! File:{Args[1]}");

            var txnInputData = File.ReadAllText(Args[1]).ReadTokenData();
            
            return txnInputData.Process();
        }
    }
}
