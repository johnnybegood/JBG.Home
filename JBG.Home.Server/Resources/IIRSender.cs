using System.Threading.Tasks;

namespace JBG.Home.Server.Resources
{
    public interface IIRSender
    {
        Task SendAsync(string command, int channel);
    }
}