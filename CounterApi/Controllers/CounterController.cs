using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CounterApi.Controllers
{
    //* Url + Route = Address for Calling Api *\\
    [Route("api")]
    //* Prevent Caching on Server Side To retriving new value for Global and Static Values *\\
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //* Autorization to EveryOne, Eny Orgin By Enabling Cors Policy Defined in StartUp Class *\\
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        //* Global Variable Stored In Memory *\\
        public static class Globals
        {
            //* parameterless constructor required for static class *\\
            static Globals() { Counter = 0; } //* default value *\\

            //* public get, and private set for strict access control *\\
            public static int Counter { get; set; }

            //* GlobalInt can be changed only via this method *\\
            public static void SetGlobalInt(int newInt)
            {
                Counter = newInt;
            }
        }
        //* Get Method Retrive The Counter *\\
        [HttpGet]
        public int Get()
        {
            return Globals.Counter;
        }
        //* Put Method Incerement The Counter by Requqsted Rate in Query String in Url *\\
        [HttpPut]
        public string Put([FromQuery] int inc)   
        {
            Globals.SetGlobalInt( Globals.Counter + inc);
            return Globals.Counter.ToString();
        }
        //* Post Method Reset The Counter *\\
        [HttpPost]
        public void Reset()
        {
            Globals.SetGlobalInt(0);
        }
    }
}