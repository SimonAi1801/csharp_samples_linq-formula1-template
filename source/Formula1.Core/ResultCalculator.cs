using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core.Entities;

namespace Formula1.Core
{
    public class ResultCalculator
    {
        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Fahrer
        /// </summary>
        /// <returns>DTO für die Fahrerergebnisse</returns>
        public static IEnumerable<TotalResultDto<Driver>> GetDriverWmTable()
        {
            var driverTable = ImportController.LoadResultsFromXmlIntoCollections()
                                .GroupBy(race => race.Driver)
                                .OrderByDescending(driver => driver.Sum(driver => driver.Points))
                                .Select((driver, idx) => new TotalResultDto<Driver>
                                {
                                    Competitor = driver.Key,
                                    Position = idx + 1,
                                    Points = driver.Sum(driver => driver.Points)
                                });
            return driverTable;
        }

        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Teams
        /// </summary>
        /// <returns>DTO für die Teamergebnisse</returns>
        public static IEnumerable<TotalResultDto<Team>> GetTeamWmTable()
        {
            var teamTable = ImportController.LoadResultsFromXmlIntoCollections()
                            .GroupBy(race => race.Team)
                            .OrderByDescending(teams => teams.Sum(teams => teams.Points))
                            .Select((teams, idx) => new TotalResultDto<Team>
                            {
                                Competitor = teams.Key,
                                Position = idx + 1,
                                Points = teams.Sum(teams => teams.Points)
                            });
            return teamTable;
        }
    }
}



