// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
// Lightweight Job Scheduling Library for .NET
// Copyright (c) 2010 Philipp Sumi
// Contact and Information: http://www.Leadtools.Medical.Winforms.Forwarder.net
//
// This library is free software; you can redistribute it and/or
// modify it in any way you see fit as long as this copyright
// notice is not being removed.
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//
// THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE


using System;

namespace Leadtools.Medical.Winforms.Forwarder.Scheduling
{
  /// <summary>
  /// Simple helper class that provides an façade to
  /// <see cref="DateTimeOffset.Now"/> which can be substituted
  /// for simple testing of time-related code.<br/>
  /// Pattern taken from Ayende: http://ayende.com/Blog/archive/2008/07/07/Dealing-with-time-in-tests.aspx
  /// </summary>
  public static class SystemTime
  {
    /// <summary>
    /// Gets the system's current data and time. Only change for
    /// testing scenarios. Use <see cref="Reset"/> to
    /// reset the function to its default implementation.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
    public static Func<DateTimeOffset> Now;

    /// <summary>
    /// Reverts the <see cref="Now"/> function to its default
    /// implementation which just returns <see cref="DateTimeOffset.Now"/>.
    /// </summary>
    public static void Reset()
    {
      Now = () => DateTimeOffset.Now;
    }

    /// <summary>
    /// Inits the <see cref="Now"/> delegate.
    /// </summary>
    static SystemTime()
    {
      Reset();
    }
  }
}
