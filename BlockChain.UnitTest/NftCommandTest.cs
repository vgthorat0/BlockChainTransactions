using Microsoft.Extensions.Options;
using Moq;
using Program.AppState;
using Program.BusinessObjects;
using Program.Commands;
using Program.Utils;
using System.Windows.Input;

namespace BlockChain.UnitTest
{
    public class NftCommandTest
    {
        private Mock<BlockChainTransaction> _blockChainObject;

        private string _invalidTokenId = "0xD000000000000000000000000000000000000000";

        private string _validTokenId = "0xB000000000000000000000000000000000000000";

        private string validTokenIdMessage = "Token 0xB000000000000000000000000000000000000000 is owned by 0x3000000000000000000000000000000000000000";
        
        private string invalidTokenIdMessage = "Token 0xD000000000000000000000000000000000000000 is not owned by any wallet";

        private BlockChainWallet blockChainWallet = new BlockChainWallet {TokenId = "0xB000000000000000000000000000000000000000", Address = "0x3000000000000000000000000000000000000000" } ;
        [SetUp]
        public void Setup()
        {
            ApplicationState.blockChains = new List<BlockChainWallet>();
            ApplicationState.blockChains.Add(blockChainWallet);

        }

        [Test]
        public void NftCommand_Should_Return_Correct_Message_For_InvalidToken()
        {
            //Arrage
            string[] args =  { "--nft", _invalidTokenId };
            var cmd = new NftCommand(args);
            
            //Act
            var result = cmd.Execute();

            //Assert
            Assert.AreEqual(result, invalidTokenIdMessage);
        }

        [Test]
        public void NftCommand_Should_Return_Correct_Message_For_ValidToken()
        {
            //Arrage
            string[] args = { "--nft", _validTokenId };
            var cmd = new NftCommand(args);

            //Act
            var result = cmd.Execute();

            //Assert
            Assert.AreEqual(result, validTokenIdMessage);
        }
    }
}