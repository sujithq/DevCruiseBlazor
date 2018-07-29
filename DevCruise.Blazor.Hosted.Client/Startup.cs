//using BlazorRedux;

using BlazorRedux;
using DevCruise.Blazor.Client.Shared;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DevCruise.Blazor.Hosted.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddReduxStore<MyStateBase,IAction>(new MyState(), Reducers<MyStateBase>.RootReducer);
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }

    public class MyState:MyStateBase
    {
    }
}
