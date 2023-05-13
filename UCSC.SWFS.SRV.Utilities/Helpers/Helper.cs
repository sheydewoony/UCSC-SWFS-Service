using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Utilities.RequestHeader;

namespace UCSC.SWFS.SRV.Utilities.Helpers
{
    public static class Helper
    {
        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName.Trim(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
        public static void SetProperty(this object obj, string propertyName, int value)
        {
            obj.GetType().GetProperty(propertyName.Trim(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).SetValue(obj, Convert.ToInt32(value), null);
        }
        public static void SetProperty(this object obj, string propertyName, DateTime value)
        {
            obj.GetType().GetProperty(propertyName.Trim(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).SetValue(obj, value, null);
        }

        public static void SetBasePropertiesOnInsert<TEntity>(TEntity entity, IRequestHeader requestHeader)
        {

            if (HasProperty(typeof(TEntity), "CreatedBy"))
            {
                //SetProperty(entity, "CreatedBy", _contextHelper.GetUserId());
                SetProperty(entity, "CreatedBy", requestHeader.UserId);
            }

            if (HasProperty(typeof(TEntity), "CreatedOn"))
            {
                SetProperty(entity, "CreatedOn", DateTime.UtcNow);
            }
        }

        public static void SetBasePropertiesOnUpdate<TEntity>(TEntity entity, IRequestHeader requestHeader)
        {
            if (HasProperty(typeof(TEntity), "ModifiedBy"))
            {
                //SetProperty(entity, "ModifiedBy", _contextHelper.GetUserId());
                SetProperty(entity, "ModifiedBy", requestHeader.UserId);
            }

            if (HasProperty(typeof(TEntity), "ModifiedOn"))
            {
                SetProperty(entity, "ModifiedOn", DateTime.UtcNow);
            }
        }
    }
}
