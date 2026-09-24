using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IJobDateFilter
{
    List<Job> Filter(IEnumerable<Job> jobs);
}
