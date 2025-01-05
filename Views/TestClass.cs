using System.Runtime.CompilerServices;
using GigApp.Models.Configuration;
using Microsoft.Extensions.Options;

namespace GigApp.Views
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
