using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestJsonDate4.Controllers
{
  //[Authorize]
  public class ValuesController : ApiController
  {
    // GET api/values
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    public DateTime Get(int id)
    {
      return new DateTime(2016, 10, 22, 0, 0, 0);
    }

    //[HttpPost]
    //public void UpdateDate(dynamic data)
    //{
    //  Debug.WriteLine(data.ToString());
    //}

    [HttpPost]
    public object UpdateDate([FromBody]string theDate)
    {
      Debug.WriteLine(theDate);
      return null;
    }

    [HttpGet]
    [Route("api/values/updatedateget")]
    public object UpdateDateGet([FromUri]string theDate)
    {
      Debug.WriteLine(theDate);
      return null;
    }

    [HttpPost]
    [Route("api/values/updatedatepost")]
    public object UpdateDatePost([FromBody]DateTime theDate)
    {
      Debug.WriteLine(theDate);
      return null;
    }

    // POST api/values
    public void Post([FromBody]dynamic value)
    {
      Debug.WriteLine(value);
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
  }
}
