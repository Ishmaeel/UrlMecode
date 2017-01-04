using System.ComponentModel;

namespace UrlMecode
{
    internal class Mecoder : INotifyPropertyChanged
    {
        private string _Encoded;
        private string _Decoded;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Decoded
        {
            get { return _Decoded; }
            set
            {
                _Decoded = value;

                _Encoded = System.Web.HttpUtility.UrlEncode(_Decoded);
                RaiseChangedEvent("Encoded");
            }
        }

        public string Encoded
        {
            get { return _Encoded; }
            set
            {
                _Encoded = value;

                _Decoded = System.Web.HttpUtility.UrlDecode(_Encoded);
                RaiseChangedEvent("Decoded");
            }
        }

        private void RaiseChangedEvent(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}