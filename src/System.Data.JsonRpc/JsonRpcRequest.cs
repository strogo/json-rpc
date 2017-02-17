﻿using System.Diagnostics;

#pragma warning disable IDE0016 // Use 'throw' expression

namespace System.Data.JsonRpc
{
    /// <summary>Represents RPC request message.</summary>
    [DebuggerDisplay("Id = {" + nameof(Id) + "}, Method = {" + nameof(Method) + "}, Has Params = {" + nameof(HasParams) + "}")]
    public sealed class JsonRpcRequest : JsonRpcMessage
    {
        internal JsonRpcRequest()
            : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> is empty string.</exception>
        public JsonRpcRequest(string method)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (method.Length == 0)
                throw new ArgumentException("Value is an empty string", nameof(method));

            Method = method;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <param name="params">The structured value that holds the parameter values to be used during the invocation of the method.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" /> or <paramref name="params" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> is empty string.</exception>
        public JsonRpcRequest(string method, object @params)
            : this(method)
        {
            if (@params == null)
                throw new ArgumentNullException(nameof(@params));

            Params = @params;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <param name="id">The identifier established by the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> is empty string.</exception>
        public JsonRpcRequest(string method, long id)
            : base(id)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (method.Length == 0)
                throw new ArgumentException("Value is an empty string", nameof(method));

            Method = method;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <param name="id">The identifier established by the client.</param>
        /// <param name="params">The structured value that holds the parameter values to be used during the invocation of the method.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" /> or <paramref name="params" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> is empty string.</exception>
        public JsonRpcRequest(string method, long id, object @params)
            : this(method, id)
        {
            if (@params == null)
                throw new ArgumentNullException(nameof(@params));

            Params = @params;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <param name="id">The identifier established by the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" /> or <paramref name="id" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> or <paramref name="id" /> is empty string.</exception>
        public JsonRpcRequest(string method, string id)
            : base(id)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (method.Length == 0)
                throw new ArgumentException("Value is an empty string", nameof(method));

            Method = method;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcRequest" /> class.</summary>
        /// <param name="method">The string containing the name of the method to be invoked.</param>
        /// <param name="id">The identifier established by the client.</param>
        /// <param name="params">The structured value that holds the parameter values to be used during the invocation of the method.</param>
        /// <exception cref="ArgumentNullException"><paramref name="method" />, or <paramref name="id" />, or <paramref name="params" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException"><paramref name="method" /> or <paramref name="id" /> is empty string.</exception>
        public JsonRpcRequest(string method, string id, object @params)
            : this(method, id)
        {
            if (@params == null)
                throw new ArgumentNullException(nameof(@params));

            Params = @params;
        }

        /// <summary>Gets a value indicating whether the response has parameters.</summary>
        public bool HasParams => Params != null;

        /// <summary>Gets a value indicating whether the message is a notification message.</summary>
        public bool IsNotification => IdType == JsonRpcIdType.Null;

        /// <summary>Gets a value indicating whether the message is a system message.</summary>
        public bool IsSystem => Method.StartsWith("rpc.", StringComparison.Ordinal);

        /// <summary>Gets a string containing the name of the method to be invoked.</summary>
        public string Method { get; internal set; }

        /// <summary>Gets a structured value that holds the parameter values to be used during the invocation of the method.</summary>
        public object Params { get; internal set; }
    }
}

#pragma warning restore IDE0016 // Use 'throw' expression