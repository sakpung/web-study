// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Ccow;

namespace CCOWClientParticipationDemo.CCOW
{
    public class AuthenticationRepository
    {
        private IAuthenticationRepository _AuthRepository;

        private KeyContainer _KeyContainer = null;

        public KeyContainer KeyContainer
        {
            get
            {
                return _KeyContainer;
            }
        }

        public AuthenticationRepository(string ApplicationName)
        {
            _AuthRepository = Utils.COMCreateObject<IAuthenticationRepository>("CCOW.AuthenticationRepository");
            _KeyContainer = new KeyContainer(ApplicationName); 
        }
    }
}
