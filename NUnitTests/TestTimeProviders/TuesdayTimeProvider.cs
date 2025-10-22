using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.TestTimeProviders
{
    public class TuesdayTimeProvider : TimeProvider
    {
        private readonly DateTimeOffset _specificDateTime = new(2025, 10, 21, 20, 00, 00, TimeZoneInfo.Utc.BaseUtcOffset);

        public override DateTimeOffset GetUtcNow() => _specificDateTime;

        public override TimeZoneInfo LocalTimeZone => TimeZoneInfo.FindSystemTimeZoneById("PST");
    }
}
