using NServiceBus;

namespace Shared
{
    public class ImportFile : ICommand
    {
        public ImportFile(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }
    }
}
