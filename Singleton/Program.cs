// See https://aka.ms/new-console-template for more information

using Singleton.LoadBalancers;

const int total = 10000000;

LazyLoadBalancer b1 = LazyLoadBalancer.LoadBalancer;
LazyLoadBalancer b2 = LazyLoadBalancer.LoadBalancer;
LazyLoadBalancer b3 = LazyLoadBalancer.LoadBalancer;
LazyLoadBalancer b4 = LazyLoadBalancer.LoadBalancer;

if (b1 == b2 && b2 == b3 && b3 == b4)
{
    Console.WriteLine("Only one load balancer is created!");
}

Dictionary<string, int> dict = new Dictionary<string, int>();
dict.Add("Server I", 0);
dict.Add("Server II", 0);
dict.Add("Server III", 0);
dict.Add("Server IV", 0);
dict.Add("Server V", 0);

for (int request = 0; request < total; ++request)
{
    string server = b1.Server;
    dict[server]++; 
}

Console.WriteLine($"Load distribution: \nServer I load : {dict["Server I"]*1.0/total}\nServer II load : {dict["Server II"]*1.0/total}\nServer III load : {dict["Server III"]*1.0/total}\nServer IV load : {dict["Server IV"]*1.0/total}\nServer V load : {dict["Server V"]*1.0/total}");


