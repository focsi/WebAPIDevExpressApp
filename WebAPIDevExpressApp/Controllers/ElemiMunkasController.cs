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
using WebAPIDevExpressApp.Models;
using Microsoft.Data.OData;
using System.Web.Http.OData.Extensions;

namespace WebAPIDevExpressApp.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebAPIDevExpressApp.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ElemiMunka>("ElemiMunkas");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ElemiMunkasController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        class Result
        {
            public IEnumerable<ElemiMunka> Results { get; set; }

            public int TotalCount { get; set; }

        }
        // GET: odata/ElemiMunkas
        public IHttpActionResult GetElemiMunkas(ODataQueryOptions<ElemiMunka> queryOptions)
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

            var munkak = ElemiMunka.GetPage(queryOptions.Skip == null ? 0 : queryOptions.Skip.Value, queryOptions.Top.Value );
            Request.ODataProperties().TotalCount = ElemiMunka.GetCount() ;

            return Ok<IEnumerable<ElemiMunka>>(munkak.AsQueryable() );
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ElemiMunkas(5)
        public IHttpActionResult GetElemiMunka([FromODataUri] decimal key, ODataQueryOptions<ElemiMunka> queryOptions)
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

            // return Ok<ElemiMunka>(elemiMunka);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/ElemiMunkas(5)
        public IHttpActionResult Put([FromODataUri] decimal key, Delta<ElemiMunka> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(elemiMunka);

            // TODO: Save the patched entity.

            // return Updated(elemiMunka);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ElemiMunkas
        public IHttpActionResult Post(ElemiMunka elemiMunka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(elemiMunka);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ElemiMunkas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] decimal key, Delta<ElemiMunka> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(elemiMunka);

            // TODO: Save the patched entity.

            // return Updated(elemiMunka);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ElemiMunkas(5)
        public IHttpActionResult Delete([FromODataUri] decimal key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
