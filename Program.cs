using System.Text.Json;
using EspacioMonedas;
using System.Net;


var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";
try
{
    using (WebResponse response = request.GetResponse())//uso la respuesta del WebRequest
    {
        using (Stream strReader = response.GetResponseStream())//usa convierte la respuetsa en un stream
        {
            if (strReader == null) return;
            using (StreamReader objReader = new StreamReader(strReader))// convierte el stream obtenido en un objeto streamReader
            {
                string responseBody = objReader.ReadToEnd(); //convierto el StreamReader en un string
                moneda mone = JsonSerializer.Deserialize<moneda>(responseBody);

                Console.WriteLine("PRECIOS DE BITCOIN EN DIFERENTES MONEDAS: ");
                Console.WriteLine("USD: U$S " + mone.bpi.USD.rate_float);
                Console.WriteLine("EUR: € "+ mone.bpi.EUR.rate_float);
                Console.WriteLine("GBP: £ " + mone.bpi.GBP.rate_float);
                Console.ReadKey();
                Console.WriteLine("\n\nIngrese un tipo de cambio: ");
                Console.WriteLine("\n1-USD");
                Console.WriteLine("\n2-EUR");
                Console.WriteLine("\n3-GBP\n");
                int opcion;
                bool ingreso = int.TryParse(Console.ReadLine(),out opcion);
                Console.WriteLine("");
                if (ingreso)
                {
                    switch (opcion)
                    {
                        case 1:
                                Console.WriteLine("Code: " + mone.bpi.USD.code) ;
                                Console.WriteLine("Symbol: " + mone.bpi.USD.symbol) ;
                                Console.WriteLine("Rate: " + mone.bpi.USD.rate);
                                Console.WriteLine("Description: " + mone.bpi.USD.description); 
                                Console.WriteLine("Rate_float: " + mone.bpi.USD.rate_float);
                                break;

                        case 2:
                                Console.WriteLine("Code: " + mone.bpi.EUR.code); 
                                Console.WriteLine("Symbol: " + mone.bpi.EUR.symbol); 
                                Console.WriteLine("Rate: " + mone.bpi.EUR.rate); 
                                Console.WriteLine("Description: " + mone.bpi.EUR.description); 
                                Console.WriteLine("Rate_float: " + mone.bpi.EUR.rate_float);
                                break;

                        case 3:
                                Console.WriteLine("Code: " + mone.bpi.GBP.code); 
                                Console.WriteLine("Symbol: " + mone.bpi.GBP.symbol); 
                                Console.WriteLine("Rate: " + mone.bpi.GBP.rate); 
                                Console.WriteLine("Description: " + mone.bpi.GBP.description); 
                                Console.WriteLine("Rate_float: " + mone.bpi.GBP.rate_float);    
                                break;
                    }
                    
                }
            }
        }
    }
}
catch (WebException ex)
{
    Console.WriteLine("Problemas de acceso a la API");
    throw;
}