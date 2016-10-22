using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(TestJsonDate4.Startup))]

namespace TestJsonDate4
{

  public class AbpDateTimeConverter : IsoDateTimeConverter
  {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      var date = base.ReadJson(reader, objectType, existingValue, serializer) as DateTime?;

      if (date.HasValue)
      {
        return Normalize(date.Value);
      }

      return null;
    }


    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var date = value as DateTime?;
      base.WriteJson(writer, date.HasValue ? Normalize(date.Value) : value, serializer);
    }

    public DateTime Normalize(DateTime dateTime)
    {
      if (dateTime.Kind == DateTimeKind.Unspecified)
      {
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
      }

      if (dateTime.Kind == DateTimeKind.Utc)
      {
        return dateTime.ToLocalTime();
      }

      return dateTime;
    }

  }

  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);


      //var config = new HttpConfiguration();
      ////config.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, Newtonsoft.Json.JsonConverter)
      ////config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
      //config.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, new AbpDateTimeConverter());

      //app.UseWebApi(config);

      //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, new AbpDateTimeConverter());


    }
  }
}
