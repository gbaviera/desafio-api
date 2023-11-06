using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu uma exceção não tratada");

            // Grava a exceção em um arquivo de log
            LogExceptionToFile(ex);

            // Pode retornar uma resposta de erro personalizada para o cliente, se necessário
        }
    }

    private void LogExceptionToFile(Exception ex)
    {
        string logFilePath = "caminho/do/arquivo.log";

        // Cria ou abre o arquivo de log
        using (StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.UTF8))
        {
            // Escreve a exceção no arquivo de log
            writer.WriteLine($"Data/Hora: {DateTime.Now}");
            writer.WriteLine($"Exceção: {ex.Message}");
            writer.WriteLine($"StackTrace: {ex.StackTrace}");
            writer.WriteLine(new string('-', 50));
        }
    }
}
