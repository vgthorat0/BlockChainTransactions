using Program.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Commands
{
    internal class ProcessToken : ICommand
    {
        private List<InputTokenData> inputTokenData;

        private ProcessToken() { }
        public ProcessToken(List<InputTokenData> _inputTokenData)
        { 
            inputTokenData = _inputTokenData;
        }

        public string Execute() 
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
            return $"Read {inputTokenData.Count} transaction(s)";
        }
    }
}
