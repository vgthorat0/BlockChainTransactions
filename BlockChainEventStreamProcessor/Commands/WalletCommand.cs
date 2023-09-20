using Program.AppState;
using Program.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Program.Commands
{
    /// <summary>
    /// Executes wallter command
    /// </summary>
    public class WalletCommand : ICommand
    {
        /// <summary>
        /// Command line parameters
        /// </summary>
        string[] Args { get; set; }

        /// <summary>
        /// Constructor for argument initialization
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public WalletCommand(string[] args)
        {
            Args = args;
        }

        /// <summary>
        /// Executes wallet command for specified arguments
        /// </summary>
        /// <returns>result message</returns>
        /// <exception cref="ArgumentException">Invalid arguments are provided.</exception>
        public string Execute()
        {
            if (Args.Length < 2)
                throw new ArgumentException("TokenId is not provided!");
            string address = Args[1];

            var tokenInfo = new BlockChainTransaction().GetTokensByWallet(address);

            if (tokenInfo != null && tokenInfo.Count > 0)
            {
                return $"Wallet {address} holds 2 Tokens:\n{string.Join( "\n", tokenInfo.Select(t => t.TokenId).ToArray())}";
            }
            else
            {
                return $"Wallet {address} holds no Tokens";
            }
        }
    }
}
