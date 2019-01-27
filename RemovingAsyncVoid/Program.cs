using System;
using System.Threading.Tasks;

namespace RemovingAsyncVoid
{
    internal static class Extensions
    {
        public static async void Catch<T>(this Task task, Action<T> handler) where T: Exception
        {
            try
            {
                await task;
            }
            catch (Exception ex) when (ex is T)
            {
                handler(ex as T);
            }
        }
    }

        internal class Progra
        {
            private static void Main(string[] args)
            {
            DoSomething();
            Console.ReadLine();
            }

        private static void DoSomething()
        {
            DoSomethingAsync().Catch<InvalidOperationException>(HandleOperation );
        }

        private static async Task DoSomethingAsync()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException("Error here!");
        }

        private static void HandleOperation(InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        }
    }
