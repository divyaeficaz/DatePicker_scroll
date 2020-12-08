using System;
using System.Collections.Generic;
using System.Text;

namespace Yondr_Finance.Models
{
      // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class StateList
    {
        public string Name { get; set; }
        public string abbreviation { get; set; }

    }

    public class CountryList
    {
        public string name { get; set; }
        public string code { get; set; }

    }
    public class RootObject
    {
        public StateList retorno { get; set; }
    }
    public class State_List
    {
        public List<StateList> statelist { get; set; }

    }

}
