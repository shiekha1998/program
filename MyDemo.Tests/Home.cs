using Bunit;
using System;
using Xunit;

namespace MyDemo.Tests
{
    public class Home
    {
        [Fact]
        public void Servic_Inject_Chekc_Positive()
        {
            using var ctx = new TestContext();
            ctx.Services.AddFallbackServiceProvider(new FallbackServiceProvider());

            var dummyService = ctx.Services.GetService<DummyService>();

            Assert.True(dummyService!=null);
        }
        [Fact]
        public void Servic_Inject_Chekc_Negative()
        {
            using var ctx = new TestContext();
            ctx.Services.AddFallbackServiceProvider(new FallbackServiceProvider());

            var dummyService = ctx.Services.GetService<DummyService>();

            Assert.False(dummyService==null);
        }
    }

    public class FallbackServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return new DummyService();
        }
    }

    public class DummyService { }
}