using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class StateResource: KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> States { get; set; }

        public StateResource()
        {
            States = new Collection<KeyValuePairResource>();
        }
        
    }
}