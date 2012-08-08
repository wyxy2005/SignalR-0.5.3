using System;
using Newtonsoft.Json;

namespace SignalR.Client
{
    public static class ConnectionExtensions
    {
        public static T GetValue<T>(this IConnection connection, string key)
        {
            object value;
            if (connection.Items.TryGetValue(key, out value))
            {
                return (T)value;
            }

            return default(T);
        }

        public static bool TryGetValue<T>(this IConnection connection, string key, out T value)
        {
            value = default(T);

            object rawValue;
            if (connection.Items.TryGetValue(key, out rawValue))
            {
                value = (T)rawValue;
                return true;
            }

            return false;
        }

#if !WINDOWS_PHONE && !SILVERLIGHT && !NET35
        public static IObservable<string> AsObservable(this Connection connection)
        {
            return connection.AsObservable(value => value);
        }

        public static IObservable<T> AsObservable<T>(this Connection connection)
        {
            return connection.AsObservable(value => JsonConvert.DeserializeObject<T>(value));
        }

        public static IObservable<T> AsObservable<T>(this Connection connection, Func<string, T> selector)
        {
            return new ObservableConnection<T>(connection, selector);
        }
#endif
    }
}
