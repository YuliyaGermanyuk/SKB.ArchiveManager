using DevExpress.Skins;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SKB.ArchiveManager
{
    static class Program
    {
        private const String ClientRootKey = @"SOFTWARE\DocsVision\Platform\5.0\Client";
        private const String ClientBasePathValue = "BasePath";
        private const String DocsVisionPlatformAssembly = "DocsVision.Platform.dll";
        private const String AssemblyResolverTypeName = "DocsVision.Platform.AssemblyResolver";
        private static readonly Guid ResolverClsId = new Guid("230DA85B-DC28-479E-B0B8-62E05C8E3065");

        private static object resolver; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                SkinManager.EnableFormSkins();

                CreateResolver();
                ArchiveManagerForm ArchiveManagerForm = null;
                try { ArchiveManagerForm = new ArchiveManagerForm(); }
                catch { ArchiveManagerForm = null; }
                if (ArchiveManagerForm != null)
                    Application.Run(ArchiveManagerForm);
            }
            catch { }
        }

        private static void CreateResolver ()
        {
            if (resolver != null)
                return;

            try
            {
                // создаем по CLSID 
                resolver = Activator.CreateInstance(Type.GetTypeFromCLSID(ResolverClsId));
            }
            catch
            {
            }

            if (resolver != null)
                return;

            // если не смогли, ищем по пути из реестра 
            String basePath = GetResolverBasePath();
            if (String.IsNullOrEmpty(basePath))
                return;

            try
            {
                Assembly resolverAssembly = Assembly.LoadFrom(Path.Combine(basePath, DocsVisionPlatformAssembly));
                resolver = resolverAssembly.CreateInstance(AssemblyResolverTypeName);
            }
            catch
            {
            }
        }

        private static String GetResolverBasePath ()
        {
            try
            {
                using (RegistryKey regSettings = Registry.LocalMachine.OpenSubKey(ClientRootKey, false))
                {
                    if (regSettings != null)
                    {
                        String basePath = (String)regSettings.GetValue(ClientBasePathValue);
                        if (!String.IsNullOrEmpty(basePath))
                            return basePath;
                    }
                }
            }
            catch
            {
            }

            try
            {
                using (RegistryKey regSettings = Registry.CurrentUser.OpenSubKey(ClientRootKey, false))
                {
                    if (regSettings != null)
                    {
                        String basePath = (String)regSettings.GetValue(ClientBasePathValue);
                        if (!String.IsNullOrEmpty(basePath))
                            return basePath;
                    }
                }
            }
            catch
            {
            }

            return null;
        }
    }
}