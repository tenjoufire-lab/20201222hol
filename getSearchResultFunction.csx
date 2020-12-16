#r "Newtonsoft.Json"
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    string resultString = "";
    string query = "";
    string searchURL = "YOURURL";


    //検索クエリの抽出
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    query = data?.r2788352246604e1fa337193aecb9a4e8;
    

    //Searchへリクエストを投げる
    using(var client = new HttpClient()){
        var request = new HttpRequestMessage(HttpMethod.Get, searchURL+query);
        request.Headers.Add("api-key", "YOURAPIKEY");
        var responce = await client.SendAsync(request);
        //string body = await new StreamReader(responce.Body).ReadToEndAsync();
        string body = await responce.Content.ReadAsStringAsync();
        dynamic searchdata = JsonConvert.DeserializeObject(body);
        for(int i = 0; i < 3; i++)
        {
        resultString += $"{searchdata?.value[i].captionTimeURL},";
        }   
    }
    return new OkObjectResult(resultString);
}

public class Caption {
    public string id {get; set;}
    public string captionTimeURL {get; set;}
    public string captionString {get; set;}
}
