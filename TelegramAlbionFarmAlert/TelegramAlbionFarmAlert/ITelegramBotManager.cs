using System.Threading.Tasks;

namespace TelegramAlbionFarmAlert
{
    public interface ITelegramBotManager
    {
        void Start();
        void Stop();
    }
}
