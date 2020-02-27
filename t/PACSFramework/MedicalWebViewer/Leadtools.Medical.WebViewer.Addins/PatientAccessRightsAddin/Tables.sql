CREATE TABLE [RolesPatients] (

            [RoleID] [varchar] (128) NULL ,

            [PatientID] [nvarchar] (64) NULL ,

            [UserID] [varchar] (128) NULL ,

            [ID] [int] IDENTITY (1, 1) NOT NULL ,

            CONSTRAINT [PK_RolesPatients] PRIMARY KEY  CLUSTERED 

            (

                        [ID]

            )  ON [PRIMARY] ,

) ON [PRIMARY]
