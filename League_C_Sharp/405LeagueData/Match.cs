namespace _400_League_C_Sharp
{
    // Classes of a specific match JSON
    public class Match
    {
        public string region { get; set; }
        public string matchType { get; set; }
        public long matchCreation { get; set; }
        public Participant[] participants { get; set; }
        public string platformId { get; set; }
        public string matchMode { get; set; }
        public Participantidentity[] participantIdentities { get; set; }
        public string matchVersion { get; set; }
        public Team[] teams { get; set; }
        public int mapId { get; set; }
        public string season { get; set; }
        public string queueType { get; set; }
        public int matchId { get; set; }
        public int matchDuration { get; set; }


        // Returns a string delimited by delimiter
        public string[] printCSVString(string delimiter)
        {
            string[] output = new string[participants.Length];
            int curOutputLine = 0;

            // Create a line for each player
            for (int x = 0; x < participants.Length; x++)
            {
                // Match info
                string curLine = this.ToString(delimiter);

                // Participant ID and stuff
                curLine += delimiter + participantIdentities[x].player.ToString(delimiter);

                // Participant info
                curLine += delimiter + participants[x].ToString(delimiter);

                // In-game stats
                curLine += delimiter + participants[x].stats.ToString(delimiter);

                // Put the new line in the output array
                output[curOutputLine] = curLine;
                curOutputLine++;
            }

            return output;
        }


        // Returns a line for the header line of the csv
        public static string getHeaderLine(string delimiter)
        {
            string[] output = new string[] {"matchId",
                 "region",
                 "matchType",
                 "matchCreation",
                 "matchMode",
                 "season",
                 "queueType",
                 "matchDuration"
            };
            
            return string.Join(delimiter, output) + delimiter + Player.getHeaderSection(delimiter) + delimiter + Participant.getHeaderSection(delimiter) + delimiter + Stats.getHeaderSection(delimiter);
        }


        // Returns the match statistics to the string
        public string ToString(string delimiter)
        {
            string[] output = new string[] {matchId + "",
                 region,
                 matchType,
                 matchCreation + "",
                 matchMode,
                 season,
                 queueType,
                 matchDuration + ""
                };

            return string.Join(delimiter, output);;
        }
    }

    public class Participant
    {
        public Mastery[] masteries { get; set; }
        public Stats stats { get; set; }
        public Rune[] runes { get; set; }
        public Timeline timeline { get; set; }
        public int spell2Id { get; set; }
        public int participantId { get; set; }
        public int championId { get; set; }
        public int teamId { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public int spell1Id { get; set; }

        public static string getHeaderSection(string delimiter)
        {
            string[] output = new string[] {
                "participantId", 
                "championId", 
                "championRole",
                "teamId", 
                "highestAchievedSeasonTier"
            };

            return string.Join(delimiter, output); ;
        }

        // Returns interesting stats from the participant class
        public string ToString(string delimiter)
        {
            string[] output = new string[] {
                participantId + "", 
                championId + "", 
                ChampionType.Champion_Roles[championId],    // Add in champion's role
                teamId + "", 
                highestAchievedSeasonTier
            };

            return string.Join(delimiter, output); ;
        }
    }

    public class Stats
    {
        public int unrealKills { get; set; }
        public int item2 { get; set; }
        public int item1 { get; set; }
        public int totalDamageTaken { get; set; }
        public int item0 { get; set; }
        public int pentaKills { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public bool winner { get; set; }
        public int magicDamageDealt { get; set; }
        public int wardsKilled { get; set; }
        public int largestCriticalStrike { get; set; }
        public int trueDamageDealt { get; set; }
        public int doubleKills { get; set; }
        public int physicalDamageDealt { get; set; }
        public int tripleKills { get; set; }
        public int deaths { get; set; }
        public bool firstBloodAssist { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int assists { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int champLevel { get; set; }
        public int physicalDamageTaken { get; set; }
        public int totalDamageDealt { get; set; }
        public int largestKillingSpree { get; set; }
        public int inhibitorKills { get; set; }
        public int minionsKilled { get; set; }
        public int towerKills { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int quadraKills { get; set; }
        public int goldSpent { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int goldEarned { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public bool firstBloodKill { get; set; }
        public bool firstTowerKill { get; set; }
        public int wardsPlaced { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int killingSprees { get; set; }
        public bool firstInhibitorKill { get; set; }
        public int totalScoreRank { get; set; }
        public int totalUnitsHealed { get; set; }
        public int kills { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int totalPlayerScore { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int magicDamageTaken { get; set; }
        public int largestMultiKill { get; set; }
        public int totalHeal { get; set; }
        public int item4 { get; set; }
        public int item3 { get; set; }
        public int objectivePlayerScore { get; set; }
        public int item6 { get; set; }
        public bool firstTowerAssist { get; set; }
        public int item5 { get; set; }
        public int trueDamageTaken { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int combatPlayerScore { get; set; }

        public static string getHeaderSection(string delimiter)
        {
            string[] output = new string[] {
            "unrealKills", 
        "item2", 
        "item1", 
        "totalDamageTaken", 
        "item0", 
        "pentaKills", 
        "sightWardsBoughtInGame", 
        "winner", 
        "magicDamageDealt", 
        "wardsKilled", 
        "largestCriticalStrike", 
        "trueDamageDealt", 
        "doubleKills", 
        "physicalDamageDealt", 
        "tripleKills", 
        "deaths", 
        "firstBloodAssist", 
        "magicDamageDealtToChampions", 
        "assists", 
        "visionWardsBoughtInGame", 
        "totalTimeCrowdControlDealt", 
        "champLevel", 
        "physicalDamageTaken", 
        "totalDamageDealt", 
        "largestKillingSpree", 
        "inhibitorKills", 
        "minionsKilled", 
        "towerKills", 
        "physicalDamageDealtToChampions", 
        "quadraKills", 
        "goldSpent", 
        "totalDamageDealtToChampions", 
        "goldEarned", 
        "neutralMinionsKilledTeamJungle", 
        "firstBloodKill", 
        "firstTowerKill", 
        "wardsPlaced", 
        "trueDamageDealtToChampions", 
        "killingSprees", 
        "firstInhibitorKill", 
        "totalScoreRank", 
        "totalUnitsHealed", 
        "kills", 
        "firstInhibitorAssist", 
        "totalPlayerScore", 
        "neutralMinionsKilledEnemyJungle", 
        "magicDamageTaken", 
        "largestMultiKill", 
        "totalHeal", 
        "item4", 
        "item3", 
        "objectivePlayerScore", 
        "item6", 
        "firstTowerAssist", 
        "item5", 
        "trueDamageTaken", 
        "neutralMinionsKilled"
            };

            return string.Join(delimiter, output); ; 
        }

        public string ToString(string delimiter)
        {
            string[] output = new string[] {
                        unrealKills + "", 
        item2 + "", 
        item1 + "", 
        totalDamageTaken + "", 
        item0 + "", 
        pentaKills + "", 
        sightWardsBoughtInGame + "", 
        winner + "", 
        magicDamageDealt + "", 
        wardsKilled + "", 
        largestCriticalStrike + "", 
        trueDamageDealt + "", 
        doubleKills + "", 
        physicalDamageDealt + "", 
        tripleKills + "", 
        deaths + "", 
        firstBloodAssist + "", 
        magicDamageDealtToChampions + "", 
        assists + "", 
        visionWardsBoughtInGame + "", 
        totalTimeCrowdControlDealt + "", 
        champLevel + "", 
        physicalDamageTaken + "", 
        totalDamageDealt + "", 
        largestKillingSpree + "", 
        inhibitorKills + "", 
        minionsKilled + "", 
        towerKills + "", 
        physicalDamageDealtToChampions + "", 
        quadraKills + "", 
        goldSpent + "", 
        totalDamageDealtToChampions + "", 
        goldEarned + "", 
        neutralMinionsKilledTeamJungle + "", 
        firstBloodKill + "", 
        firstTowerKill + "", 
        wardsPlaced + "", 
        trueDamageDealtToChampions + "", 
        killingSprees + "", 
        firstInhibitorKill + "", 
        totalScoreRank + "", 
        totalUnitsHealed + "", 
        kills + "", 
        firstInhibitorAssist + "", 
        totalPlayerScore + "", 
        neutralMinionsKilledEnemyJungle + "", 
        magicDamageTaken + "", 
        largestMultiKill + "", 
        totalHeal + "", 
        item4 + "", 
        item3 + "", 
        objectivePlayerScore + "", 
        item6 + "", 
        firstTowerAssist + "", 
        item5 + "", 
        trueDamageTaken + "", 
        neutralMinionsKilled + ""
            };

            return string.Join(delimiter, output); ;
        }
    }

    public class Timeline
    {
        public Xpdiffpermindeltas xpDiffPerMinDeltas { get; set; }
        public Damagetakendiffpermindeltas damageTakenDiffPerMinDeltas { get; set; }
        public Xppermindeltas xpPerMinDeltas { get; set; }
        public Goldpermindeltas goldPerMinDeltas { get; set; }
        public string role { get; set; }
        public Creepspermindeltas creepsPerMinDeltas { get; set; }
        public Csdiffpermindeltas csDiffPerMinDeltas { get; set; }
        public Damagetakenpermindeltas damageTakenPerMinDeltas { get; set; }
        public string lane { get; set; }
    }

    public class Xpdiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Damagetakendiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Xppermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Goldpermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Creepspermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Csdiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Damagetakenpermindeltas
    {
        public float zeroToTen { get; set; }
        public float thirtyToEnd { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Mastery
    {
        public int rank { get; set; }
        public int masteryId { get; set; }
    }

    public class Rune
    {
        public int rank { get; set; }
        public int runeId { get; set; }
    }

    public class Participantidentity
    {
        public Player player { get; set; }
        public int participantId { get; set; }
    }

    public class Player
    {
        public int profileIcon { get; set; }
        public string matchHistoryUri { get; set; }
        public string summonerName { get; set; }
        public int summonerId { get; set; }

        // Returns a line for the header line of the csv
        public static string getHeaderSection(string delimiter)
        {
            string[] output = new string[] {"summonerId",
                 "summonerName"
            };

            return string.Join(delimiter, output);
        }


        // Returns the match statistics to the string
        public string ToString(string delimiter)
        {
            string[] output = new string[] {summonerId + "",
                 summonerName
                };

            return string.Join(delimiter, output); ;
        }
    }

    public class Team
    {
        public int inhibitorKills { get; set; }
        public int dominionVictoryScore { get; set; }
        public Ban[] bans { get; set; }
        public int towerKills { get; set; }
        public bool firstTower { get; set; }
        public bool firstBlood { get; set; }
        public bool firstBaron { get; set; }
        public bool firstInhibitor { get; set; }
        public bool firstDragon { get; set; }
        public bool winner { get; set; }
        public int vilemawKills { get; set; }
        public int baronKills { get; set; }
        public int dragonKills { get; set; }
        public int teamId { get; set; }
    }

    public class Ban
    {
        public int pickTurn { get; set; }
        public int championId { get; set; }
    }
}