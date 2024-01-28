
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebSupergoo.ABCpdf13;

namespace ABCpdfLinuxPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors("AllowAll");

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //Trial license
            XSettings.InstallTrialLicense("XeJREBodo/9T4SEFbaGCaoygLbFIPdtypsrh8LDRNnUc4VLHNiy+P+kuLVxk7kIFBw==");
            using var doc = new Doc();
            doc.AddText("Hello, This is ABCpdf in Linux!");
            doc.Save($"./data/Hello_ABCpdf_{DateTime.Now:dd_MM_yyyy_hh_mm_ss}.pdf");

            app.Run();


        }
    }
}
