using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PokemonDetector.Models;
using Newtonsoft.Json;
using Plugin.Toast; 

namespace PokemonDetector
{
    public class OnlineClassifier : IClassifier
    {
        public event EventHandler<ClassificationEventArgs> ClassificationCompleted;

        public async Task Classify(byte[] bytes)
        {
            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 10);

            client.DefaultRequestHeaders.Add("Prediction-Key", "3866b9746e5f445791aa66a616cdd4a7");

            string url = "https://ruapseminar-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/9169ec72-c8e4-4799-8bd1-f64541f44743/classify/iterations/Iteration3/image";
            
            HttpResponseMessage response;

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PredictionResult>(json);

                ClassificationCompleted.Invoke(this, new ClassificationEventArgs(result.Predictions));
            }
        }
    }
}
