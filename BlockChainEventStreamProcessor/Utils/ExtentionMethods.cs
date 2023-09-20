using Newtonsoft.Json;
using Program.BusinessObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.Utils
{
    /// <summary>
    /// Extention methods
    /// </summary>
    public static class ExtentionMethods
    {
        /// <summary>
        /// Converts the json string to list of InputTokneData object
        /// </summary>
        /// <param name="jsonData">List of token transactions</param>
        /// <returns>List of rerialized objects from json string</returns>
        public static List<InputTokenData> ReadTokenData(this string jsonData)
        {
            List < InputTokenData > tokens = new List < InputTokenData > ();
            if (jsonData.Trim().Length>0 && jsonData.Trim()[0] == '{')
            {
                // contains single object
                var txnInputData = JsonConvert.DeserializeObject<InputTokenData>(jsonData);
                tokens.Add(txnInputData);
            }
            else
            {
                // contains list of objects or none
                tokens = JsonConvert.DeserializeObject<List<InputTokenData>>(jsonData);
            }
            return tokens;
        }

        /// <summary>
        /// Updates the token data in application state
        /// </summary>
        /// <param name="inputTokenData">List of input tokens from json</param>
        /// <returns>Message similar to; Read {Count} transaction(s) </returns>
        /// <exception cref="Exception">Exception in case of invalid type of transaction</exception>
        public static string Process(this List<InputTokenData> inputTokenData)
        {
            BlockChainTransaction transaction = new BlockChainTransaction();
            foreach (var token in inputTokenData)
            {
                switch (token.Type)
                {
                    case "Mint":
                        transaction.Mint(token.Address, token.TokenId);
                        break;
                    case "Burn":
                        transaction.Burn(token.TokenId);
                        break;
                    case "Transfer":
                        transaction.Transfer(token.TokenId, token.From, token.To);
                        break;
                    default: throw new Exception($"Invlaid operation! Type:{token.Type}");

                }
            }
            Log.Information($"{inputTokenData.Count} blockchain transactions processed!");
            return $"Read {inputTokenData.Count} transaction(s)";
        }
    }
}
