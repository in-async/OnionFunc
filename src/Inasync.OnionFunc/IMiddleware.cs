﻿using System;

namespace Inasync.OnionFunc {

    /// <summary>
    /// オニオン パイプラインを構成するミドルウェア コンポーネント インターフェース。
    /// </summary>
    /// <typeparam name="T">パイプラインの実行時パラメーターの型。</typeparam>
    /// <typeparam name="TResult">パイプラインの実行結果の型。</typeparam>
    public interface IMiddleware<T, TResult> {

        /// <summary>
        /// ミドルウェアで定義されている処理を実行します。
        /// </summary>
        /// <param name="context">パイプラインの実行時パラメーター。</param>
        /// <param name="next">パイプラインの後続のコンポーネントを表すデリゲート。常に非 <c>null</c>。呼ばない事により残りのコンポーネントをショートサーキットできます。</param>
        /// <returns>このコンポーネント以降の処理を表すタスク。常に非 <c>null</c>。</returns>
        TResult Invoke(T context, Func<T, TResult> next);
    }

    /// <summary>
    /// ミドルウェアで定義されている処理を実行します。
    /// </summary>
    /// <typeparam name="T">パイプラインの実行時パラメーターの型。</typeparam>
    /// <typeparam name="TResult">パイプラインの実行結果の型。</typeparam>
    /// <param name="context">パイプラインの実行時パラメーター。</param>
    /// <param name="next">パイプラインの後続のコンポーネントを表すデリゲート。常に非 <c>null</c>。呼ばない事により残りのコンポーネントをショートサーキットできます。</param>
    /// <returns>このミドルウェア コンポーネント以降の処理を表すタスク。常に非 <c>null</c>。</returns>
    public delegate TResult MiddlewareFunc<T, TResult>(T context, Func<T, TResult> next);
}
