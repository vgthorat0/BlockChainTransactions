using Program.AppState;
using Program.Commands;
using Serilog;
using System.Windows.Input;
using ICommand = Program.Commands.ICommand;

namespace BlockChainEventStreamProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("consoleapp.log")
            .CreateLogger();

            //args = new[] { "--read-file", "C:\\Users\\vijay\\source\\repos\\BlockChainEventStreamProcessor\\BlockChainEventStreamProcessor\\transactions.json" }; // uncomment thils
            //for debug
            if (args.Length == 0)
            {
                showHelp(args);
                return;
            }
                
            try
            {
                ApplicationState._FileName = "AppState.json";
                var commandInvoker = new CommandInvoker();
                var command = commandInvoker.GetCommand(args);

                if (command != null)
                {
                    string result = command.Execute();
                    Console.WriteLine(result);
                }
                else
                {
                    showHelp(args);
                }
                
                // Save applicaiton state in json file
                // TODO: we can use database here but due coplexity to setup(db server / docker etc) on remote I used json to store state
                ApplicationState.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex, $"Exception on executing command: cmd>program {string.Join(" ", args )}");
            }
            
        }

        /// <summary>
        /// Shows help on console for commands those are supported
        /// </summary>
        public static void showHelp(string[] args)
        {
            Log.Information($"Invlaid command parameters provide. args:{string.Join(" ", args)}");
            Console.WriteLine($"\nprogram [--read-inline] [--read-file] [--nft] [--wallet] [--reset]  <json> <file> <address> <tokenId>\n\n" +
                $"--read-inline \t\t Reads the transactions from inline json\n" +
                $"--read-file \t\t Reads the transactions from json file\n" +
                $"--nft \t\t\t Returns ownership information for the nft with the given id\n" +
                $"--wallet \t\t Lists all NFTs currently owned by the wallet of the given address\n" +
                $"--reset \t\t Deletes all data previously processed by the program\n"  );
        }
    }
    
}