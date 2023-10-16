using FullStackAuth_WebAPI.ActionFilters;
using FullStackAuth_WebAPI.Contracts;
using FullStackAuth_WebAPI.Extensions;
using FullStackAuth_WebAPI.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;


namespace FullStackAuth_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

        
        
    var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigureMySqlContext(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<ValidationFilterAttribute>();
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            builder.Services.AddControllers();
            builder.Services.AddTransient<UPCLookupService>();
            builder.Services.AddTransient<GooglePlacesService>();
            // builder.Services.AddScoped<SpoonacularService>();
            string spoonacularApiKey ="4cb8d788dff14192aeeb7619916f5365";

            builder.Services.AddScoped(provider => new SpoonacularService(spoonacularApiKey));




            //added the above syntax from online resource to eliminate 500 error in postman




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}