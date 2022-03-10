using System;
using System.Collections.Generic;
using System.Text;

namespace SoftTeco.ViewModel
{
    public static class CountableTask
    {
        public static int CountTask { get; set; }

        public static void Func(ref int a, out int count)
        {
            count = a;
        }
    }
}
