using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.common
{
    public class SettingHelper
    {
        public static ApplicationDbContext db= new ApplicationDbContext();
        public static string GetValue(string key)
        {
            var item = db.SystemSettings.SingleOrDefault(x=>x.SettingKey == key);
            if(item != null)
            {
                return item.SettingValue;
            }
            return "";
        }
    }
}