using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;using Microsoft.Extensions.Configuration;

namespace ConsoleAppNetCoreDI
{
    public class Functions
    {
        private readonly ILogger<Functions> _logger;

        private readonly IConfiguration _configuration;

        private readonly IMyDependency1 _myDependency1;
        public Functions(ILogger<Functions> logger, IConfiguration configuration, IMyDependency1 myDependency1)
        {
            _logger = logger;

            _configuration = configuration;

            _myDependency1 = myDependency1;
        }

        public void TimerTrigger1([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer)
        {
            _logger.LogInformation("TimerTrigger1 logged something, courtesy of the Ilogger you explicitly injected.");
            string fakeAppSetting = _configuration["FakeAppSetting"];
            _logger.LogInformation("FakeAppSettingValue: " + fakeAppSetting);

            //if the following prints "MyDependency1 successfully injected", we know MyDependency1 was sucessfully injected because this message was passed into the constructor during registration 
            _logger.LogInformation("MyDependency1.TestDependencyInjection() return value: " + _myDependency1.TestDependencyInjection());
        }

        public void TimerTrigger2([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger log)
       {
           log.LogInformation("TimerTrigger2 logged something, thanks to the ILogger injected by WebJobs SDK");
        }
    

    }
}
