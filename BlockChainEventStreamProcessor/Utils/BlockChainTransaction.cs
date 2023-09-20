using Program.BusinessObjects;
using Program.AppState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Program.Utils
{
    /// <summary>
    /// Class to pefrom transactions and update the application state
    /// </summary>
    public class BlockChainTransaction
    {
        /// <summary>
        /// A mint transaction creates a new token in the wallet with the provided address
        /// </summary>
        /// <param name="address">Blockchain Wallet address</param>
        /// <param name="tokenId">Blockchain token Id</param>
        /// <exception cref="Exception">Exception while minting token</exception>
        public void Mint(string address, string tokenId)
        {

            if (ApplicationState.blockChains.Where(t => t.TokenId == tokenId && t.Address == address).ToList().Count > 0)
            {
                // Token is already present
                Log.Information($"Token is already present. Token:{tokenId}, Address:{address}");
                return;
            }

            if (ApplicationState.blockChains.Where(t => t.TokenId == tokenId).ToList().Count > 0)
            {
                // same token is being assigned to multiple wallets
                throw new Exception($"Token can be assigned to single wallet only!  tokenId:{tokenId} address:{address}");
            }
            ApplicationState.blockChains.Add(new BlockChainWallet { TokenId = tokenId, Address = address });
            Log.Information($"Token Added! tokenId:{tokenId}, address:{address}");
        }

        /// <summary>
        /// A burn transaction destroys the token with the given id.
        /// </summary>
        /// <param name="tokenId">Blockchain token Id</param>
        /// <returns>1 if successfully deletes the token from wallet</returns>
        public int Burn(string tokenId)
        {
            var walletData = ApplicationState.blockChains.Where(t => t.TokenId == tokenId).FirstOrDefault();

            // no data present; already deleted
            if (walletData == null)
                return 0;

            // delete from app state
            ApplicationState.blockChains.Remove(walletData);
            Log.Information($"Token Deleted! tokenId:{tokenId}");
            return 1;
        }

        /// <summary>
        /// A transfer transaction changes ownership of a token by removing the “fromAddress” wallet address, and adds it to the “toAddress” wallet address
        /// </summary>
        /// <param name="tokenId">Blockchain tokenId</param>
        /// <param name="fromAddress">Blockchain from wallet address</param>
        /// <param name="toAddress">Blockchain to wallet address</param>
        /// <returns>1 if successfull</returns>
        public bool Transfer(string tokenId, string fromAddress, string toAddress)
        {
            var walletData = ApplicationState.blockChains.Where(t => t.TokenId == tokenId && t.Address == fromAddress).FirstOrDefault();

            // no data present
            if (walletData == null)
                return false;

            // update the data
            walletData.Address = toAddress;
            Log.Information($"Token Transfered! tokenId:{tokenId}, fromAddress:{fromAddress}, toAddress:{toAddress}");
            return true;
        }

        /// <summary>
        /// Reads the wallet details associated with token
        /// </summary>
        /// <param name="tokenId">Blockchain token Id</param>
        /// <returns>Wallet information for token</returns>
        public BlockChainWallet GetWallteByToken(string tokenId)
        {
            Log.Information($"Token Read! tokenId:{tokenId}");
            return ApplicationState.blockChains.Where(t => t.TokenId == tokenId).FirstOrDefault();
        }

        /// <summary>
        /// Reads all tokens associated with Blockchain wallet
        /// </summary>
        /// <param name="address">Blockchain wallet address</param>
        /// <returns>List of tokens associated with Blockchain wallet</returns>
        public List<BlockChainWallet> GetTokensByWallet(string address)
        {
            Log.Information($"Wallet Read! address:{address}");
            return ApplicationState.blockChains.Where(t => t.Address == address).ToList();
        }

        /// <summary>
        /// Deletes all data previously processed by the program
        /// </summary>
        /// <returns>No of records deleted</returns>
        public int Reset()
        {
            int count = ApplicationState.blockChains.Count;
            ApplicationState.blockChains = new List<BlockChainWallet>();
            Log.Information($"Application state reset! No of tokens delete:{count}");
            return count;
        }
    }
}
