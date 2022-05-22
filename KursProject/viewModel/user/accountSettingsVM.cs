using LightBooking.modelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel
{
    internal static class accountSettingsVM
    {
        public readonly static USER _user = new USER();

        public static void SetUser(Dictionary<string, string> result)
        {
            _user.Id = int.Parse(result["Id"]);
            _user.name = result["name"];
            _user.surname = result["surname"];
            _user.email = result["email"];
            _user.phone_number = result["phone_number"];
            _user.photo = result["photo"];
        }
    }
}
