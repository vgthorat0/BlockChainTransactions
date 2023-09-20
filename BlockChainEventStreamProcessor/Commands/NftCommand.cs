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
    /// Command to handle --nft [tokenId]
    /// </summary>
    public class NftCommand : ICommand
    {
        /// <summary>
        /// Command line arguments
        /// </summary>
        string[] Args { get; set; }

        /// <summary>
        /// Constructor for argument initialization
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public NftCommand(string[] args)
        {
            Args = args;
        }

        public string Execute()
        {
            if (Args.Length < 2)
                throw new ArgumentException("TokenId is not provided!");
            
            string tokenId = Args[1];

            var tokenInfo = new BlockChainTransaction().GetWallteByToken(tokenId);

            if (tokenInfo != null)
            {
                return $"Token {tokenInfo.TokenId} is owned by {tokenInfo.Address}";
            }
            else
            {
                return $"Token {tokenId} is not owned by any wallet";
            }
        }
    }
}
