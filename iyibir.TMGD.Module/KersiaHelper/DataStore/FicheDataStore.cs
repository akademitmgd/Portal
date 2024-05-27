using iyibir.TMGD.Module.KersiaHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.KersiaHelper.DataStore;

public class FicheDataStore
{
    private const string RequestUrl = "api/fiches?username=servis&password=O!BPqrUd";
    public IEnumerable<Fiche> GetObjectsAsync(HttpClient httpClient,int ficheType)
    {
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddMonths(-1);
        string url = $"{RequestUrl}&begDate={endDate.Year}-{endDate.Month.ToString().PadLeft(2,'0')}-{endDate.Day.ToString().PadLeft(2,'0')}&endDate={startDate.Year.ToString()}-{startDate.Month.ToString().PadLeft(2,'0')}-{startDate.Day.ToString().PadLeft(2,'0')}&ficheType={ficheType}";
        var response = httpClient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            var jsonData = response.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(jsonData))
            {
                return JsonSerializer.Deserialize<IEnumerable<Fiche>>(jsonData);
            }
            else
                return Enumerable.Empty<Fiche>();
        }
        else
            return Enumerable.Empty<Fiche>();
    }
}
