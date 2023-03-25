using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using iyibir.TMGD.WebAPI.OData.Helpers;
using iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.OData.Controllers
{
    public class PositionController : ODataController
    {
        private UnitOfWork Session;

        public PositionController()
        {
            if (XpoDefault.Session == null)
                XpoDefault.Session = ConnectionHelper.CreateSession();
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Position> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<Position>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Position> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<Position>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                Position entity = new Position(uow)
                {
                    Oid = Guid.NewGuid(),
                    Code = position.Code,
                    Name = position.Name ?? string.Empty

                };
                await uow.CommitChangesAsync();
                return Created(entity);
            }
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> Post(string code)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    using (UnitOfWork uow = ConnectionHelper.CreateSession())
        //    {
        //        Position entity = new Position(uow)
        //        {
        //            Oid = Guid.NewGuid(),
        //            Code = code,

        //        };
        //        await uow.CommitChangesAsync();
        //        return Created(entity);
        //    }
        //}

        [HttpPut]
        public IHttpActionResult Put([FromODataUri] Guid key, Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (key != position.Oid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                Position existing = uow.GetObjectByKey<Position>(key);
                if (existing == null)
                {
                    Position entity = new Position(uow)
                    {
                        Oid = position.Oid,
                    };
                    uow.CommitChanges();
                    return Created(entity);
                }
                else
                {
                    existing.Oid = position.Oid;
                    uow.CommitChanges();
                    return Updated(position);
                }
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<Position> position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = ApiHelper.Patch<Position, string>(key, position);
            if (result != null)
            {
                return Updated(result);
            }
            return NotFound();
        }

        [HttpPost, HttpPut]
        public IHttpActionResult CreateRef([FromODataUri] Guid key, string navigationProperty, [FromBody] Uri link)
        {
            return StatusCode(ApiHelper.CreateRef<Position, Guid>(Request, key, navigationProperty, link));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (Session != null)
                {
                    Session.Dispose();
                    Session = null;
                }
            }
        }
    }
}