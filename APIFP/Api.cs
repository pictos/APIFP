using APIFP.Exceptions;
using APIFP.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using APIFP.Helpers;
using System.Collections.Generic;

namespace APIFP
{
    public class FP
    {
        static Lazy<FP> LazyApi = new Lazy<FP>(() => new FP());

        public static FP Current => LazyApi.Value;

        HttpClient Client;

        public int DayLimit { get; private set; }
        public int RequestNumber { get; private set; }

        FP() => Client = new HttpClient();

        public void Init(string api = KeyRepo.MinhaChave, Units units = Units.AVIATION)
        {

            if (units is Units.AVIATION)
                Console.WriteLine("é aviation");

            if (!(units is Units.AVIATION))
                Console.WriteLine("não é aviation");

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(api);
            Client.DefaultRequestHeaders.Add("X-Units", units.ToString());
        }



        public async Task<GenerateResponseFP> GenerateRouteAsync(GenerateFP fp)
        {

            var teste = JsonConvert.SerializeObject(fp);

            using (var content = new StringContent(teste, Encoding.UTF8, "application/json"))
            {
                var response = await Client.PostAsync(Const.generateUrl, content).ConfigureAwait(false);

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var show = JsonConvert.DeserializeObject<GenerateResponseFP>(json);
                    //show.Positions = new List<Position>();
                    var myFp = GooglePoints.Decode(show.EncodedPolyline);

                    foreach (var item in myFp)
                        show.Positions.Add(new Position(item.Latitude, item.Longitude));

                    return show;

                }

                else
                {
                    var msg = ApiException(json);
                    throw new BadRequestException(msg);
                }
            }


        }

        public async Task<MetarResponse> GetWheaterAsync(string icao)
        {
            var uri = string.Format(Const.metarRequest, icao);

            using (var response = await Client.GetAsync(uri).ConfigureAwait(false))
            {
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return MetarResponse.FromJson(json);
                else
                {
                    var msg = ApiException(json);
                    throw new BadRequestException(msg);
                }
            }
        }

        public async Task GetPlanIdAsync(string id)
        {
            var uri = string.Format(Const.planId, id);


            using (var response = await Client.GetAsync(uri).ConfigureAwait(false))
            {
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                }
            }

        }

        public async Task<List<UserFp>> GetUserPlansAsync(string username)
        {
            var uri = string.Format(Const.userPlans, username);

            using (var response = await Client.GetAsync(uri))
            {
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return UserFp.FromJson(json).ToList();
                else
                {
                    var msg = ApiException(json);
                    throw new BadRequestException(msg);
                }
            }
        }

        public async Task<ErrorMessage> DeleteFPAsync(string id)
        {
            var uri = string.Format(Const.planId, id);

            try
            {
                using (var response = await Client.DeleteAsync(uri))
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return ErrorMessage.FromJson(json);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Aiport> GetAiportAsync(string icao)
        {
            var uri = string.Format(Const.airpotInfo, icao);

            using (var response = await Client.GetAsync(uri))
            {
                ApiLimits(response);

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return Aiport.FromJson(json);
                else
                {
                    var msg = ApiException(json);
                    throw new BadRequestException(msg);
                }
            }
        }

        void ApiLimits(HttpResponseMessage response)
        {
            if (response is null) return;

            var limit = response.Headers.GetValues("X-Limit-Cap").FirstOrDefault();
            var used  = response.Headers.GetValues("X-Limit-Used").FirstOrDefault();

            RequestNumber = int.Parse(used);

            var count = int.Parse(limit);

            if (count == 100)
                return;

            DayLimit = count - RequestNumber;

        }

        static string ApiException(string json)
        {
            var error = JsonConvert.DeserializeObject<ErrorMessage>(json);
            var primeiroErro = $":  {error.Errors?.FirstOrDefault().Message}" ?? string.Empty;
            return $"{error.Message} {primeiroErro}";
        }
    }
}
