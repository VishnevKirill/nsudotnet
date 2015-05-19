using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DatabaseApplication.Data.Entities;

namespace DatabaseApplication.GUI.ViewModels
{
  public class CountryViewModel : PropertyChangedBase
    {
      public countries count { get; private set; }

      public int ID
      {
          get { return count.id; }
          set
          {
              if(value==count.id) return;
              count.id = value;
              NotifyOfPropertyChange(()=>ID);
          }
      }


      public String Name
      {
          get { return count.country_name; }
          set
          {
              if(value==count.country_name) return;
              count.country_name = value;
              NotifyOfPropertyChange(() => Name);
          }
      }

      public void setCountry(countries c)
      {
          count = c;
      }

    }
}
