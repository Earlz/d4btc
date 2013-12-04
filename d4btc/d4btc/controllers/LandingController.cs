using System;
using Earlz.LucidMVC;
using Earlz.d4btc.Views;

namespace Earlz.d4btc
{
    public class LandingController : HttpController
    {
        public LandingController(RequestContext c) : base(c)
        {
        }
        public LandingView Landing()
        {
            return new LandingView();
        }
    }
}

