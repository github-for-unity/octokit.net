//using System;

//namespace System.Runtime.CompilerServices
//{
//    public interface INotifyCompletion
//    {
//        void OnCompleted(Action action);
//    }
//}

//namespace Octokit
//{
//    using System.Runtime.CompilerServices;

//    public interface IAwaitable<out T>
//    {
//        IAwaiter<T> GetAwaiter();
//    }

//    public interface IAwaiter<out T> : INotifyCompletion
//    {
//        bool IsCompleted { get; }
//        T GetResult();
//    }

//    public interface IAwaitable
//    {
//        IAwaiter GetAwaiter();
//    }

//    public interface IAwaiter : INotifyCompletion
//    {
//        bool IsCompleted { get; }
//        object GetResult();
//    }

//    public struct TaskAwaiter : IAwaiter
//    {
//        public void OnCompleted(Action callback)
//        {
//            callback();
//        }

//        public bool IsCompleted { get; private set; }
//        public object GetResult()
//        {
//            return null;
//        }
//    }
//}