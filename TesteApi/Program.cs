using APIFP;
using APIFP.Exceptions;
using APIFP.Model;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace TesteApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Hello World!");

            var api = Api.Current;
            
            api.Init();

            await TesteException();


            WriteLine($"Limite de uso {api.RequestNumber}");
            WriteLine($"Limite de uso {api.DayLimit}");

            //await api.DeleteFPAsync("1380973");

            var show = await api.GetAiportAsync("SBCF");

            WriteLine(show.Elevation);


           // api.Init();

            show = await api.GetAiportAsync("SBCF");
            WriteLine(show.Elevation);
            //await TesteException();
            WriteLine($"Limite de uso {api.RequestNumber}");
            WriteLine($"Limite de uso {api.DayLimit}");
            //var tempo = await api.GetWheaterAsync("SBGR");
            ReadKey();
        }

        static async Task TesteException()
        {
            try
            {

                var api = Api.Current;
                var fp = new GenerateFP
                {
                    FromIcao = "EHAM",
                    ToIcao = "KJFK"
                };

                var retorno = await api.GenerateRouteAsync(fp);
            }
            catch (BadRequestException ex)
            {
               // var exc = ErrorMessage.FromJson(ex.Message);
                WriteLine(ex.Message);
                //await Task.Delay(1);
                //throw;
            }
        }
    }
}
