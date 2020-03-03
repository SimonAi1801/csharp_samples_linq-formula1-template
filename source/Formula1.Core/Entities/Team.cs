using Formula1.Core.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Core.Entities
{
    public class Team : ICompetitor
    {
        public string DriverName { get; }
        public string Nationality { get; set; }

        public Team(string name)
        {
            DriverName = name;
        }

        public override string ToString()
        {
            return $"{nameof(DriverName)}: {DriverName}, {nameof(Nationality)}: {Nationality}";
        }
    }
}
