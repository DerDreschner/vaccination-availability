using System;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using Refit;
using VaccineAvailability.BaseClient;
using VaccineAvailability.BaseClient.Interfaces;
using VaccineAvailability.TelematikClient.Interfaces;
using VaccineAvailability.TelematikClient.Services;

namespace VaccineAvailability.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            
            TelematikClient.Infrastructure.ServiceRegistration.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var telematikClient = serviceProvider.GetService<IBaseClient>();

            var termineVerfügbar = telematikClient.GetAppointmentsFor("12345", "XXXX-XXXX-XXXX");

            Console.WriteLine($"Anzahl verfügbarer Termine: {termineVerfügbar.Result.Count}");
            termineVerfügbar.Result.ForEach(x => Console.WriteLine($"Erster Termin: {x.FirstAppointment.ToString()} - Zweiter Termin: {x.SecondAppointment.ToString()}"));

            var ocicat = telematikClient.AreAppointmentsAvailableFor("69124", VaccineTypes.AstraZeneca);
            Console.WriteLine($"Termin verfügbar? {ocicat.Result}");

            Console.ReadKey();
        }
        
    }
}