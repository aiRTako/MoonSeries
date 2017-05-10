﻿namespace TakoYasuo_Loader
{
    using EloBuddy;
    using EloBuddy.SDK.Events;

    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;

    internal class Program
    {
        private static readonly string dllPath = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\EloBuddy\Addons\Libraries\TakoYasuo.dll";

        private static void Main(string[] Args)
        {
            Loading.OnLoadingComplete += eventArgs =>
            {
                if (File.Exists(dllPath))
                {
                    File.Delete(dllPath);
                }

                var bydll = Properties.Resources.TakoYasuo;
                using (var fs = new FileStream(dllPath, FileMode.Create))
                {
                    fs.Write(bydll, 0, bydll.Length);
                }

                var dllpath = Assembly.LoadFrom(dllPath);
                var main = dllpath.GetType("l").GetMethod("a", BindingFlags.NonPublic | BindingFlags.Static);

                main.Invoke(null, null);
            };
        }
    }
}
