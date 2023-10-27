using GTFOprogress.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GTFOprogress.Services
{
    public class RundownRepository
    {
        private readonly string _dataFilePath = "Data/levels.json";
        private JsonSerializerOptions _jsonSerializerOptions;

        public RundownRepository()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };
        }

        public IEnumerable<Rundown> GetAllRundowns()
        {
            if (!File.Exists(_dataFilePath))
                throw new FileNotFoundException("The levels.json file was not found.", _dataFilePath);

            var jsonData = File.ReadAllText(_dataFilePath);
            return JsonSerializer.Deserialize<List<Rundown>>(jsonData, _jsonSerializerOptions);
        }
    }
}
