using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edo.Web.Model
{
    /// <summary>
    /// 执行结构返回Model
    /// </summary>
    public class Result
    {
        public Result()
        {
            Success = false;
        }
        public bool Success { get; set; }
        public object Obj { get; set; }
    }
}