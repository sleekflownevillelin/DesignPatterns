namespace Singleton.LoadBalancers;

// one application could only create one load balancer, 
// when multiple request comes in, the unique load balancer would dispatch this request to a random server
public class DoubleCheckingLoadBalancer
{
    // static global instance
    private static DoubleCheckingLoadBalancer _loadBalancer = null;
    private readonly Random _random = new Random();
    private static readonly object MyLock = new object();

    private static readonly List<string> ServerList = new List<string>();
    // empty/symbolic ctor - it actually delegates the creation of the single object to LoadBalancer()
    private DoubleCheckingLoadBalancer()
    {
        ServerList.Add("Server I");
        ServerList.Add("Server II");
        ServerList.Add("Server III");
        ServerList.Add("Server IV");
        ServerList.Add("Server V");
    }
    // static initializer 
    public static DoubleCheckingLoadBalancer LoadBalancer
    {
        get
        {
            if (_loadBalancer == null)
            {
                lock (MyLock)
                {
                    if (_loadBalancer == null)
                    {
                        _loadBalancer = new DoubleCheckingLoadBalancer();
                    }
                }
            }

            return _loadBalancer;
        }
    }

    public string Server
    {
        get
        {
            var index = _random.Next(0, 5);
            return ServerList[index];
        }
    }
}