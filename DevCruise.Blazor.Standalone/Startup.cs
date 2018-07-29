using System;
using System.Net.Http;
using BlazorRedux;
using DevCruise.Blazor.Client.Shared;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DevCruise.Blazor.Standalone
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://devcruiseblazorhostedserver.azurewebsites.net/") });
            services.AddReduxStore<MyStateBase, IAction>(new MyState(), Reducers<MyStateBase>.RootReducer);
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }

    public class MyState:MyStateBase
    {
        public override string ApiRoot { get; set; } = "https://devcruiseblazorhostedserver.azurewebsites.net/";
    }
}
