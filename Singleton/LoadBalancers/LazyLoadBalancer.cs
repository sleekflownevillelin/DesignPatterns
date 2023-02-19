namespace Singleton.LoadBalancers;

public class LazyLoadBalancer
{
    private static readonly Lazy<LazyLoadBalancer> Lazy = new Lazy<LazyLoadBalancer>(() => new LazyLoadBalancer());
    private static readonly List<string> ServerList = new List<string>();
    private readonly Random _random = new Random();
    private LazyLoadBalancer()
    {
        ServerList.Add("Server I");
        ServerList.Add("Server II");
        ServerList.Add("Server III");
        ServerList.Add("Server IV");
        ServerList.Add("Server V");
    }

    public static LazyLoadBalancer LoadBalancer => Lazy.Value;
    public string Server
    {
        get
        {
            var index = _random.Next(0, 5);
            return ServerList[index];
        }
    }
}