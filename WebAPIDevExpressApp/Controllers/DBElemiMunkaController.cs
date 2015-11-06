using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using MIRTUSZContext;
using Microsoft.Data.OData;
using WebAPIDevExpressApp.Models;
using System.Web.Http.OData.Extensions;
using System.Web.Mvc;

namespace WebAPIDevExpressApp.Controllers
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }

    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MIRTUSZContext;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<VELEMIMUNKAINMLIST>("DBElemiMunka");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DBElemiMunkaController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/DBElemiMunka
        [RequireHttps]
        public IHttpActionResult GetDBElemiMunka(ODataQueryOptions<VELEMIMUNKAINMLIST> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var munkak = DBElemiMunkaHelper.GetDbPage(queryOptions);
            int count = DBElemiMunkaHelper.GetCount(queryOptions);
            Request.ODataProperties().TotalCount = count;

            return Ok<IEnumerable<VELEMIMUNKAINMLIST>>(munkak.AsQueryable());
        }

        // GET: odata/DBElemiMunka(5)
        [RequireHttps]
        public IHttpActionResult GetVELEMIMUNKAINMLIST([FromODataUri] long key, ODataQueryOptions<VELEMIMUNKAINMLIST> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<VELEMIMUNKAINMLIST>(vELEMIMUNKAINMLIST);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/DBElemiMunka(5)
        [RequireHttps]
        public IHttpActionResult Put([FromODataUri] long key, Delta<VELEMIMUNKAINMLIST> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(vELEMIMUNKAINMLIST);

            // TODO: Save the patched entity.

            // return Updated(vELEMIMUNKAINMLIST);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/DBElemiMunka
        [RequireHttps]
        public IHttpActionResult Post(VELEMIMUNKAINMLIST vELEMIMUNKAINMLIST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(vELEMIMUNKAINMLIST);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/DBElemiMunka(5)
        [System.Web.Http.AcceptVerbs("PATCH", "MERGE")]
        [RequireHttps]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<VELEMIMUNKAINMLIST> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(vELEMIMUNKAINMLIST);

            // TODO: Save the patched entity.

            // return Updated(vELEMIMUNKAINMLIST);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/DBElemiMunka(5)
        [RequireHttps]
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
