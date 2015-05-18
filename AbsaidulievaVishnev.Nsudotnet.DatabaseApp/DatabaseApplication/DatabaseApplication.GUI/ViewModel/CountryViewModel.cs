using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Caliburn.Micro;
using DatabaseApplication.Data.Entities;

namespace DatabaseApplication.GUI
{
    class CountryViewModel : PropertyChangedBase
    {
        public countries count { get; private set; }

        public void setCountry(countries c)
        {
            count = c;
        }

        public int id
        {
            get { return count.id; }
            set
            {
                if(value==count.id) return;
                count.id = value;
                NotifyOfPropertyChange(()=>id);

            }
        }

        public String name
        {
            get { return count.country_name; }
            set
            {
                if (value == count.country_name) return;
                count.country_name = value;
                NotifyOfPropertyChange(()=>name);
            }
        }
    }
}
