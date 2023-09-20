using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.BusinessObjects
{
    /// <summary>
    /// Input Token Data from json 
    /// </summary>
    public class InputTokenData
    {
        /// <summary>
        /// Type of transaction; from one of - Mint , Burn or Transaction
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// TokenId of blockchain
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Wallet address of block chain
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Wallet address from token will be transfered from
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Wallet address to where tokne will be transfered
        /// </summary>
        public string To { get; set; }

    }
}
