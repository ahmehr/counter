using NUnit.Framework;
using System.Net;
using System.IO;
using System;

namespace UITests
{
    //* For this test you need a real host for api *\\
    //* You can use my host or Change the host with your host *\\
    [TestFixture]
    class UITests
    {
        //* UITests or RealTests check if All methods working well exterternally *\\
        WebClient wc = new WebClient();
        const string host = "http://api.ippars.ir";  // localhost:55493
        const string route = "/api";
        const string url = host + route;
        [Test]
        public void CheckGet()
        {
            //* Get the counter value by request with webclient *\\
            //* Check if get method return the default value or inceremented value *\\
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data); string s = reader.ReadToEnd(); data.Close(); reader.Close();
            Assert.That(int.Parse(s), Is.GreaterThanOrEqualTo(0));
        }
        [Test]
        public void CheckPut()
        {
            //* First create a random number between 0 and 1000 *\\
            //* Second take the static conter value by webclient request get method *\\
            //* Third take the put method by random *\\
            //* Third check if put method by random is equal to get method + random *\\
            Random r = new Random(); var i = r.Next(0, 1000);
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data); string s = reader.ReadToEnd(); data.Close(); reader.Close();
            var res = wc.UploadString(url + "?inc=" + i, "PUT", "").ToString();
            Assert.That(int.Parse(res), Is.EqualTo(int.Parse(s) + i));
        }
        [Test]
        public void CheckPost()
        {
            //* First send a httprequest by post method method *\\
            //* Second take the static conter value by webclient request get method *\\
            //* Third Chceck if post method reset the counter to 0 *\\
            var request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Method = WebRequestMethods.Http.Post;
            var response2 = request2.GetResponse();
            Stream data2 = wc.OpenRead(url);
            StreamReader reader2 = new StreamReader(data2); string s2 = reader2.ReadToEnd(); data2.Close(); reader2.Close();
            Assert.That(s2, Is.EqualTo("0"));
        }
    }
}
