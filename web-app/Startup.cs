using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using My.ToDoApp.DataAccess;
using My.ToDoApp.DataAccess.Stubs;
using Newtonsoft.Json;

namespace My.ToDoApp.WebApp {
    public class Startup {
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {
            //Uncomment to enable logging
            // loggerFactory.AddConsole();
            // loggerFactory.AddDebug();

            app
                .UseStaticFiles()
                .UseDeveloperExceptionPage()
                .UseMvc(routeBuilder => routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            //Uncomment to enable Hot Module Replacement 
            // app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
            //     HotModuleReplacement = true,
            //     ProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "client"),
            //     ConfigFile = "webpack.server-config.js"
            // });
        }

        public void ConfigureServices(IServiceCollection serviceCollection) {
            var jsonSerializerSettings = JsonSerializerSettingsProvider.CreateSerializerSettings();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var jsonOutputFormatter = new JsonOutputFormatter(jsonSerializerSettings, System.Buffers.ArrayPool<char>.Create());
            
            serviceCollection.AddNodeServices(options => {
                // options.LaunchWithDebugging = true;
                // options.DebuggingPort = 5858;
                options.HostingModel = NodeHostingModel.Socket;
                options.ProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "client");
            });

            serviceCollection.AddMvc(options => 
                options.OutputFormatters.Insert(0, jsonOutputFormatter));
            serviceCollection.AddSingleton<IEntitiesRepositoryFactory>(new EntitiesRepositoryFactory());
        }
    }
}