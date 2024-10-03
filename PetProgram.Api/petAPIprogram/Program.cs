using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PetApiProgram
{

    // the entry point for the the pet api application
    public class Program
    {

        // the main method that runs the application
        public static void Main(string[] args)
        {

            // create a builder for the web application with the provided command line arguments 
            var builder = WebApplication.CreateBuilder(args);

            // add services for api exploration
            builder.Services.AddEndpointsApiExplorer();

            // register swagger for Api documentation
            builder.Services.AddSwaggerGen();

            // add support for MVC controllers
            builder.Services.AddControllers();


            // configure CORS policies
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {

                    // allow any origin, method and header
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // build the web application
            var app = builder.Build();

            // if the app is in development, use the developer exception page and enable swagger UI
            if (app.Environment.IsDevelopment())
            {

                // show detailed error pages for development
                app.UseDeveloperExceptionPage();

                // enable swagger
                app.UseSwagger();

                // enable swagger UI
                app.UseSwaggerUI();
            }


            // redirect http requests to https
            app.UseHttpsRedirection();

            // serve static files such as image, css and js 
            app.UseStaticFiles();

            // apply the CORS policy
            app.UseCors("AllowAllOrigins");

            // enable authorization middleware
            app.UseAuthorization();

            // map controller routes
            app.MapControllers();

            // run the web application
            app.Run();
        }
    }
}
