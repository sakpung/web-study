// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;

namespace Leadtools.Ccow.Dialogs
{
    public enum LogonTypes : uint
    {
        Interactive = 2,
        Network,
        Batch,
        Service,
        NetworkCleartext = 8,
        NewCredentials
    }

    public enum LogonProviders : uint
    {
        Default = 0, // default for platform (use this!)
        WinNT35, // sends smoke signals to authority
        WinNT40, // uses NTLM
        WinNT50 // negotiates Kerb or NTLM
    }

    /// <summary>
    /// Passed to <see cref="GetTokenInformation"/> to specify what
    /// information about the token to return.
    /// </summary>
    enum TokenInformationClass
    {
        TokenUser = 1,
        TokenGroups,
        TokenPrivileges,
        TokenOwner,
        TokenPrimaryGroup,
        TokenDefaultDacl,
        TokenSource,
        TokenType,
        TokenImpersonationLevel,
        TokenStatistics,
        TokenRestrictedSids,
        TokenSessionId,
        TokenGroupsAndPrivileges,
        TokenSessionReference,
        TokenSandBoxInert,
        TokenAuditPolicy,
        TokenOrigin,
        TokenElevationType,
        TokenLinkedToken,
        TokenElevation,
        TokenHasRestrictions,
        TokenAccessInformation,
        TokenVirtualizationAllowed,
        TokenVirtualizationEnabled,
        TokenIntegrityLevel,
        TokenUiAccess,
        TokenMandatoryPolicy,
        TokenLogonSid,
        MaxTokenInfoClass
    }

    /// <summary>
    /// The elevation type for a user token.
    /// </summary>
    enum TokenElevationType
    {
        TokenElevationTypeDefault = 1,
        TokenElevationTypeFull,
        TokenElevationTypeLimited
    }

    public class AuthenticationUtils
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string principal, string authority, string password,
                                            LogonTypes logonType, LogonProviders logonProvider, out IntPtr token);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(IntPtr tokenHandle, TokenInformationClass tokenInformationClass, IntPtr tokenInformation, int tokenInformationLength, out int returnLength);

        public static bool Login(string domain, string user, string password, out IntPtr token)
        {
            WindowsIdentity id;

            bool result = LogonUser(user, domain, password, LogonTypes.Network,
                                    LogonProviders.Default, out token);

            if (!result)
                return false;

            id = new WindowsIdentity(token);
            CloseHandle(token);
            WindowsPrincipal p = new WindowsPrincipal(id);
            Thread.CurrentPrincipal = p;

            return true;
        }

        public static bool IsAdmin(WindowsPrincipal principal)
        {
            var identity = principal.Identity as WindowsIdentity;

            if (identity == null) 
                throw new InvalidOperationException("Couldn't get the current user identity");            

            // Check if this user has the Administrator role. If they do, return immediately.
            // If UAC is on, and the process is not elevated, then this will actually return false.
            if (principal.IsInRole(WindowsBuiltInRole.Administrator)) return true;

            // If we're not running in Vista onwards, we don't have to worry about checking for UAC.
            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 6)
            {
                // Operating system does not support UAC; skipping elevation check.
                return false;
            }

            int tokenInfLength = Marshal.SizeOf(typeof(int));
            IntPtr tokenInformation = Marshal.AllocHGlobal(tokenInfLength);

            try
            {
                var token = identity.Token;
                var result = GetTokenInformation(token, TokenInformationClass.TokenElevationType, tokenInformation, tokenInfLength, out tokenInfLength);

                if (!result)
                {
                    var exception = Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
                    throw new InvalidOperationException("Couldn't get token information", exception);
                }

                var elevationType = (TokenElevationType)Marshal.ReadInt32(tokenInformation);

                switch (elevationType)
                {
                    case TokenElevationType.TokenElevationTypeDefault:
                        // TokenElevationTypeDefault - User is not using a split token, so they cannot elevate.
                        return false;
                    case TokenElevationType.TokenElevationTypeFull:
                        // TokenElevationTypeFull - User has a split token, and the process is running elevated. Assuming they're an administrator.
                        return true;
                    case TokenElevationType.TokenElevationTypeLimited:
                        // TokenElevationTypeLimited - User has a split token, but the process is not running elevated. Assuming they're an administrator.
                        return true;
                    default:
                        // Unknown token elevation type.
                        return false;
                }
            }
            finally
            {
                if (tokenInformation != IntPtr.Zero) Marshal.FreeHGlobal(tokenInformation);
            }
        }

        public static bool IsDomainAdmin(WindowsPrincipal principal)
        {
            WindowsIdentity identity = principal.Identity as WindowsIdentity;
            Domain d = Domain.GetDomain(new DirectoryContext(DirectoryContextType.Domain, getDomainName()));

            using (DirectoryEntry de = d.GetDirectoryEntry())
            {
                byte[] domainSIdArray = (byte[])de.Properties["objectSid"].Value;
                SecurityIdentifier domainSId = new SecurityIdentifier(domainSIdArray, 0);
                SecurityIdentifier domainAdminsSId = new SecurityIdentifier(
                WellKnownSidType.AccountDomainAdminsSid, domainSId);
                WindowsPrincipal wp = new WindowsPrincipal(identity);

                return wp.IsInRole(domainAdminsSId);
            }
        }

        private static string getDomainName()
        {
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }
    }
}
