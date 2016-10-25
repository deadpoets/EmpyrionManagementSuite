using GalaSoft.MvvmLight;

namespace EMS.Core.ViewModels
{
    /// <summary>
    /// The common properties and behaviours that all ViewModels should share.
    /// </summary>
    public class ViewModelCommon : ViewModelBase
    {
        public string Name { get; set; }
    }
}