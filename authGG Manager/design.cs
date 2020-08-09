using Colorful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading.Tasks;

namespace authGG_Manager
{
    #region design
    public class design
    {
        public static Formatter[] colors = new Formatter[]
        {
            new Formatter(" [", Color.Gray),
            new Formatter("!", Color.Violet),
            new Formatter("]", Color.Gray),
            new Formatter(" >", Color.Violet),
            new Formatter("1", Color.Violet),
            new Formatter("2", Color.Violet),
            new Formatter("3", Color.Violet),
            new Formatter("4", Color.Violet),
            new Formatter("5", Color.Violet),
            new Formatter("6", Color.Violet),
            new Formatter("7", Color.Violet),
        };
        public static void Logo()
        {
            Console.WriteLine("\n\t\t     _         _   _      ____  ____                                               ", Color.BlueViolet);
            Console.WriteLine("\t\t    / \\  _   _| |_| |__  / ___|/ ___|  _ __ ___   __ _ _ __   __ _  __ _  ___ _ __ ", Color.BlueViolet);
            Console.WriteLine("\t\t   / _ \\| | | | __| '_ \\| |  _| |  _  | '_ ` _ \\ / _` | '_ \\ / _` |/ _` |/ _ \\ '__|", Color.BlueViolet);
            Console.WriteLine("\t\t  / ___ \\ |_| | |_| | | | |_| | |_| | | | | | | | (_| | | | | (_| | (_| |  __/ |   ", Color.BlueViolet);
            Console.WriteLine("\t\t /_/   \\_\\__,_|\\__|_| |_|\\____|\\____| |_| |_| |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_|   ", Color.BlueViolet);
            Console.WriteLine("\t\t                                                                   |___/           ", Color.BlueViolet);
        }
    }
    #endregion
}
