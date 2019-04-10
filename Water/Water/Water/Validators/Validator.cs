using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Water.Validators
{
    public static class Validator
    {
        public static bool EmailVal(string email)
        {
            if (email == null)
                return false;
            var tmp = email as string;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            Match match = regex.Match(tmp);
            return match.Success;
        }
        public static bool PhoneVal(string number)
        {
            if (number == null)
                return false;
            var tmp = number as string;
            Regex regex = new Regex(@"^([0-9]{3})[-]([0-9]{3})[-]([0-9]{3})$");
            Match match = regex.Match(tmp);
            return match.Success;
        }

        public static bool WaterVal(string balance)
        {
            if (balance == null)
                return false;
            List<string> units = new List<string>()
        {
            "l","ml","cup"
        };
            var tmp = balance as string;
            Regex regex = new Regex(@"^([0-9]{3})|([0-9]\.[0-9]{1})[\s]" + string.Join("|", units.Select(Regex.Escape).ToArray()) + "$");
            Match match = regex.Match(tmp);
            return match.Success;
        }

        public static bool ConsultationVal(string consultation)
        {
            if (consultation == null)
                return false;
            var tmp = consultation as string;
            Regex regex = new Regex(@"^Yes|No|no|yes|^$");
            Match match = regex.Match(tmp);
            return match.Success;
        }

        public static bool EmptyField(string field)
        {
            if (field == null)
                return false;
            var str = field as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
