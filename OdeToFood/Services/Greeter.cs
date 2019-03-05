using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public class Greeter: IGreeter
    {

        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string getMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}
