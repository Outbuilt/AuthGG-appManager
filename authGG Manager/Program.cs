using Colorful;
using System;
using System.Drawing;
using Console = Colorful.Console;
using xNet;
using Newtonsoft.Json;

namespace authGG_Manager
{
    class Program
    {
        public static string AuthorizationKey { get; set; }
        static void Main(string[] args)
        {
            design.Logo();
            Console.Title = "Auth.GG | Manager - Application made by bnja#0606";
            Console.WriteLineFormatted("\n{0}{1}{2} Authorization key (https://auth.gg/dashboard/applications/settings.php):", Color.White, design.colors);
            Console.WriteFormatted(" {3} ", Color.White, design.colors);
            AuthorizationKey = Console.ReadLine();
            Req.tryingAuthorizationKey();
            Console.ReadLine();
        }

        public static void Menu()
        {
            design.Logo();
            Console.WriteLineFormatted("\n {0}{4}{2} Users", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{5}{2} Licenses", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{6}{2} HWID", Color.White, design.colors);
            Console.WriteFormatted("  {3} ", Color.White, design.colors);
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Users();
                    break;

                case "2":
                    Console.Clear();
                    LicenseMenu();
                    break;

                case "3":
                    Console.Clear();
                    HWIDMenu();
                    break;
            }
        }

        #region User menu
        public static void Users()
        {
            design.Logo();
            Console.WriteLineFormatted("\n{0}{4}{2} Fetch Users' Information", Color.White, design.colors);
            Console.WriteLineFormatted("{0}{5}{2} Delete User", Color.White, design.colors);
            Console.WriteLineFormatted("{0}{6}{2} Edit user variable", Color.White, design.colors);
            Console.WriteLineFormatted("{0}{7}{2} Change Password", Color.White, design.colors);
            Console.WriteLineFormatted("{0}{8}{2} User Count", Color.White, design.colors);
            Console.WriteFormatted(" {3} ", Color.White, design.colors);
            string Option = Console.ReadLine();
            switch (Option)
            {
                case "1":
                    Console.Clear();
                    design.Logo();
                    string responseFetchUser = Req.userInformation();
                    if (responseFetchUser == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "2":
                    Console.Clear();
                    design.Logo();
                    string responseDeleteUser = Req.deleteUser();
                    if (responseDeleteUser == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "3":
                    Console.Clear();
                    design.Logo();
                    string responseEditvariable = Req.editUserVariable();
                    if (responseEditvariable == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "4":
                    Console.Clear();
                    design.Logo();
                    string editPassword = Req.editPassword();
                    if (editPassword == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "5":
                    Console.Clear();
                    design.Logo();
                    string usercount = Req.userCount();
                    if (usercount == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;
            }            
        }
        #endregion

        #region Licenses menu
        public static void LicenseMenu()
        {
            design.Logo();
            Console.WriteLineFormatted("\n {0}{4}{2} Generate Licenses", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{5}{2} Unuse License", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{6}{2} Use License", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{7}{2} Delete License", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{8}{2} License information", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{9}{2} Count Licenses", Color.White, design.colors);
            Console.WriteFormatted("  {3} ", Color.White, design.colors);
            string optionSelect = Console.ReadLine();
            switch (optionSelect)
            {
                case "1":
                    Console.Clear();
                    design.Logo();
                    string generateLicenses = Req.GenerateLicenses();
                    if (generateLicenses == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "2":
                    Console.Clear();
                    design.Logo();

                    string unuseLicense = Req.unuseLicenses();
                    if (unuseLicense == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "3":
                    Console.Clear();
                    design.Logo();

                    string useLicense = Req.useLicenses();
                    if (useLicense == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "4":
                    Console.Clear();
                    design.Logo();
                    string deleteLicense = Req.deleteLicense();
                    if (deleteLicense == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "5":
                    Console.Clear();
                    design.Logo();
                    string informationLicense = Req.licenseInformation();
                    if (informationLicense == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "6":
                    Console.Clear();
                    design.Logo();
                    string countLicenses = Req.countLicenses();
                    if (countLicenses == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;
            }
        }
        #endregion

        #region HWID Menu
        public static void HWIDMenu()
        {
            design.Logo();
            Console.WriteLineFormatted("\n {0}{4}{2} HWID Information", Color.White, design.colors);
            Console.WriteLineFormatted(" {0}{5}{2} Reset HWID from License", Color.White, design.colors);
            Console.WriteFormatted("  {3} ", Color.White, design.colors);
            string optionSelect = Console.ReadLine();
            switch (optionSelect)
            {
                case "1":
                    Console.Clear();
                    design.Logo();
                    string HWIDInformation = Req.getHWIDInfo();
                    if (HWIDInformation == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;

                case "2":
                    Console.Clear();
                    design.Logo();

                    string resetHWID = Req.resetHwid();
                    if (resetHWID == "done")
                    {
                        Console.WriteLine(" \n press enter to close", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    break;
            }
        }
        #endregion
    }
}
