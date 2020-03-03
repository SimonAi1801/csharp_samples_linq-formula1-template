using Formula1.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Core.Entities
{
    public class Driver : ICompetitor
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DriverName { get; private set; }

        public Driver(string driverName)
        {
            DriverName = driverName;
        }

        public override string ToString()
        {
            return $"{nameof(DriverName)}: {DriverName}";
        }
    }
}
