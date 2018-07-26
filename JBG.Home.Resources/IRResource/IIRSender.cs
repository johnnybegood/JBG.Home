using System.Threading.Tasks;

namespace JBG.Home.Resources.IRResource
{
    public interface IIRSender
    {
        Task SendAsync(string command, int channel);
    }
}