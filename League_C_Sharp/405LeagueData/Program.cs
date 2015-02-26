using RiotSharp;
using RiotSharp.ChampionEndpoint;
using RiotSharp.StaticDataEndpoint;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace _400_League_C_Sharp
{
    class Program
    {
        // Michael: deeceptor   summoner id: 32864925    ffa09023-efd5-4bc1-bb8f-007dbfb25d04

        // Kevin: squirrelknight	08baaaf9-f50f-4102-b291-c8567a7b96a6

        // Austin: dewie    22934000        A match id: 1507660629

        // 10 recent matches of a summoner  region                 summoner id             api key
        private static string ten_recent_games_url = "https://na.api.pvp.net/api/lol/na/v1.3/game/by-summoner/22934000/recent?";

        // Match history of a summoner (15 games)
        private static string match_History_url = "https://na.api.pvp.net/api/lol/na/v2.2/matchhistory/22934000?rankedQueues=RANKED_TEAM_5x5&";

        // Specific match
        private static string specific_match_url = "https://na.api.pvp.net/api/lol/na/v2.2/match/1507660629?";

        static string[] keys = { "ffa09023-efd5-4bc1-bb8f-007dbfb25d04", "08baaaf9-f50f-4102-b291-c8567a7b96a6" };
        private static int curKeyIndex = 0;

        static Region NA = Region.na;
        static string API_key = "ffa09023-efd5-4bc1-bb8f-007dbfb25d04"; // deeceptor's key


        static void Main(string[] args)
        {
            Console.WriteLine("Program, GO!");
            Match match = getMatch(12345);  // Use a breakpoint to look at the match object. It's beautiful!


            while (true) { }
        }


        /**
         * Returns the next key in our array keys. Used to circumvent the query limit
         */
        public static string getKey()
        {
            curKeyIndex++;
            return keys[curKeyIndex % keys.Length];
        }


        /**
         * Pass in matchID, returns a Match object
         */
        public static Match getMatch(int matchID)
        {
            String json_return = getJSON(addKeyToURL(specific_match_url));

            return JsonConvert.DeserializeObject<Match>(json_return.ToString());
        }


        /**
         * Returns an unmodified string JSON
         */ 
        public static string getJSON(string URL)
        {
             // Dispose webclient after calls
            using (var webClient = new System.Net.WebClient())
            {
                var json_data = string.Empty;                // attempt to download JSON data as a string
                try
                {
                    // This is the raw JSON string
                    json_data = webClient.DownloadString(URL);
                }
                catch (Exception) { }

                return json_data;
            }
        }
        public static string addKeyToURL(string url)
        {
            return url + "api_key=" + getKey();
        }


        static void readJSON()
        {
            // Gives 15 5v5 ranked team games of a given id (22934000)
            string URL = specific_match_url;

            // Dispose webclient after calls
            using (var webClient = new System.Net.WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    // This is the raw JSON string
                    json_data = webClient.DownloadString(URL);
                }
                catch (Exception) { }

                // Deserialize into a match object, containing all the properties of the JSON
                Match match = JsonConvert.DeserializeObject<Match>(json_data.ToString());

                // If we want to alter stuff from the JSON
                JObject json_object = JObject.Parse(json_data);
                
                // Removed masteries, rune and runes fields
                JToken changed_token = removeFields(JToken.Parse(json_data), new string[] { "masteries", "rune", "runes" });


                // You can explicitly add values here. add a "Entered" field with the value DateTime.Now
                //json_object.Add("Entered", DateTime.Now);

                // Or you can make it a dynamic
                //dynamic parsed_json_data = JValue.Parse(json_data);
                // or
                // dynamic parsed_json_data = json_object;

                // You can view specific fields:
                //string matches = parsed_json_data.MatchSummary;

                // Print out in a human readable way
                foreach (var item in (JObject)changed_token)
                {
                    //Console.WriteLine(item.Key + " " + item.Value.ToString());
                }

                int a = 1;
                // If you want to convert the JSON to a c# class, use this:
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                // !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();

                // Cast modified JSON back to string
                String string_json = changed_token.ToString();
                Console.WriteLine(string_json);

                // To create a CSV of the JSON object
                // Not working yet
                JSONtoCSV.toCSV(string_json, "test.csv");
            }
        }


        private static JToken removeFields(JToken token, string[] fields)
        {
            JContainer container = token as JContainer;
            if (container == null)
                return token;

            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if (p != null && fields.Contains(p.Name))
                {
                    removeList.Add(el);
                }
                removeFields(el, fields);
            }

            foreach (JToken el in removeList)
            {
                el.Remove();
            }

            return token;
        }


        void leagueAPI()
        {
            /*
            //RiotApi api = RiotApi.GetInstance("test");
            var api = RiotApi.GetInstance(API_key);
            var staticApi = StaticRiotApi.GetInstance("ffa09023-efd5-4bc1-bb8f-007dbfb25d04");
            var statusApi = StatusRiotApi.GetInstance();
            int id = 555;// int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = "dewie";//ConfigurationManager.AppSettings["Summoner1Name"];
            int id2 = 1;//int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            string name2 = "deeceptor";//ConfigurationManager.AppSettings["Summoner2Name"];
            //string team = 1;//ConfigurationManager.AppSettings["Team1Id"];
            //string team2 = 2;//ConfigurationManager.AppSettings["Team2Id"];

            Summoner me = api.GetSummoner(NA, name);
            Console.WriteLine(me.Id);
            long aaa = api.GetChampions(Region.na).First().Id;
            try
            {
                var ranked = me.GetStatsRanked();
                //    .Where((s) => s.ChampionId != null);

                ChampionStats[] array = ranked.ToArray();

                for (int x = 0; x < array.Length; x++)
                {
                    Console.WriteLine(array[x].ChampionId);
                }
            }
            catch (RiotSharpException ex)
            {
                //Handle the exception however you want.
            }


            // Player name
            // Console.WriteLine(api.GetSummonerName(Region.na, 555).Name);

            // Champion stats
            //ChampionStatic ch = staticApi.GetChampion(Region.na, 2);

            // Individual match histories
            //PlayerStatsSummary ps = api.GetStatsSummaries(Region.na, 555).First();

            // Win loss stats
            //var statSummaries = api.GetStatsSummaries(Region.na, id);

            /*
            var championIds = new List<int>();
            for (int i = 0; i < 30; i += 15)
            {
                var matches = api.GetMatchHistory(Region.na, 555, i, i + 2, null,
                    new List<Queue>() { Queue.RankedSolo5x5 });
                foreach (var match in matches)
                {
                    championIds.Add(match.Participants[0].ChampionId);
                }
            }
            var mostPlayedChampId = championIds.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            var mostPlayedChamp = staticApi.GetChampion(Region.euw, mostPlayedChampId);
            Console.WriteLine(mostPlayedChamp.Name);
            */

            //var games = api.GetRecentGames(Region.euw, id);

            Console.ReadLine();

            // mostPlayedChampId = championIds.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault().Key;

            while (true)
            {

            }
        }
    }
}
