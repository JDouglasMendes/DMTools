using System;
using System.Collections.Generic;
using System.Text;

namespace DMTools.Disposebles
{
    public static class DisposeUtil
    {
        public static void Disposables(params IDisposable[] disposables) => Array.ForEach(disposables, x => x.Dispose());
    }
}
