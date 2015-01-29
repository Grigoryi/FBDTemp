using FBDTemp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Helpers
{
   public class FullyCreatedConnectorInfo : ConnectorInfoBase
    {
        private bool showConnectors = false;

        public FullyCreatedConnectorInfo(DesignerBlockViewModel dataItem, ConnectorOrientation orientation)
            : base(orientation)
        {
            this.DataItem = dataItem; 
        }

        public DesignerBlockViewModel DataItem { get; private set; }

        public bool ShowConnectors
        {
            get
            {
                return showConnectors;
            }
            set
            {
                if (showConnectors != value)
                {
                    showConnectors = value;
                    NotifyChanged("ShowConnectors");
                }
            }
        }
    }
}
