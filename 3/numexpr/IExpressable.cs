using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Func<TResult>
Func<T,TResult>
Func<T1,T2,TResult>
Func<T1,T2,T3,TResult>
Func<T1,T2,T3,T4,TResult>
Func<T1,T2,T3,T4,T5,TResult>
Func<T1,T2,T3,T4,T5,T6,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,TResult>
Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,TResult>
 */
public interface IExpressable
{
    public string Express(int number);
}
