﻿using Serenity.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Serenity.Web
{
    /// <summary>
    /// Adds temporary granting support to any IPermissionService implementation
    /// </summary>
    public class TransientGrantingPermissionService : IPermissionService, ITransientGrantor
    {
        private IPermissionService permissionService;
        private ThreadLocal<Stack<HashSet<string>>> grantingStack = new ThreadLocal<Stack<HashSet<string>>>();

        public TransientGrantingPermissionService(IPermissionService permissionService)
        {
            Check.NotNull(permissionService, "permissionService");

            this.permissionService = permissionService;
        }

        private Stack<HashSet<string>> GetGrantingStack(bool createIfNull)
        {
            Stack<HashSet<string>> stack;

            var requestItems = Dependency.Resolve<IRequestContext>().Items;
            if (requestItems != null)
            {
                stack = requestItems["GrantingStack"] as Stack<HashSet<string>>;
                if (stack == null && createIfNull)
                    requestItems["GrantingStack"] = stack = new Stack<HashSet<string>>();
            }
            else
            {
                stack = grantingStack.Value;
                if (stack == null && createIfNull)
                    grantingStack.Value = stack = new Stack<HashSet<string>>();
            }

            return stack;
        }

        public bool HasPermission(string permission)
        { 
            var grantingStack = GetGrantingStack(false);

            if (grantingStack != null && grantingStack.Count > 0)
            {
                var permissionSet = grantingStack.Peek();
                if (permissionSet == null)
                    return true;

                return permissionSet.Contains(permission) ||
                    permissionService.HasPermission(permission);
            }

            return permissionService.HasPermission(permission);
        }

        public void Grant(params string[] permissions)
        {
            if (permissions == null || permissions.Length == 0)
                throw new ArgumentNullException("permissions");

            var grantingStack = GetGrantingStack(true);

            if (grantingStack.Count > 0)
            {
                var oldSet = grantingStack.Peek();
                if (oldSet == null)
                    grantingStack.Push(null);
                else
                {
                    var newSet = new HashSet<string>(oldSet);
                    newSet.AddRange(permissions);
                    grantingStack.Push(newSet);
                }
            }
            else
            {
                grantingStack.Push(new HashSet<string>(permissions));
            }
        }

        public void GrantAll()
        {
            var grantingStack = GetGrantingStack(true);
            grantingStack.Push(null);
        }

        public void UndoGrant()
        {
            var grantingStack = GetGrantingStack(false);
            if (grantingStack == null || grantingStack.Count == 0)
                throw new InvalidOperationException("UndoGrant() is called while Granting stack is empty!");

            grantingStack.Pop();
        }
    }
}