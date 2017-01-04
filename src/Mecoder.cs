using System.ComponentModel;

namespace UrlMecode
{
    internal class Mecoder : INotifyPropertyChanged
    {
        private string _Input;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DecodedOutput { get; set; }

        public string EncodedOutput { get; set; }

        public string Input
        {
            get { return _Input; }
            set
            {
                _Input = value;

                EncodedOutput = System.Web.HttpUtility.UrlEncode(_Input);
                RaiseChangedEvent("EncodedOutput");

                DecodedOutput = System.Web.HttpUtility.UrlDecode(_Input);
                RaiseChangedEvent("DecodedOutput");
            }
        }

        private void RaiseChangedEvent(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}