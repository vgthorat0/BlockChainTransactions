using Newtonsoft.Json;
using Program.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.AppState
{
    /// <summary>
    /// Stores the application state in json fie. This can be modifed to store state in database as well.
    /// </summary>
    public static class ApplicationState
    {
        public static List<BlockChainWallet> blockChains {get;set;}

        public static string _FileName = "AppState.json";
        
        /// <summary>
        /// Reads the state from json file
        /// </summary>
        static  ApplicationState()
        {
            //read application state from json file.
            if (File.Exists(_FileName))
            {
                var currentState = JsonConvert.DeserializeObject<List<BlockChainWallet>>(File.ReadAllText(_FileName)) ;
                blockChains = currentState !=null ? currentState : new List<BlockChainWallet>();
            }
            else 
            {
                blockChains = new List<BlockChainWallet>();
            }

        }

        /// <summary>
        /// Saves the state in json file
        /// </summary>
        public static void Save()
        {
            string appState = JsonConvert.SerializeObject(blockChains);
            File.WriteAllText(_FileName, appState);
        }


    }
}
