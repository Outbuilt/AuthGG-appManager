using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace authGG_Manager
{
    class Req
    {
        public static void tryingAuthorizationKey()
        {
            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + Program.AuthorizationKey).ToString();
                    if (result.Contains("\"status\":\"failed\""))
                    {
                        Console.WriteLine("\nSomething went wrong, please check your authorization key or renew it.", Color.Red);
                    }
                    else if (result.Contains("\"status\":\"success\""))
                    {
                        Console.Clear();
                        Program.Menu();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n " + ex.Message, Color.Red);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        #region User Requests
        public static string userInformation()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string userFetch = Console.ReadLine();
                try
                {                    
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=fetch&authorization=" + Program.AuthorizationKey + "&user=" + userFetch).ToString();
                    if (result.Contains("\"status\":\"failed\""))
                    {
                        Console.WriteLine("  Something went wrong. Try again.", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    informationUser user = JsonConvert.DeserializeObject<informationUser>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Username: " + user.username, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Status: " + user.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Email: " + user.email, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Rank: " + user.rank, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} HWID: " + user.hwid, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Variable: " + user.variable, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Last-Login: " + user.lastlogin, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Last-IP: " + user.lastip, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Expiry: " + user.expiry, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string deleteUser()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string userSearch = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=delete&authorization=" + Program.AuthorizationKey + "&user=" + userSearch).ToString();
                    userDelete user = JsonConvert.DeserializeObject<userDelete>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + user.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + user.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string editUserVariable()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string userSearch = Console.ReadLine();
                Console.WriteLineFormatted("\n{0}{1}{2} new Variable:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string newVariable = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=editvar&authorization=" + Program.AuthorizationKey + "&user=" + userSearch + "&value=" + newVariable).ToString();
                    editVariable user = JsonConvert.DeserializeObject<editVariable>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + user.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + user.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string editPassword()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string userSearch = Console.ReadLine();
                Console.WriteLineFormatted("\n{0}{1}{2} new Password:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string newPassword = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=changepw&authorization=" + Program.AuthorizationKey + "&user=" + userSearch + "&password=" + newPassword).ToString();
                    editVariable user = JsonConvert.DeserializeObject<editVariable>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + user.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + user.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string userCount()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + Program.AuthorizationKey).ToString();
                    userCount user = JsonConvert.DeserializeObject<userCount>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + user.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Value: " + user.value, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }
        #endregion

        #region Licenses Requests
        public static string GenerateLicenses()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} Days:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string days = Console.ReadLine();
                Console.WriteLineFormatted("\n{0}{1}{2} Amount (maximum 25):", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLineFormatted("\n{0}{1}{2} Level:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string level = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=generate&days=" + days + "&amount=" + amount + "&level=" + level + "&authorization=" + Program.AuthorizationKey).ToString();
                    if (result.Contains("\"info\":\"You can only generate 25 licenses at once!\""))
                    {
                        Console.WriteLineFormatted(" {0}{1}{2} You can only generate 25 licenses at once!", Color.White, design.colors);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else if (result.Contains("\"status\":\"failed\""))
                    {
                        Console.WriteLine("  Something went wrong. Try again.", Color.LightGray);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    
                    string licenseKey = licenseAjust(result);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string licenseAjust(string text)
        {
            string lol = text.Replace("{\"0\"", string.Empty).Replace("\"1\"", string.Empty).Replace("\"2\"", string.Empty).Replace("\"3\"", string.Empty).Replace("\"4\"", string.Empty).Replace("\"5\"", string.Empty).Replace("\"6\"", string.Empty).Replace("\"7\"", string.Empty).Replace("\"8\"", string.Empty).Replace("\"9\"", string.Empty).Replace("\"10\"", string.Empty).Replace("\"11\"", string.Empty).Replace("\"12\"", string.Empty).Replace("\"13\"", string.Empty).Replace("\"14\"", string.Empty).Replace("\"15\"", string.Empty).Replace("\"16\"", string.Empty).Replace("\"17\"", string.Empty).Replace("\"18\"", string.Empty).Replace("\"19\"", string.Empty).Replace("\"20\"", string.Empty).Replace("\"21\"", string.Empty).Replace("\"22\"", string.Empty).Replace("\"23\"", string.Empty).Replace("\"24\"", string.Empty).Replace("\"25\"", string.Empty).Replace("}", string.Empty).Replace(":\"", string.Empty).Replace("\"", string.Empty).Replace(" ", string.Empty);
            string[] licenseFinish = lol.Split(',');
            Console.WriteLineFormatted("\n{0}{1}{2} Licenses created: \n", Color.White, design.colors);
            foreach (var licenses in licenseFinish)
            {
                Console.WriteLine(licenses, Color.White);
            }
            return "done";
        }


        public static string unuseLicenses()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} License:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=unuse&license=" + license + "&authorization=" + Program.AuthorizationKey).ToString();
                    unuseLicense unuse = JsonConvert.DeserializeObject<unuseLicense>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + unuse.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + unuse.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string useLicenses()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} License:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=use&license=" + license + "&authorization=" + Program.AuthorizationKey).ToString();
                    useLicense unuse = JsonConvert.DeserializeObject<useLicense>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + unuse.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + unuse.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string deleteLicense()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} License:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=delete&license=" + license + "&authorization=" + Program.AuthorizationKey).ToString();
                    deleteLicense unuse = JsonConvert.DeserializeObject<deleteLicense>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + unuse.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + unuse.info, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string licenseInformation()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} License:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=fetch&authorization=" + Program.AuthorizationKey + "&license=" + license).ToString();
                    informationLicense infoLicense = JsonConvert.DeserializeObject<informationLicense>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + infoLicense.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} License: " + infoLicense.license, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Rank: " + infoLicense.rank, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Used: " + infoLicense.used, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Used_by: " + infoLicense.used_by, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Created: " + infoLicense.created, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string countLicenses()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=count&authorization=" + Program.AuthorizationKey).ToString();
                    licensesCount countLi = JsonConvert.DeserializeObject<licensesCount>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + countLi.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Total: " + countLi.value, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        #endregion

        #region HWID Requests
        public static string getHWIDInfo()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/HWID/?type=fetch&authorization=" + Program.AuthorizationKey + "&user=" + license).ToString();
                    HWIDInformation countLi = JsonConvert.DeserializeObject<HWIDInformation>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + countLi.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + countLi.value, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        public static string resetHwid()
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                Console.WriteLineFormatted("\n{0}{1}{2} User:", Color.White, design.colors);
                Console.WriteFormatted(" {3} ", Color.White, design.colors);
                string license = Console.ReadLine();
                try
                {
                    string result = httpRequest.Get("https://developers.auth.gg/HWID/?type=reset&authorization=" + Program.AuthorizationKey + "&user=" + license).ToString();
                    HWIDInformation countLi = JsonConvert.DeserializeObject<HWIDInformation>(result);
                    Console.WriteLineFormatted("\n{0}{1}{2} Status: " + countLi.status, Color.White, design.colors);
                    Console.WriteLineFormatted("{0}{1}{2} Info: " + countLi.value, Color.White, design.colors);
                    return "done";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex.Message, Color.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                    return null;
                }
            }
        }
        #endregion
    }
}
