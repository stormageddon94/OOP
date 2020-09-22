using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartPhone
    {
        string Call(string number);

        string Browse(string website);
    }
}
