using System.Diagnostics;
using AspNetCoreLoggingProviderForAppService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingProviderForAppService.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            // Category is the fully-qualified type name of the type we request the ILogger for.
            // In this case, it's AspNetCoreLoggingProviderForAppService.Web.Controllers.HomeController.
            _logger = logger;
        }

        public IActionResult Index()
        {
            EmitLogEntries(nameof(Index));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private void EmitLogEntries(string viewName)
        {
            const string messageTemplate = "Emitting log entry with level {Level} while executing view {View}";

            _logger.LogTrace(messageTemplate, LogLevel.Trace, viewName);
            _logger.LogDebug(messageTemplate, LogLevel.Debug, viewName);
            _logger.LogInformation(messageTemplate, LogLevel.Information, viewName);
            _logger.LogError(messageTemplate, LogLevel.Error, viewName);
            _logger.LogCritical(messageTemplate, LogLevel.Critical, viewName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
