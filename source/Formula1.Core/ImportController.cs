using Formula1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Utils;

namespace Formula1.Core
{
    /// <summary>
    /// Daten sind in XML-Dateien gespeichert und werden per Linq2XML
    /// in die Collections geladen.
    /// </summary>
    public static class ImportController
    {
        public static List<Driver> Drivers { get; private set; }
        public static List<Team> Teams { get; private set; }
        public static List<Result> Results { get; private set; }
        /// <summary>
        /// Daten der Rennen werden aus der
        /// XML-Datei ausgelesen und in die Races-Collection gespeichert.
        /// Grund: Races werden nicht aus den Results geladen, weil sonst die
        /// Rennen in der Zukunft fehlen
        /// </summary>
        public static IEnumerable<Race> LoadRacesFromRacesXml()
        {
            List<Race> races = new List<Race>();
            string filePath = MyFile.GetFullNameInApplicationTree("Races.xml");
            var xElement = XDocument.Load(filePath).Root;

            if (xElement != null)
            {
                races = xElement.Elements("Race")
                       .Select(race => new Race
                       {
                           Number = (int)race.Attribute("round"),
                           Date = (DateTime)race.Element("Date"),
                           Country = race.Element("Circuit")
                                     ?.Element("Location")
                                     ?.Element("Country")
                                     ?.Value,
                           City = race.Element("Circuit")
                                  ?.Element("Location")
                                  ?.Element("Locality")
                                  ?.Value
                       })
                       .ToList();
            }
            return races;
        }

        /// <summary>
        /// Aus den Results werden alle Collections, außer Races gefüllt.
        /// Races wird extra behandelt, um auch Rennen ohne Results zu verwalten
        /// </summary>
        public static IEnumerable<Result> LoadResultsFromXmlIntoCollections()
        {
            LoadRacesFromRacesXml();
            Drivers = new List<Driver>();
            Teams = new List<Team>();
            Results = new List<Result>();
            string filePath = MyFile.GetFullNameInApplicationTree("Results.xml");
            var xElement = XDocument.Load(filePath).Root;

            if (xElement != null)
            {
                Results = xElement.Elements("Race").Elements("ResultsList").Elements("Result")
                           .Select(result => new Result
                           {

                           })
                           .ToList();
            }
            return Results;
        }


    }
}