using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;

namespace GigApp.Application
{
    public class TestClass
    {
        private readonly ConnectionStrings _options;

        public TestClass(IOptions<ConnectionStrings> options)
        {
            _options = options.Value;
        }

        public ConnectionStrings PrintOptions()
        {
            return _options;
        }
    }
}
