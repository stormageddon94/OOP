﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoarderControl
{
    public interface IId
    {
        string IdNumber { get; set; }

        bool IsIdFake(string idNumber);

    }
}
