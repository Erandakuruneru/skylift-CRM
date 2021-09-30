using System;
using System.Collections.Generic;
using System.Text;

namespace Skylift.Core.Interactors
{
    /// <summary>
    /// Class SaveDeliveryInfoRequest
    /// </summary>
    public class SaveLogInfoRequest
    {
        public string DeviceCode { get; set; }

        public string CardNumber { get; set; }

        public int UserId { get; set; }

    }
}

