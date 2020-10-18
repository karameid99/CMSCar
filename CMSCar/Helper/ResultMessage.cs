using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Helper
{
    public static class ResultMessage
    {
        public static string AddSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: تمت الاضافة بنجاح", close = 1 });
        }

        public static string EditSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: تم التعديل بنجاح", close = 1 });
        }

        public static string DeleteSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: تمت الحذف بنجاح", close = 1 });
        }

        public static string StatusUpdateResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: تم تعديل الحالة بنجاح", close = 1 });
        }

        public static string FailedResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "e: فشلت العملية", close = 1 });
        }
    }
}
