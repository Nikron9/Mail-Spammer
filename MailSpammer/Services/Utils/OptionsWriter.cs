﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Services.Utils
{
    class OptionsWriter : IOptionsWriter
    {
        private readonly IConfigurationRoot _configuration;

        public OptionsWriter(
            IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public void UpdateOptions(Action<JObject> callback, bool reload = true)
        {
            var path = @"config\appsettings.json";
            var json = File.ReadAllText(path);
            var config = JObject.Parse(json);

            callback(config);
            
            File.WriteAllText(path, JsonConvert.SerializeObject(config));

            _configuration.Reload();
        }
    }
}