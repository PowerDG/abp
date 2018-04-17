﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiBootstrapModule)
        )]
    public class AbpAspNetCoreMvcUiBasicThemeModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiBasicThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic");
            });

            services.Configure<BundlingOptions>(options =>
            {
                options.StyleBundles.Add("GlobalStyles", new[]
                {
                    "/libs/font-awesome/css/font-awesome.css",
                    "/libs/bootstrap/dist/css/bootstrap.css",
                    "/libs/datatables.net-bs4/css/dataTables.bootstrap4.css",
                    "/styles/libs/datatables.css"
                });

                //TODO: Handle ticks stuff for all files
                options.ScriptBundles.Add("GlobalScripts", new[]
                {
                    "/libs/jquery/dist/jquery.js",
                    "/libs/bootstrap/dist/js/bootstrap.bundle.js",
                    "/libs/jquery-validation/dist/jquery.validate.js",
                    "/libs/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js",
                    "/libs/jquery-form/dist/jquery.form.min.js",
                    "/libs/datatables.net/js/jquery.dataTables.js",
                    "/libs/datatables.net-bs4/js/dataTables.bootstrap4.js",
                    "/libs/vue/dist/vue.js",
                    "/libs/abp/abp-jquery.js?_v" + DateTime.Now.Ticks,
                    "/Abp/ApplicationConfigurationScript?_v=" + DateTime.Now.Ticks,
                    "/Abp/ServiceProxyScript?_v=" + DateTime.Now.Ticks
                });
            });

            services.AddAssemblyOf<AbpAspNetCoreMvcUiBasicThemeModule>();
        }
    }
}