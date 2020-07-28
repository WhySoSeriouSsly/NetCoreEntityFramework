using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<out T>:IResult//data veriyor
    {
        T Data { get; }
    }
}
