The purpose of this demo is to use the LEADTOOLS CloudServices SDK in a Serverless Azure Functions environment

To get started, you will need to fill in the configuration information in the DemoConfiguration class located in the following path: /Helper/Configuration.cs


Each API End point has the following required parameters:
	-firstPage
	-lastPage

This Demo Contains the following API End points and parameters
	-Conversion
		-ConvertToRaster
			-Parameters
				-format - Corresponds to the LEADTOOLS RasterImageFormat enumeration
		-ConvertToDocument
			-Parameters
				-format - Corresponds to the LEADTOOLS DocumentFormat enumeration
	-Recognition
		-ExtractAllBarcodes
			-Parameters
				-symbologies - A , delimited string of Barcode Symbologies.  Each symbology corresponds to a LEADTOOLS BarcodeSymbology. 
		-ExtractBarcode
			-Parameters
				-symbologies - A , delimited string of Barcode Symbologies.  Each symbology corresponds to a LEADTOOLS BarcodeSymbology.
		-ExtractText
			-No additional parameters
		-ExtractCheck
			-No additional parameters

	Files can be passed to the end points, either by passing a URL to the fileUrl parameter, or by uploading a file as Multipart-content with the request.

	You can use the following templates for testing requests:
	-Conversion
		-ConvertToRaster
			-{BaseUrl}/api/Conversion/ConvertToRaster?firstPage=1&lastPage=-1&format=3
		-ConvertToDocument
			-{BaseUrl}/api/Conversion/ConvertToDocument?firstPage=1&lastPage=-1&format=3
	-Recognition
		-ExtractAllBarcodes
			-{BaseUrl}/api/Recognition/ExtractAllBarcodes?firstPage=1&lastPage=-1&symbologies=X,x,x,x,x
		-ExtractBarcode
			-{BaseUrl}/api/Recognition/ExtractBarcode?firstPage=1&lastPage=-1&symbologies=X,x,x,x,x
		-ExtractText
			-{BaseUrl}/api/Recogntioin/ExtractText?firstPage=1&lastPage=-1
		-ExtractCheck
			-{BaseUrl}/api/Recogntioin/ExtractCheck?firstPage=1&lastPage=-1