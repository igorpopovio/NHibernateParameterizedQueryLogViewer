using System.ComponentModel;

namespace NHibernateParameterizedQueryLogViewer
{
    public class MainViewModel : ViewModel
    {
        public string Input { get; set; } = string.Empty;
        public string Output { get; set; } = string.Empty;

        public MainViewModel()
        {
            PropertyChanged += EmbedQueryParameters;
        }

        private void EmbedQueryParameters(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(Input)) return;

            Output = Input;
        }
    }
}
