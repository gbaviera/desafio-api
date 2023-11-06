﻿namespace Desafio.api;

public class Program
{
    public static void Main(string[] args)
    {
        CreatHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreatHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

}

