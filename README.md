# counter
Asp.Net Core 2.1 Simple Api
ASP.NET CORE 2.1 Api created in Visual Studio 2017 according to the kiss principle.

A Global variable inside static class storing the Counter in memory with default value: 0.

GET method retrieve the counter,

Post method reset the counter to 0 and

PUT method Increment the counter according to the request < inc > as a query < ? > in url .

Built-in cors used for cross orgin by defining policy and options in startup class and then calling the policy in api controller to let 

every one from every orgin can run the Api. Verb Set to not store the cache on controller to retrieve always fresh static counter value.

--------------------------------------------)

Api URL to test in tools like fiddler :

url/api Get Method Retrieve The Counter

url/api?inc = incrementRate Put Method Increment The Counter (int) >> Counter += incrementRate

url/api Post Method Reset The Counter to 0 

To test in fiddler, set http version to HTTP/1.1 OR HTTP/1.2 and in options set > Cache-Control : no-cache .

http://git.ippars.ir/
