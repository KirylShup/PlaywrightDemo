using System;
using System.Threading;

namespace PlayWrightDemo.Utils
{
    public static class Attempts
    {
        public static T TryUnitl<T, TResult>(Func<T> resultObj, Func<T, TResult> condition, int delay, int timeout) where T : class
        {
            if(resultObj != default(T))
            {
                var resultType = typeof(TResult);
                var totalTime = 0;

                while (true)
                {
                    T obj = default(T);
                    try
                    {
                        obj = resultObj.Invoke();
                        var result = condition(obj);

                        if (resultType == typeof(bool))
                        {
                            var boolResult = result as bool?;
                            if (boolResult.HasValue && boolResult.Value)
                            {
                                return obj;
                            }
                        }
                        else
                        {
                            if (result != null)
                            {
                                return obj;
                            }
                        }
                    }
                    catch
                    {
                    }

                    Thread.Sleep(delay);
                    totalTime += delay;

                    if (totalTime >= timeout)
                    {
                        return obj;
                    }
                }
            }

            return default(T);
        }
    }
}
