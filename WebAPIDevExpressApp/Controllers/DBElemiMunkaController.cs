using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using MIRTUSZContext;
using Microsoft.Data.OData;
using WebAPIDevExpressApp.Models;
using System.Web.Http.OData.Extensions;

namespace WebAPIDevExpressApp.Controllers
{
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
            // return Ok<IEnumerable<VELEMIMUNKAINMLIST>>(vELEMIMUNKAINMLISTs);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/DBElemiMunka(5)
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
        [AcceptVerbs("PATCH", "MERGE")]
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
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
