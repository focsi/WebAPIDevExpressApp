using MIRTUSZContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData.Query;

namespace WebAPIDevExpressApp.Models
{
    public class DBElemiMunkaHelper
    {
        internal static int GetCount(ODataQueryOptions<VELEMIMUNKAINMLIST> queryOptions)
        {
            using (MIRTUSZContext.MIRTUSZDataContext mirtuszDC = new MIRTUSZContext.MIRTUSZDataContext())
            {
                mirtuszDC.Connection.Open();
                if (queryOptions.Filter != null)
                {
                    ODataQuerySettings settings = new ODataQuerySettings()
                    {
                        PageSize = 1000000
                    };
                    IQueryable query = queryOptions.ApplyTo(mirtuszDC.VELEMIMUNKAINMLISTs, settings);
                    return query.Cast<VELEMIMUNKAINMLIST>().Count();
                }
                return mirtuszDC.VELEMIMUNKAINMLISTs.Count();
            }
        }

        internal static IEnumerable<VELEMIMUNKAINMLIST> GetDbPage(ODataQueryOptions<VELEMIMUNKAINMLIST> queryOptions)
        {
            using (MIRTUSZContext.MIRTUSZDataContext mirtuszDC = new MIRTUSZContext.MIRTUSZDataContext())
            {
                mirtuszDC.Connection.Open();
                if (queryOptions.Filter != null)
                {
                    IQueryable query = queryOptions.ApplyTo(mirtuszDC.VELEMIMUNKAINMLISTs);
                    var a = query.Provider.Execute< IEnumerable<VELEMIMUNKAINMLIST>>(query.Expression);
                    return a.ToArray();
//                    return a.Skip(queryOptions.Skip == null ? 0 : queryOptions.Skip.Value).Take(queryOptions.Top.Value).ToArray();
                }
                return mirtuszDC.VELEMIMUNKAINMLISTs.Skip(queryOptions.Skip == null ? 0 : queryOptions.Skip.Value).Take(queryOptions.Top.Value).ToArray();
            }
        }
    }
}