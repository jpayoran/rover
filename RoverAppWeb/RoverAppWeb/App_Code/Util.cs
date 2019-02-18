using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

/// <summary>
/// Misc codes
/// </summary>
public static class Util
{

    public static string GetCallAPI(string url)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                return response;
            }
        }
        catch
        {
            return "";
        }
    }

}