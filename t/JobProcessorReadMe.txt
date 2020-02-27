This folder includes the LEADTOOLS Job Processor SDK demos. We recommended that you read the topic "Programming with 
LEADTOOLS Job Processor SDK" located in the LEADTOOLS .Net help file before developing with the LEADTOOLS Job Processor SDK. 

In order to simulate a Job Processor environment on a single development machine we have provided the 'Job Processor Host Demo'.
This demo will self-host all services and the database required to simulate a Job Processor environment.

LEADTOOLS also provides other installation packages which can be used to setup a distributed Job Processor environment built
using the LEADTOOLS Job Processor SDK (both server and any number of worker machines). Refer to 
https://www.leadtools.com/sdk/distributed-computing/setting-up-cloud for more information on these installation packages.


LEADTOOLS Job Processor SDK Demos:

-- Virtual Parallel Computing:
   The demos in this folder are designed to simulate a Job Processor environment on a single development machine.

	Self-Host Demo
	- Hosts the LEADTOOLS Job Processor WCF services.
	- Creates the Job Processor database on any network available SQL Server instance.

	Dashboard Demo
	- Simulates and debugs physical worker machines, with the ability to start/stop the service.
	- Simulates clients with the ability to add, abort, delete and reset jobs.


-- Distributed Parallel Computing:
   The demos in this folder implement a real-world distrubuted clould environment using a server and one or more worker machines.

	IIS Config Demo
	- Creates a virtual directory and an application pool for hosting the necessary WCF services and ASP.net demos in IIS.
	- Tests the virtual directory for the WCF service and ASP.net demos.
	- Creates the Job Processor database on any network available SQL Server instance.
	- Configures Job Processor worker machines.

	Administrator Demo
	- Views real time status of each worker.
	- Starts/Stops Job Processor services on each worker.
	- Deletes/Resets jobs.
	- Includes an 'Analyze Database' feature to fix database inconsistencies causes by critical errors.

	OCR Job Processor Demo
	- Worker assembly, used to convert images to searchable documents using the LEADTOOLS OCR SDK.

	Job Processor Client Demos
	- Adds, deletes and resets jobs.
	- Displays real time status of each job.
	- Downloads files successfully processed by the Job Processor.