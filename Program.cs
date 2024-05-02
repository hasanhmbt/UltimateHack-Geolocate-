using System.Drawing;
using System.Net.Http;
using System.Security.Principal;
using Newtonsoft.Json;
using UltimateHack_Geolocate_;
using static System.Net.WebRequestMethods;



namespace superhack
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Console.Title = "darkwebhack";
            Console.Write("Enter IP Adress:");
            string ip = Console.ReadLine();

            string url = $"https://ipinfo.io/{ip}/json";


            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("[+] the bluetooth device is connected successfully🤤💀😎😍🥰🤩😪🤤😈👽👾🐳");

                    string respondData = await response.Content.ReadAsStringAsync();

                    VeryImportantData ipInfo = JsonConvert.DeserializeObject<VeryImportantData>(respondData);


                    // Console.Clear();

                    Console.WriteLine($"Country: {ipInfo.country}");
                    Console.WriteLine($"City: {ipInfo.city}");
                    Console.WriteLine($"Region: {ipInfo.region}");
                    Console.WriteLine($"Loc: {ipInfo.loc}");
                    Console.WriteLine($"Org: {ipInfo.org}");
                    Console.WriteLine($"Postal: {ipInfo.postal}");
                    Console.WriteLine($"Timezone: {ipInfo.timezone}");
                    string[] Coords = ipInfo.loc.Split(',');
                    Console.WriteLine($"Gooogle Maps: https://www.google.com/maps/?q={Coords[0]},{Coords[1]}");
                }
                catch (HttpRequestException ex)
                {

                    Console.WriteLine($"Error:{ex.Message}");
                }
            }


        }

    }

}