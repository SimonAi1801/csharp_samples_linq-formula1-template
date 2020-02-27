using Formula1.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Core.Entities
{
    public class Driver : ICompetitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => FirstName + LastName;
        public string Nationality { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Nationality)}: {Nationality}";
        }
    }
}
