using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ICargo
    {
        Task<CargoResult> CreateShipment(User user, string cargoKey, int shippingType);
        Task<CargoResult> QueryShipment(string cargoKey, int shippingType);
        Task<CargoResult> CancelShipment(string cargoKey, int shippingType);

        string GenerateCargoKey() => StringHelper.RandomCode(10);
    }

    public class CargoResult
    {
        public bool HasError { get; set; } = true;
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string TranckingNumber { get; set; }
        public string TrackingUrl { get; set; }
    }
}
