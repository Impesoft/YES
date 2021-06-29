using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YES.Shared.Helper
{
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.Now.AddYears(100).ToShortDateString()) 
        {

        }
    }
}
