using GalaSoft.MvvmLight.Views;

namespace EMS.Core.Navigation
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}