using System;
using System.Collections.Generic;
using System.Text;

namespace EdistynytTentti02
{
    class JobChangedEventArgs : System.EventArgs
    {
        public Job Job { get; set; }
    }
}
