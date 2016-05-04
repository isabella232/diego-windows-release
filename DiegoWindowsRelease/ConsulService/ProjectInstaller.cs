﻿using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Utilities;

namespace ConsulService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : CommonService
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        public override string ServiceName()
        {
            return this.serviceInstaller.ServiceName;
        }

        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            var configDir = Config.ConfigDir("consul");
            Directory.Delete(configDir, true);
            Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ConsulService"), true);
        }
    }
}
