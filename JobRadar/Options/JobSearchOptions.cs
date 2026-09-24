using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRadar.Options;

public class JobSearchOptions
{
    public const string SectionName = "JobSearch";

    public int MaxJobAgeDays { get; set; } = 20;
}
