using Newtonsoft.Json;
using Program.BusinessObjects;
using Program.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Program.Commands
{
    /// <summary>
    /// To handle --read-inline '{ "key": "value"}'
    /// </summary>
    public class ReadInlineCommand :ICommand
    {

        /// <summary>
        /// Command line arguments
        /// </summary>
        string[] Args { get; set; }
        /// <summary>
        /// Constructor for argument initialization
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public ReadInlineCommand(string[] args) 
        {
            Args = args;
        }

        public string Execute()
        {
            if (Args.Length < 2)
                throw new ArgumentException("Transaction data not provided!");

            
            // Convert list of arguments to single json string
            string[] jsonArgs = Args.Skip(1).ToArray();
            string jsonObject = Regex.Replace(Regex.Replace(String.Join("", jsonArgs),":", "\":\""),",", "\",\"").Replace("{", "{\"").Replace("}", "\"}").Substring(1);
            jsonObject = jsonObject.Substring(0, jsonObject.Length - 1);

            //convert json string to object list
            var txnInputData = jsonObject.ReadTokenData();
            return txnInputData.Process();
        }
    }
}
