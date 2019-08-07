﻿using System;

namespace Inasync.OnionPipelines {

    internal static class OnionFuncExtensions {

        public static Func<TContext, TResult> Wrap<TContext, TResult>(this Func<TContext, TResult> onionFunc, Func<Func<TContext, TResult>, Func<TContext, TResult>> middleware) {
            if (onionFunc == null) { throw new ArgumentNullException(nameof(onionFunc)); }
            if (middleware == null) { throw new ArgumentNullException(nameof(middleware)); }

            return middleware(onionFunc);
        }

        public static Func<TContext, TResult> Wrap<TContext, TResult>(this Func<TContext, TResult> onionFunc, MiddlewareFunc<TContext, TResult> middleware) {
            if (onionFunc == null) { throw new ArgumentNullException(nameof(onionFunc)); }
            if (middleware == null) { throw new ArgumentNullException(nameof(middleware)); }

            return context => middleware(context, onionFunc);
        }

        public static Func<TContext, TTask> Wrap<TContext, TTask>(this Func<TContext, TTask> onionFunc, IMiddleware<TContext, TTask> middleware) {
            if (onionFunc == null) { throw new ArgumentNullException(nameof(onionFunc)); }
            if (middleware == null) { throw new ArgumentNullException(nameof(middleware)); }

            return context => middleware.Invoke(context, onionFunc);
        }
    }
}