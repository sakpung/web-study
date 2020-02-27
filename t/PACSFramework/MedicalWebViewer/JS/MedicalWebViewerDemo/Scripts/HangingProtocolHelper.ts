// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../lib/LEADTOOLS/Leadtools.Controls.Medical.d.ts" />


class ModalityItem {
    public metadata;
    public Modality: string;
    public StudyDescription: string;
    public BodyPartExamined: string;
    public ProtocolName: string;
    public AnatomicRegionSequence: Array<Models.CodeSequence>;
    public ProcedureCodeSequence: Array<Models.CodeSequence>;
    public ReasonForRequestedProcedureCodeSequence: Array<Models.CodeSequence>;

    constructor(metadata, modality: string) {
        this.metadata = metadata;
        this.Modality = modality;
        this.AnatomicRegionSequence = new Array<Models.CodeSequence>();
        this.ProcedureCodeSequence = new Array<Models.CodeSequence>();
        this.ReasonForRequestedProcedureCodeSequence = new Array<Models.CodeSequence>();
    }
}

class HangingProtocolHelper {

    public static get_HangingProtocol(viewer: lt.Controls.Medical.MedicalViewer, primaryCell: lt.Controls.Medical.Cell, metadata): Models.HangingProtocol {
        var hp: Models.HangingProtocol = new Models.HangingProtocol();
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var authenticationService: AuthenticationService = injector.get('authenticationService');
        var modalities: Array<ModalityItem> = HangingProtocolHelper.get_ModalityItemsInView(viewer);
        var studyDescription: string = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyDescription);
        var selectedModality: string = DicomHelper.getDicomTagValue(metadata, DicomTag.Modality);

        // Hanging Protocol Name (Mandatory)       
        if (studyDescription == null)
            hp.HangingProtocolName = selectedModality;
        else
            hp.HangingProtocolName = (selectedModality + " " + studyDescription).substring(0, 16);

        // Hanging Protocol Description (Mandatory)
        hp.HangingProtocolDescription = studyDescription;
        if (hp.HangingProtocolDescription == null)
            hp.HangingProtocolDescription = hp.HangingProtocolName;

        // Hanging Protocol Level (Mandatory)
        hp.HangingProtocolLevel = Models.HangingProtocolLevel.Site;

        // Hanging Protocol Creator (Mandatory)
        hp.HangingProtocolCreator = authenticationService.user;

        // Hanging Protocol Creation DateTime (Mandatory)
        hp.WCFHangingProtocolCreationDateTime = new Date();

        // Hanging Protocol Definition Sequence (Mandatory)
        for (var i: number = 0; i < modalities.length; i++) {
            var hpd: Models.HangingProtocolDefinition = new Models.HangingProtocolDefinition();

            // Modality (Conditional)
            hpd.Modality = modalities[i].Modality;

            // 
            hpd.StudyDescription = modalities[i].StudyDescription;

            // Procedure Code Sequence (Mandatory)
            hpd.ProcedureCodeSequence = modalities[i].ProcedureCodeSequence;

            // Anatomic Region Sequence (Conditional)
            hpd.AnatomicRegionSequence = modalities[i].AnatomicRegionSequence;

            // Laterality (Conditional)

            // Reason for Requested Procedure Code Sequence (Mandatory)
            hpd.ReasonForRequestedProcedureCodeSequence = modalities[i].ReasonForRequestedProcedureCodeSequence;

            //
            hpd.BodyPartExamined = modalities[i].BodyPartExamined;

            //
            hpd.ProtocolName = modalities[i].ProtocolName;
            hpd["metadata"] = modalities[i].metadata;
            hp.HangingProtocolDefinitionSequence.push(hpd);
        }

        // Hanging Protocol User Identification Code Sequence (Mandatory)
        hp.HangingProtocolUserIdentificationCodeSequence = new Array<Models.HangingProtocolUserIdentificationCode>();

        // Hanging Protocol User Group Name (Optional)
        // xxx

        // Source Hanging Protocol Sequence (Optional)
        // xxx

        // Number of Priors Referenced (Mandatory)
        hp.NumberOfPriorsReferenced = 0;

        // Image Sets Sequence (Mandatory)
        this.get_ImageSets(viewer, primaryCell, hp);

        // Number of Screens (Mandatory)
        hp.NumberOfScreens = 1;

        // Nominal Screen Definition Sequence (Mandatory)
        this.setNominalScreenDefinitionSequence(hp);

        // Display Sets Sequence (Mandatory)
        // constructor

        // Partial Data Display Handling (Mandatory)
        hp.PartialDataDisplayHandling = Models.PartialDataDisplayHandling.MaintainLayout;

        // Synchronized Scrolling Sequence (Optional)
        // assigned in get_ImageSets

        // Navigation Indicator Sequence (Optional)
        // assigned in get_ImageSets

         
        // LEAD specific
        if (viewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
            hp.Rows = viewer.gridLayout.rows;
            hp.Columns = viewer.gridLayout.columns;
        }

        return hp;
    }

    public static ConvertToHorizontalAlignmentType(frameHorizontalJustication: Models.FrameHorizontalJustification): lt.Controls.Medical.HorizontalAlignmentType {
        var horizontalAlignmentType: lt.Controls.Medical.HorizontalAlignmentType = lt.Controls.Medical.HorizontalAlignmentType.middle;

        switch (frameHorizontalJustication) {
            case Models.FrameHorizontalJustification.Center:
                horizontalAlignmentType = lt.Controls.Medical.HorizontalAlignmentType.middle;
                break;

            case Models.FrameHorizontalJustification.Left:
                horizontalAlignmentType = lt.Controls.Medical.HorizontalAlignmentType.left;
                break;

            case Models.FrameHorizontalJustification.Right:
                horizontalAlignmentType = lt.Controls.Medical.HorizontalAlignmentType.right;
                break;
        }
        return horizontalAlignmentType;
    }

    public static ConvertToFrameHorizontalJustication(horizontalAlignmentType: lt.Controls.Medical.HorizontalAlignmentType): Models.FrameHorizontalJustification {
        var frameHorizontalJustication: Models.FrameHorizontalJustification = Models.FrameHorizontalJustification.Center;

        switch (horizontalAlignmentType) {
            case lt.Controls.Medical.HorizontalAlignmentType.middle:
                frameHorizontalJustication = Models.FrameHorizontalJustification.Center;
                break;

            case lt.Controls.Medical.HorizontalAlignmentType.left:
                frameHorizontalJustication = Models.FrameHorizontalJustification.Left;
                break;

            case lt.Controls.Medical.HorizontalAlignmentType.right:
                frameHorizontalJustication = Models.FrameHorizontalJustification.Right;
                break;
        }
        return frameHorizontalJustication;
    }



    public static ConvertToVerticalAlignmentType(frameVerticalJustication: Models.FrameVerticalJustification): lt.Controls.Medical.VerticalAlignmentType {
        var horizontalAlignmentType: lt.Controls.Medical.VerticalAlignmentType = lt.Controls.Medical.VerticalAlignmentType.middle;

        switch (frameVerticalJustication) {
            case Models.FrameVerticalJustification.Center:
                horizontalAlignmentType = lt.Controls.Medical.VerticalAlignmentType.middle;
                break;

            case Models.FrameVerticalJustification.Bottom:
                horizontalAlignmentType = lt.Controls.Medical.VerticalAlignmentType.bottom;
                break;

            case Models.FrameVerticalJustification.Top:
                horizontalAlignmentType = lt.Controls.Medical.VerticalAlignmentType.top;
                break;
        }
        return horizontalAlignmentType;
    }

    public static ConvertToFrameVerticalJustication(horizontalAlignmentType: lt.Controls.Medical.VerticalAlignmentType): Models.FrameVerticalJustification {
        var frameVerticalJustication: Models.FrameVerticalJustification = Models.FrameVerticalJustification.Center;

        switch (horizontalAlignmentType) {
            case lt.Controls.Medical.VerticalAlignmentType.middle:
                frameVerticalJustication = Models.FrameVerticalJustification.Center;
                break;

            case lt.Controls.Medical.VerticalAlignmentType.top:
                frameVerticalJustication = Models.FrameVerticalJustification.Top;
                break;

            case lt.Controls.Medical.VerticalAlignmentType.bottom:
                frameVerticalJustication = Models.FrameVerticalJustification.Bottom;
                break;
        }
        return frameVerticalJustication;
    }



    //public static GetCellMprTypeName(mprType: lt.Controls.Medical.CellMPRType) : string {
    //    var ret: string = "";

    //    switch (mprType) {
    //        case lt.Controls.Medical.CellMPRType.axial:
    //            ret = "Axial";
    //            break;

    //        case lt.Controls.Medical.CellMPRType.sagittal:
    //            ret = "Sagittal";
    //            break;

    //        case lt.Controls.Medical.CellMPRType.coronal:
    //            ret = "Coronal";
    //            break;

    //        case lt.Controls.Medical.CellMPRType.none:
    //            ret = "";
    //            break;
    //    }
    //    return ret;
    //}

    public static GetCellMprTypeSelectorValue(mprType: lt.Controls.Medical.CellMPRType): string {
        var ret: string = "";

        switch (mprType) {
            case lt.Controls.Medical.CellMPRType.axial:
                ret = "TRANSVERSE";
                break;

            case lt.Controls.Medical.CellMPRType.sagittal:
                ret = "SAGITTAL";
                break;

            case lt.Controls.Medical.CellMPRType.coronal:
                ret = "CORONAL";
                break;

            case lt.Controls.Medical.CellMPRType.none:
                ret = "";
                break;
        }
        return ret;
    }


    private static getTimeBasedImageSetLabel(prefix: string, imageSetName: string): string {
        var result = imageSetName.replace("Image Set", "");
        result = result.trim();
        result = prefix + " " + result;
        return result;
    }

    private static get_ImageSets(viewer: lt.Controls.Medical.MedicalViewer, primaryCell: lt.Controls.Medical.Cell, hp: Models.HangingProtocol) {
        var count: number = viewer.layout.items.count;
        // var imageSetNumber: number = 0;
        var displaySetNumber: number = 1;
        var imageBoxNumber: number = 1;
        var sets: any = {};
        var modalitySplit = HangingProtocolHelper.split_cells(viewer);  
        var pixelSpacing: number = 1.0;        

        for (var i = 0; i < count; i++) {
            var cell: lt.Controls.Medical.Cell = viewer.layout.items.item(i);                      

            if (cell.frames.count > 0) {
                var firstFrame: lt.Controls.Medical.Frame = cell.frames.item(0);
                var activeFrame: lt.Controls.Medical.Frame = HangingProtocolHelper.get_activeFrame(cell);
                var metadata: any = firstFrame["metadata"];

                if (metadata != null) {
                    pixelSpacing = DicomHelper.getDicomTagValue(metadata, DicomTag.PixelSpacing);
                }
                                
                var parentDisplaySet: Models.DisplaySet = Utils.findFirst(hp.DisplaySets, function (item) {
                    var parentCell: lt.Controls.Medical.Cell = item['cell'];

                    if (parentCell) {
                        return parentCell.derivatives.contains(cell);
                    }
                    return false;
                });                               

                if (parentDisplaySet) {

                    // *************************************
                    // MPR -- generated (reformatted) stacks
                    // *************************************

                    var displaySet: Models.DisplaySet = new Models.DisplaySet();

                    // Display Set Number (Mandatory)
                    displaySet.DisplaySetNumber = displaySetNumber;

                    // Display Set Label (Optional)
                    displaySet.DisplaySetLabel = "Display Set " + displaySetNumber;

                    // Display Set Presentation Group (Mandatory)
                    displaySet.DisplaySetPresentationGroup = 1;

                    // Image Set Number (Mandatory)
                    displaySet.ImageSetNumber = parentDisplaySet.ImageSetNumber;

                    // Image Boxes Sequence (Mandatory)
                    var box: Models.ImageBox = HangingProtocolHelper.get_cellImageBox(cell, imageBoxNumber);
                    displaySet.Boxes.push(box);
                    
                    // Filter Operations Sequence (Mandatory)
                    this.setFilterOperationsMpr(displaySet, cell);

                    // Sorting Operations Sequence (Mandatory)
                    this.setSortingOperationsMpr(displaySet, cell);

                    // Blending Operation Type (Optional)
                    // xxx

                    // Reformatting Operation Type (Optiona)
                    this.setReformattingOptions(displaySet, cell, pixelSpacing);

                    // 3D Rendering Type (Conditional)

                    // Display Set Patient Orientation (Optional)
                    this.setDisplaySetPatientOrientation(activeFrame, displaySet);

                    // Display Set Horizontal Justification (Optional)
                    displaySet.DisplaySetHorizontalJustification = this.ConvertToFrameHorizontalJustication(activeFrame.horizontalAlignment);  
                    
                    // Display Set Vertical Justification (Optional)        
                    displaySet.DisplaySetVerticalJustification = this.ConvertToFrameVerticalJustication(activeFrame.verticalAlignment);

                    // VOI Type (Optional)
                    displaySet.VoiType = this.get_voiType(cell);

                    // Pseudo-Color Type (Optional)
                    // xxx

                    // Pseudo-Color Palette Instance Reference Sequence (Conditional)
                    // xxx

                    // Show Grayscale Inverted (Optional)
                    // xxx

                    // Show Image True Size Flag (Optional)
                    // xxx

                    // Show Graphic Annotation Flag (Optional)
                    // xxx

                    // Show Patient Demographics Flag (Optional)
                    // xxx

                    // Show Acquisition Techniques Flag (Optional)
                    // xxx

                    // Display Set Presentation Group Description (Optional)
                    // xxx

                    // displaySet["CombinedName"] = displaySet.DisplaySetLabel + " - " + "MPR Reformatted " + this.GetCellMprTypeName(cell.mprType); //+ imageSet.Name;
                    displaySet['cell'] = cell;                    

                    imageBoxNumber++;
                    displaySetNumber++;

                    hp.DisplaySets.push(displaySet);
                }
                else {
                    if (metadata) {
                        var imageSet: Models.ImageSet;
                        var imageSetSelector: Models.ImageSetSelector;
                        var modality: string = DicomHelper.getDicomTagValue(metadata, DicomTag.Modality);
                        var bodyPart: string = DicomHelper.getDicomTagValue(metadata, DicomTag.BodyPartExamined);        
                        var studyDescription: string;  
                        var box: Models.ImageBox = HangingProtocolHelper.get_cellImageBox(cell, imageBoxNumber);
                        var setKey: string;

                        var studyInstanceUid: string = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyInstanceUID);

                        if (!bodyPart) {
                            bodyPart = "";
                        }

                        if (bodyPart.length == 0) {
                            studyDescription = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyDescription);                           
                        }

                        if (!studyDescription)
                            studyDescription = "";
                        
                        var ignoreStudyTime: boolean = true;
                        var studyDateString: string = DicomHelper.getStudyDateTimeString(metadata, ignoreStudyTime, true);
                        var studyDate: IDateJS = DicomHelper.getStudyDateTime(metadata, ignoreStudyTime);
                        var sopClass: string = DicomHelper.getDicomTagValue(metadata, DicomTag.SOPClassUID);

                        // Test for encapsulated PDF
                        var isPdf: boolean = false;
                        if (sopClass == "1.2.840.10008.5.1.4.1.1.104.1")
                            isPdf = true;

                        // setKey = modality + bodyPart + studyDescription;//  + studyDateString;
                        // setKey = modality + "|" + sopClass + "|" + bodyPart + "|" + studyDescription; // + "|" + studyInstanceUid;//  + studyDateString;
                        // setKey = modality + "|" + sopClass + "|" + bodyPart;
                        setKey = modality + "|" + sopClass;
                        if (!sets[setKey]) {
                            imageSet = new Models.ImageSet();
                            imageSet['metadata'] = metadata;
                            sets[setKey] = imageSet;

                            imageSet.Name = modality;
                            if (isPdf)
                                imageSet.Name = imageSet.Name + " PDF";
                            if (bodyPart.length > 0) {
                                imageSet.Name = imageSet.Name + " [" + bodyPart + "]";
                            }
                            imageSet.Name = imageSet.Name + /* studyDateString + */ " Image Set "; // + imageSetNumber;

                            // imageSetNumber++;
                            hp.ImageSetsSequence.push(imageSet);
                        }
                        else {
                            imageSet = sets[setKey];
                        }

                        if (imageSet.ImageSetSelectorSequence.length == 0) {
                            imageSetSelector = new Models.ImageSetSelector();
                            imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.NoMatch;
                            imageSetSelector.WCFSelectorAttribute = Utils.insert(DicomTag.Modality, 4, ":");
                            imageSetSelector.SelectorValueNumber = 1;
                            imageSetSelector.SelectorValue = modality;
                            imageSetSelector.SelectorName = 'Modality';
                            imageSet.ImageSetSelectorSequence.push(imageSetSelector);

                            if (sopClass.length != 0) {
                                imageSetSelector = new Models.ImageSetSelector();
                                imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.NoMatch;
                                imageSetSelector.WCFSelectorAttribute = Utils.insert(DicomTag.SOPClassUID, 4, ":");
                                imageSetSelector.SelectorValueNumber = 1;
                                imageSetSelector.SelectorValue = sopClass;
                                imageSetSelector.SelectorName = 'SOP Class UID';
                                imageSet.ImageSetSelectorSequence.push(imageSetSelector);
                            }
                        }

                        // Add the following items as MATCH (match if not present)
                        imageSet.UpdateImageSelectorItem(metadata, DicomTag.BodyPartExamined, "Body Part Examined");
                        imageSet.UpdateImageSelectorItem(metadata, DicomTag.Laterality, "Laterality");
                        imageSet.UpdateImageSelectorItem(metadata, DicomTag.ProtocolName, "Protocol Name");
                        imageSet.UpdateImageSelectorItem(metadata, DicomTag.StudyDescription, "Study Description");
                        imageSet.UpdateImageSelectorItem(metadata, DicomTag.ImageLaterality, "Image Laterality");


                        //if (bodyPart.length != 0) {
                        //    imageSetSelector = new Models.ImageSetSelector();
                        //    imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.Match;
                        //    imageSetSelector.WCFSelectorAttribute = Utils.insert(DicomTag.BodyPartExamined, 4, ":");
                        //    imageSetSelector.SelectorValueNumber = 1;
                        //    imageSetSelector.SelectorValue = bodyPart;
                        //    imageSetSelector.SelectorName = 'Body Part Examined';
                        //    imageSet.ImageSetSelectorSequence.push(imageSetSelector);
                        //}
                        //// (10.27.2016 -- Xxxx) put this back
                        //if (studyDescription.length > 0) {
                        //    imageSetSelector = new Models.ImageSetSelector();
                        //    imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.NoMatch;
                        //    imageSetSelector.WCFSelectorAttribute = Utils.insert(DicomTag.StudyDescription, 4, ":");
                        //    imageSetSelector.SelectorValueNumber = 1;
                        //    imageSetSelector.SelectorValue = studyDescription;
                        //    imageSetSelector.SelectorName = 'Study Description';
                        //    imageSet.ImageSetSelectorSequence.push(imageSetSelector);
                        //}

                        // remove this code
                        //var imageLaterality: string = DicomHelper.getDicomTagValue(metadata, DicomTag.ImageLaterality);
                        //if (imageLaterality.length > 0) {
                        //    imageSetSelector = new Models.ImageSetSelector();
                        //    imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.NoMatch;
                        //    imageSetSelector.WCFSelectorAttribute = Utils.insert(DicomTag.ImageLaterality, 4, ":");
                        //    imageSetSelector.SelectorValueNumber = 1;
                        //    imageSetSelector.SelectorValue = imageLaterality;
                        //    imageSetSelector.SelectorName = 'Image Laterality ';
                        //    imageSet.ImageSetSelectorSequence.push(imageSetSelector);
                        //}


                        // if (!modalitySplit[setKey] || modalitySplit[setKey].length == 1 || modalitySplit[setKey].indexOf(cell) == 0)
                        // if (imageSet.TimeBasedImageSetsSequence.length == 0) {

                        var currentImageSetNumber: number = imageSet.FindTimeBasedImageSetNumber(studyDate);
                        if (currentImageSetNumber == 0) {
                            currentImageSetNumber = hp.getNextImageSetNumber();
                            currentImageSetNumber = imageSet.AddTimeBasedImageSet(studyDate, currentImageSetNumber);
                        }
                        //else {
                        //    alert("Image Set not getting added");
                        //}

                        // This is the priors code, which we are currently not using
                        // 
                        //else
                        //{
                        //    var prior = modalitySplit[setKey].indexOf(cell);
                        //    var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
                        //    var dataService: DataService = injector.get('dataService');
                        //    var series: Array<any> = dataService.get_allSeries();
                        //    var found = Utils.findFirst(series, function (item) {
                        //        return item.InstanceUID == cell.seriesInstanceUID;
                        //    });

                        //    if (found) {
                        //        prior = 1 + series.indexOf(found);
                        //    }

                        //    tmImageSetSelector.ImageSetLabel = "Prior " + modality + " " + bodyPart;
                        //    tmImageSetSelector.ImageSetNumber = ++imageSetNumber;
                        //    tmImageSetSelector.ImageSetSelectorCategory = Models.ImageSetSelectorCategory.AbstractPrior;
                        //    tmImageSetSelector.AbstractPriorValue.push(prior);
                        //    tmImageSetSelector.AbstractPriorValue.push(prior);
                        //    imageSet.TimeBasedImageSetsSequence.push(tmImageSetSelector);
                        //    hp.NumberOfPriorsReferenced += 1;
                        //}

                        var displaySet: Models.DisplaySet = new Models.DisplaySet();
                        if (activeFrame) {
                            displaySet['metadata'] = activeFrame['metadata'];
                        }

                        // Display Set Number (Mandatory)
                        displaySet.DisplaySetNumber = displaySetNumber;

                        // Display Set Label (Optional)
                        displaySet.DisplaySetLabel = "Display Set " + displaySetNumber;

                        // Display Set Presentation Group (Mandatory)
                        displaySet.DisplaySetPresentationGroup = 1;

                        // Image Set Number (Mandatory)
                        displaySet.ImageSetNumber = currentImageSetNumber; //imageSet.TimeBasedImageSetsSequence[0].ImageSetNumber; // tmImageSetSelector.ImageSetNumber;

                        // Image Boxes Sequence (Mandatory)                        
                        displaySet.Boxes.push(box);

                        // Filter Operations Sequence (Mandatory)
                        HangingProtocolHelper.checkFilterOperations(displaySet);

                        // Sorting Operations Sequence (Mandatory)
                        HangingProtocolHelper.checkSortingOperations(displaySet, cell);

                        // Blending Operation Type (Optional)
                        // xxx
                        
                        // Reformatting Operation Type (Optional)
                        //if (cell.derivatives.count > 0) { // <== means MPR original cell (i.e. not derived MPR cell)
                            // Do not write the reformatting options for the MPR original cell -- only the derived MPR cells
                            // Note that the three display sets that correspond to the MPR all reference the same image set!
                            // this.setReformattingOptions(displaySet, cell, pixelSpacing);
                        //}   

                        // 3D Rendering Type (Conditional)
                        // xxx

                        // Display Set Patient Orientation (Optional)
                        this.setDisplaySetPatientOrientation(activeFrame, displaySet);

                        // Display Set Horizontal Justification (Optional)
                        displaySet.DisplaySetHorizontalJustification = this.ConvertToFrameHorizontalJustication(activeFrame.horizontalAlignment); 
                         
                        // Display Set Vertical Justification (Optional)
                        displaySet.DisplaySetVerticalJustification = this.ConvertToFrameVerticalJustication(activeFrame.verticalAlignment);

                        // VOI Type (Optional)
                        displaySet.VoiType = this.get_voiType(cell);

                        // Pseudo-Color Type (Optional)
                        // xxx

                        // Pseudo-Color Palette Instance Reference Sequence (Conditional)
                        // xxx
                 
                        // Show Grayscale Inverted (Optional)
                        displaySet.ShowGrayscaleInverted = this.get_invertedFlag(cell);

                        // Show Image True Size Flag (Optional)
                        displaySet.ShowImageTrueSizeFlag = this.get_showImageTrueSize(cell); 

                        // Show Graphic Annotation Flag (Optional)
                        displaySet.ShowGraphicAnnotationFlag = this.get_annotationFlag(cell);

                        // Show Patient Demographics Flag (Optional)
                        displaySet.ShowPatientDemographicsFlag = cell.overlayTextVisible;

                        // Show Acquisition Techniques Flag (Optional)
                        // xxx

                        // Display Set Presentation Group Description (Optional)
                        // xxx
                        var notUsed: string = hp.getTimeBasedImageSetLabel(displaySet.ImageSetNumber);

                        // displaySet["CombinedName"] = displaySet.DisplaySetLabel + " - " + imageSet.Name;
                        displaySet['cell'] = cell;
                   
                        imageBoxNumber++;
                        displaySetNumber++;

                        hp.DisplaySets.push(displaySet);
                    }
                }
            }                    
        }

        //*******************************************
        // Code to update the Priors

        for (var i = 0; i < hp.ImageSetsSequence.length; i++) {
            hp.ImageSetsSequence[i].TimeBasedImageSetsSequence.sort(function (a, b) {
                return (-1) * a.StudyDateTime.compareTo(b.StudyDateTime);
            }); 

            // Update current and Priors information (TimeBasedImageSetsSequence)
            for (var index = 0; index < hp.ImageSetsSequence[i].TimeBasedImageSetsSequence.length; index++) {
                var timeBasedImageSet: Models.TimeBasedImageSet = hp.ImageSetsSequence[i].TimeBasedImageSetsSequence[index];

                if (index == 0) { // <== Most current
                    // Image Set Selector Category (Mandatory)
                    timeBasedImageSet.ImageSetSelectorCategory = Models.ImageSetSelectorCategory.RelativeTime;

                    // Relative Time (Conditional)
                    timeBasedImageSet.RelativeTime.push(0);
                    timeBasedImageSet.RelativeTime.push(0);

                    // Relative Time Units (Conditional)
                    timeBasedImageSet.RelativeTimeUnits = Models.RelativeTimeUnits.Minutes;

                    // Image Set Label (Optional)                   
                    timeBasedImageSet.ImageSetLabel = this.getTimeBasedImageSetLabel("Current", hp.ImageSetsSequence[i].Name);
                }
                else { // <== Prior(s)
                    // Image Set Selector Category (Mandatory)
                    timeBasedImageSet.ImageSetSelectorCategory = Models.ImageSetSelectorCategory.AbstractPrior;

                    // Abstract Prior Value (Conditional)
                    timeBasedImageSet.AbstractPriorValue.push(index);
                    timeBasedImageSet.AbstractPriorValue.push(index);

                    // Image Set Label (Optional)
                    var priorPrefix: string = Utils.GetNumericPrefix(index);                  
                    // timeBasedImageSet.ImageSetLabel = priorPrefix + " Prior " + modality + " " + bodyPart;
                    timeBasedImageSet.ImageSetLabel = this.getTimeBasedImageSetLabel(priorPrefix + " Prior", hp.ImageSetsSequence[i].Name);
                }
            }
        }

        hp.updateDisplaySetCombinedName();

        // Number of Priors Referenced (Mandatory)
        hp.NumberOfPriorsReferenced = hp.getNumberOfPriorsReferenced();

        hp.updateImageSetSelectorValues();
        //*******************************************

        this.setReferenceLine(viewer, hp);
        this.setSynchronizedScrolling(viewer, hp);
        this.setSynchronizedScrollingMprDerived(viewer, hp);

        count = viewer.emptyDivs.items.count;
        for (var i = 0; i < count; i++) {
            var emptyCell: lt.Controls.Medical.EmptyCell = viewer.emptyDivs.items.item(i);
            var displaySet: Models.DisplaySet = new Models.DisplaySet();

            // Display Set Number (Mandatory)
            displaySet.DisplaySetNumber = displaySetNumber++;

            // Display Set Label (Optional)
            displaySet.DisplaySetLabel = "Display Set " + displaySet.DisplaySetNumber;   
            
            // Display Set Presentation Group (Mandatory)
            // xxx
               
            // Image Set Number (Mandatory)      
            displaySet.ImageSetNumber = -1;

            // Image Boxes Sequence (Mandatory)
            var box: Models.ImageBox = HangingProtocolHelper.get_emptyCellImageBox(emptyCell, imageBoxNumber++);
            displaySet.Boxes.push(box);
            hp.DisplaySets.push(displaySet);

            // Filter Operations Sequence (Mandatory)
            // xxx

            // Sorting Operations Sequence (Mandatory)
            // xxx

            // Blending Operation Type (Optional)
            // xxx

            // Reformatting Operation Type (Optional)
            // xxx

            // 3D Rendering Type (Conditional)
            // xxx

            // Display Set Patient Orientation (Optional)
            displaySet.DisplaySetPatientOrientation = null;  

            // Display Set Horizontal Justification (Optional)
            // xxx

            // Display Set Vertical Justification (Optional)
            // xxx

            // VOI Type (Optional)
            // xxx

            // Pseudo-Color Type (Optional)
            // xxx

            // Pseudo-Color Palette Instance Reference Sequence (Conditional)
            // xxx

            // Show Grayscale Inverted (Optional)
            displaySet.ShowGrayscaleInverted = this.get_invertedFlag(cell);

            // Show Image True Size Flag (Optional)
            displaySet.ShowImageTrueSizeFlag = this.get_showImageTrueSize(cell); 

            // Show Graphic Annotation Flag (Optional)
            // xxx

            // Show Patient Demographics Flag (Optional)
            // xxx

            // Show Acquisition Techniques Flag (Optional)
            // xxx

            // Display Set Presentation Group Description (Optional)
            // xxx
        }
    }

    public static get_activeFrame(cell: lt.Controls.Medical.Cell): lt.Controls.Medical.Frame {
        if (cell) {
            var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
            var seriesManagerService: SeriesManagerService = injector.get('seriesManagerService');
            var index = seriesManagerService.get_activeSubCellIndex(cell);

            return (<lt.Controls.Medical.SubCell>(cell.imageViewer.items.get_item(index))).attachedFrame;
        }
        return null;
    }

    private static get_allValues(cell: lt.Controls.Medical.Cell, field: string) {
            var returnValue = null;
            var count = cell.frames.count;

            // get first value
            var frame = cell.frames.get_item(0);
            if (frame.hasOwnProperty(field)) {
                returnValue = frame[field];
            }

            if (returnValue == null)
                return null;

            // All frames must have same returnValue to return returnValue
            // Otherwise, return null
            for (var i = 1; i < count; i++) {
                var frame = cell.frames.get_item(i);

                if (!frame.hasOwnProperty(field)) {
                    return null;
                }
                if (returnValue != frame[field]) {
                    return null;
                }
            }
            return returnValue;
    }

    public static get_voiType(cell: lt.Controls.Medical.Cell): Models.VoiType {
        var voiType: Models.VoiType = null;
        var voiTypeItem = this.get_allValues(cell, 'currentCustomWindowlevel');
        if (voiTypeItem != null) {
            if (voiTypeItem.hasOwnProperty('VoiType')){
                voiType = voiTypeItem["VoiType"];
                }
        }
        return voiType == Models.VoiType.Undefined ? null : voiType;
    }

    public static get_invertedFlag(cell: lt.Controls.Medical.Cell): boolean {

        var inverted: boolean = this.get_allValues(cell, '_inverted');
        return inverted;
    }

    public static get_showImageTrueSize(cell: lt.Controls.Medical.Cell): boolean {
        var imageTrueSize: lt.Controls.Medical.MedicalViewerSizeMode = this.get_allValues(cell, '_sizeMode');
        return imageTrueSize == lt.Controls.Medical.MedicalViewerSizeMode.trueSize ? true : null;
    }

    public static get_annotationFlag(cell: lt.Controls.Medical.Cell): boolean {
        var automation: lt.Annotations.Automation.AnnAutomation = cell.automation;

        return automation.activeContainer.isVisible;
    }

    public static setReformattingOptions(displaySet: Models.DisplaySet, cell : lt.Controls.Medical.Cell, pixelSpacing : number) {
        displaySet.ReformattingOperationType = Models.ReformattingOperationType.Mpr;
        displaySet.ReformattingThickness = 1.0;             // MedicalViewer does not currently return this value so default
        displaySet.ReformattingInterval = pixelSpacing;
        displaySet.ReformattingOperationInitialViewDirection = <any>cell.mprType;
    }
    
    public static checkFilterOperations(displaySet: Models.DisplaySet) {
        var metadata = displaySet['metadata'];
        var imageTypes: Array<string> = DicomHelper.get_allValues(metadata, DicomTag.ImageType);
        var value: string;
        var filterOperation: Models.FilterOperation;

        // Check if non-image DICOM Dataset (like encapsulated PDF)  
        // If non-image, add SOPClassUID
        var isImage: boolean = DicomHelper.IsDicomImage(metadata);
        if (!isImage) {
            value = DicomHelper.getDicomTagValue(metadata, DicomTag.SOPClassUID);
            if (value) {
                filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.SOPClassUID, 1, value);
                filterOperation.SelectorName = 'SOP Class UID';
                filterOperation.SelectorAttributeVr = "UI";
                displaySet.FilterOperationsSequence.push(filterOperation);
            }

            //value = DicomHelper.getDicomTagValue(metadata, DicomTag.DocumentTitle);
            //if (value) {
            //    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.DocumentTitle, 1, value);
            //    filterOperation.SelectorName = 'Document Title';
            //    filterOperation.SelectorAttributeVr = "ST";
            //    displaySet.FilterOperationsSequence.push(filterOperation);
            //}
        }

        // Value 3 of Image Type (0008,0008)
        if (imageTypes.length >= 3) {
            // Check if 3rd value contains only white space
            var onlyWhitespace = ($.trim(imageTypes[2]).length === 0);
            if (!onlyWhitespace) {
                filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ImageType, 3, imageTypes[2]);
                filterOperation.SelectorName = 'Image Type';
                filterOperation.SelectorAttributeVr = "CS";
                displaySet.FilterOperationsSequence.push(filterOperation);
            }
            else {
                // Check if 4th value contains only white space
                onlyWhitespace = ($.trim(imageTypes[3]).length === 0);
                if (!onlyWhitespace) {
                    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ImageType, 4, imageTypes[3]);
                    filterOperation.SelectorName = 'Image Type';
                    filterOperation.SelectorAttributeVr = "CS";
                    displaySet.FilterOperationsSequence.push(filterOperation);
                }
            }
        }

        // Anatomic Region Sequence (0008,2218)

        // Pixel Presentation (0008, 9205)

        // Volume Based Calculation Technique (0008,9207)

        // Acquisition Contrast (0008,9209)

        // Contrast/Bolus Agent (0018,0010)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.ContrastBolusAgent);
        if (value && (typeof value != "string" || (typeof value == "string" && value.length > 0))) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ContrastBolusAgent, 1, value);
            filterOperation.SelectorName = 'Contrast/Bolus Agent';
            filterOperation.SelectorAttributeVr = "LO";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }

        // Body Part Examined (0018, 0015)

        // Scanning Sequence (0018,0020)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.ScanningSequence);
        if (value && (typeof value != "string" || (typeof value == "string" && value.length > 0))) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ScanningSequence, 1, value);
            filterOperation.SelectorName = 'Scanning Sequence';
            filterOperation.SelectorAttributeVr = "CS";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }

        // Intervention Drug Start Time (0018,0035)

        // Echo Time (0018,0081)
        //value = DicomHelper.getDicomTagValue(metadata, DicomTag.EchoTime);
        //if (value && (typeof value != "string" || (typeof value == "string" && value.length > 0))) {
        //    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.EchoTime, 1, value);
        //    filterOperation.SelectorName = 'Echo Time';
        //    filterOperation.SelectorAttributeVr = "DS";
        //    displaySet.FilterOperationsSequence.push(filterOperation);
        //}

        // Echo Number(s) (0018,0086)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.EchoNumber);
        if (value) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.EchoNumber, 1, value);
            filterOperation.SelectorName = 'Echo Numbers';
            filterOperation.SelectorAttributeVr = "IS";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }

        // Protocol Name (0018,1030)
        if (!value) {
            value = DicomHelper.getDicomTagValue(metadata, DicomTag.ProtocolName);
            if (value && (typeof value != "string" || (typeof value == "string" && value.length > 0))) {
                filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ProtocolName, 1, value);
                filterOperation.SelectorName = 'Protocol Name';
                filterOperation.SelectorAttributeVr = "LO";
                displaySet.FilterOperationsSequence.push(filterOperation);
            }
        }

        // Contrast/Bolus Start Time (0018,1042)
        // Contrast/Bolus Stop Time (0018,1043)
        // Trigger Time (0018,1060)
        // Image Trigger Delay (0018,1067)
        // Radiopharmaceutical Start Time (0018,1072)
        // Radiopharmaceutical Stop Time (0018,1073)
        // Trigger Window (0018,1094)
        // View Position (0018,5101)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.ViewPosition);
        if (value) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ViewPosition, 1, value);
            filterOperation.SelectorName = 'View Position';
            filterOperation.SelectorAttributeVr = "CS";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }

        // Echo Pulse Sequence (0018,9008)
        // Phase Contrast (0018,9014)
        // Effective Echo Time (0018,9082)
        // Laterality (0020,0060)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.Laterality);
        if (value) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.Laterality, 1, value);
            filterOperation.SelectorName = 'Laterality';
            filterOperation.SelectorAttributeVr = "CS";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }

        // Image Laterality (0020,0062)
        value = DicomHelper.getDicomTagValue(metadata, DicomTag.ImageLaterality);
        if (value) {
            filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.ImageLaterality, 1, value);
            filterOperation.SelectorName = 'Image Laterality';
            filterOperation.SelectorAttributeVr = "CS";
            displaySet.FilterOperationsSequence.push(filterOperation);
        }
        // Slice Location (0020,1041)
        //value = DicomHelper.getDicomTagValue(metadata, DicomTag.SliceLocation);
        //if (value) {
        //    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.SliceLocation, 1, value);
        //    filterOperation.SelectorName = 'Slice Location';
        //    displaySet.FilterOperationsSequence.push(filterOperation);
        //}

        // View Code Sequence (0054,0220) 


        // Others

        //value = DicomHelper.getDicomTagValue(metadata, DicomTag.SeriesNumber);
        //if (value) {
        //    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.SeriesNumber, 1, value);
        //    filterOperation.SelectorName = 'Series Number';
        //    displaySet.FilterOperationsSequence.push(filterOperation);

        // Patient Orientation (0020,0020)
        //value = DicomHelper.getDicomTagValue(metadata, DicomTag.PatientOrientation);
        //if (value) {
        //    filterOperation = HangingProtocolHelper.get_FilterOperation(DicomTag.PatientOrientation, 1, value);
        //    filterOperation.SelectorName = 'Patient Orientation';
        //    displaySet.FilterOperationsSequence.push(filterOperation);
        //}
    }

    public static checkSortingOperations(displaySet: Models.DisplaySet, cell: lt.Controls.Medical.Cell) {

        if (cell.derivatives.count > 0) { // <== means MPR original cell (i.e. not derived MPR cell)
            this.setSortingOperationsMpr(displaySet, cell);
            return;
            }

        var medicalViewerSortingOperations: lt.Controls.Medical.SortingOperation[];
        var sortingOperationsSequence: Array<Models.SortingOperations> = new Array<Models.SortingOperations>();
        medicalViewerSortingOperations = cell.sortingOperationsSequence;

        if (medicalViewerSortingOperations != null) {
            medicalViewerSortingOperations.forEach((medicalViewerSortingOperation: lt.Controls.Medical.SortingOperation) => {
                var sortingOperations: Models.SortingOperations = new Models.SortingOperations();

                sortingOperations.Convert(medicalViewerSortingOperation);
                sortingOperationsSequence.push(sortingOperations);
            });

            if (sortingOperationsSequence.length > 0) {
                displaySet.SortingOperationsSequence = sortingOperationsSequence;
            }
        }

        // default -- no sorting option chosen in the menu
        else {
        }
    }

    public static setNominalScreenDefinitionSequence(hp: Models.HangingProtocol) {
        hp.NominalScreenDefinitionSequence = new Array<Models.NominalScreenDefinition>();

        var nsc: Models.NominalScreenDefinition = new Models.NominalScreenDefinition();
        nsc.NumberOfHorizontalPixels = 1024;
        nsc.NumberOfVerticalPixels = 768;
        nsc.DisplayEnvironmentSpatialPosition = [0, 1, 1, 0];
        nsc.ScreenMinimumColorBitDepth = 8;

        hp.NominalScreenDefinitionSequence.push(nsc);
    }

    public static setFilterOperationsMpr(displaySet: Models.DisplaySet, cell: lt.Controls.Medical.Cell) {
        var filterOperation: Models.FilterOperation = new Models.FilterOperation();
        filterOperation.SelectorName = 'Image Plane';
        filterOperation.FilterByCategory = "IMAGE_PLANE";
        filterOperation.SelectorAttributeVr = "CS";
        filterOperation.SelectorValue = this.GetCellMprTypeSelectorValue(cell.mprType);              //"TRANSVERSE";
        filterOperation.FilterByOperator = Models.FilterByOperator.MemberOf;
        displaySet.FilterOperationsSequence.push(filterOperation);
    }

    public static setSortingOperationsMpr(displaySet: Models.DisplaySet, cell: lt.Controls.Medical.Cell) {

        var medicalViewerSortingOperations: lt.Controls.Medical.SortingOperation[];
        var sortingOperationsSequence: Array<Models.SortingOperations> = new Array<Models.SortingOperations>();
        medicalViewerSortingOperations = cell.sortingOperationsSequence;

        var sortingOperations: Models.SortingOperations = new Models.SortingOperations();

        sortingOperations.SortByCategory = Models.SortByCategory.AlongAxis;
        sortingOperations.SortingDirection = Models.SortingDirection.Increasing;
        sortingOperationsSequence.push(sortingOperations);

        if (sortingOperationsSequence.length > 0) {
            displaySet.SortingOperationsSequence = sortingOperationsSequence;
        }
    }

    public static setDisplaySetPatientOrientation(activeFrame: lt.Controls.Medical.Frame, displaySet: Models.DisplaySet) {
        displaySet.DisplaySetPatientOrientation = null;
        if (activeFrame.targetOrientation != undefined) {
            displaySet.DisplaySetPatientOrientation = activeFrame.targetOrientation;
        }
    }

    //public static checkReformatting(displaySet: Models.DisplaySet, cell: lt.Controls.Medical.Cell) {

    //    var medicalViewerSortingOperations: lt.Controls.Medical.SortingOperation[];
    //    var sortingOperationsSequence: Array<Models.SortingOperations> = new Array<Models.SortingOperations>();
    //    medicalViewerSortingOperations = cell.sortingOperationsSequence;

    //    if (medicalViewerSortingOperations != null) {
    //        medicalViewerSortingOperations.forEach((medicalViewerSortingOperation: lt.Controls.Medical.SortingOperation) => {
    //            var sortingOperations: Models.SortingOperations = new Models.SortingOperations();

    //            sortingOperations.Convert(medicalViewerSortingOperation);
    //            sortingOperationsSequence.push(sortingOperations);
    //        });

    //        if (sortingOperationsSequence.length > 0) {
    //            displaySet.SortingOperationsSequence = sortingOperationsSequence;
    //        }
    //    }
    //}

    private static get_FilterOperation(tag: string, index: number, value: any): Models.FilterOperation {
        var filterOperation: Models.FilterOperation = new Models.FilterOperation();

        filterOperation.WCFSelectorAttribute = Utils.insert(tag, 4, ":");
        filterOperation.SelectorValueNumber = index;
        filterOperation.SelectorValue = value;
        filterOperation.FilterByOperator = Models.FilterByOperator.MemberOf;
        return filterOperation;
    }

    public static get_ModalityItemsInView(viewer: lt.Controls.Medical.MedicalViewer): Array<ModalityItem> {
        var modalityItems: Array<ModalityItem> = new Array<ModalityItem>();
        var count: number = viewer.layout.items.count;

        for (var i = 0; i < count; i++) {
            var cell: lt.Controls.Medical.Cell = viewer.layout.items.item(i);

            if (cell.frames.count > 0) {
                var frame: lt.Controls.Medical.Frame = cell.frames.item(0);

                if (frame["metadata"]) {
                    var modality: string = DicomHelper.getDicomTagValue(frame["metadata"], DicomTag.Modality);
                    var ars: Array<Models.CodeSequence> = DicomHelper.getCodeSequenceList(frame["metadata"], DicomTag.AnatomicRegionSequence, null);
                    var pcs: Array<Models.CodeSequence> = DicomHelper.getCodeSequenceList(frame["metadata"], DicomTag.ProcedureCodeSequence, null);
                    var rfrpcs: Array<Models.CodeSequence> = DicomHelper.getCodeSequenceList(frame["metadata"], DicomTag.ReasonForRequestedProcedureCodeSequence, null);
                    var studyDescription: string = DicomHelper.getDicomTagValue(frame["metadata"], DicomTag.StudyDescription);
                    var bpe: string = DicomHelper.getDicomTagValue(frame["metadata"], DicomTag.BodyPartExamined);
                    var pn: string = DicomHelper.getDicomTagValue(frame["metadata"], DicomTag.ProtocolName);
                    var item: ModalityItem;

                    if (pcs.length > 0 || rfrpcs.length > 0) {
                        studyDescription = '';
                    }
                    else {                        
                        if ((bpe && bpe.length > 0) || (pn && pn.length > 0)) {                            
                            studyDescription = '';
                        }
                    }

                    item = Utils.findFirst(modalityItems, function (item: ModalityItem) {
                        return item.Modality == modality && item.StudyDescription == studyDescription && Utils.is_equal(item.AnatomicRegionSequence, ars) &&
                            Utils.is_equal(item.ProcedureCodeSequence, pcs) && Utils.is_equal(item.ReasonForRequestedProcedureCodeSequence, rfrpcs);
                    });

                    if (!item) {
                        var item: ModalityItem = new ModalityItem(frame["metadata"], modality);

                        item.AnatomicRegionSequence = ars;
                        item.ProcedureCodeSequence = pcs;
                        item.ReasonForRequestedProcedureCodeSequence = rfrpcs;
                        item.StudyDescription = studyDescription;
                        item.BodyPartExamined = bpe;
                        item.ProtocolName = pn;

                        modalityItems.push(item);
                    }
                }
            }
        }

        return modalityItems;
    }

    public static get_emptyCellImageBox(cell: lt.Controls.Medical.EmptyCell, boxNumber: number): Models.ImageBox {
        var box: Models.ImageBox = new Models.ImageBox();

        box.Position = HangingProtocolHelper.get_position(cell.bounds);
        box.ImageBoxNumber = boxNumber;

        if (cell.parent.viewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
            box.RowPosition = cell.rowPosition;
            box.ColumnPosition = cell.columnsPosition;
            box.NumberOfRows = cell.numberOfRows;
            box.NumberOfColumns = cell.numberOfColumns;
        }

        box.ImageBoxLayoutType = Models.ImageBoxLayoutType.Single;
        return box;
    }

    public static get_cellScrollType(cell: lt.Controls.Medical.Cell, box: Models.ImageBox) {
        if (cell == null || box == null) {
            return;
        }

        switch (cell.scrollType) {
            default:
            case lt.Controls.Medical.ScrollType.none:
                box.ImageBoxScrollDirection = Models.ScrollDirection.None;
                box.ImageBoxSmallScrollType = Models.ScrollType.None;
                box.ImageBoxLargeScrollType = Models.ScrollType.None;
                box.ImageBoxSmallScrollAmount = 1;
                box.ImageBoxLargeScrollAmount = 1;
                break;

            case lt.Controls.Medical.ScrollType.normal:
                box.ImageBoxScrollDirection = Models.ScrollDirection.Vertical;
                box.ImageBoxSmallScrollType = Models.ScrollType.Image;
                box.ImageBoxLargeScrollType = Models.ScrollType.Image;
                box.ImageBoxSmallScrollAmount = 1;
                box.ImageBoxLargeScrollAmount = 1;
                break;

            case lt.Controls.Medical.ScrollType.row:
                box.ImageBoxScrollDirection = Models.ScrollDirection.Vertical;
                box.ImageBoxSmallScrollType = Models.ScrollType.RowColumn;
                box.ImageBoxLargeScrollType = Models.ScrollType.RowColumn;
                box.ImageBoxSmallScrollAmount = 1;
                box.ImageBoxLargeScrollAmount = 1;
                break;

            case lt.Controls.Medical.ScrollType.column:
                box.ImageBoxScrollDirection = Models.ScrollDirection.Horizontal;
                box.ImageBoxSmallScrollType = Models.ScrollType.RowColumn;
                box.ImageBoxLargeScrollType = Models.ScrollType.RowColumn;
                box.ImageBoxSmallScrollAmount = 1;
                box.ImageBoxLargeScrollAmount = 1;
                break;

            case lt.Controls.Medical.ScrollType.page:
                box.ImageBoxScrollDirection = Models.ScrollDirection.Vertical
                box.ImageBoxSmallScrollType = Models.ScrollType.Page;
                box.ImageBoxLargeScrollType = Models.ScrollType.Page;
                box.ImageBoxSmallScrollAmount = 1;
                box.ImageBoxLargeScrollAmount = 1;
                break;
        }
    }

    public static ConvertToHangingProtocolCineOptions(cinePlayer: lt.Controls.Medical.CinePlayer): Models.PlaybackSequencing {
        if (cinePlayer == null)
            return null;

        var playback: Models.PlaybackSequencing = null;
        var loop: boolean = cinePlayer.get_loop();

        switch (cinePlayer.get_direction()) {
            case lt.Controls.Medical.PlayingDirection.forward:
                playback = loop ? Models.PlaybackSequencing.Looping : Models.PlaybackSequencing.Stop;
                break;

            case lt.Controls.Medical.PlayingDirection.sweep:
                playback = loop ? Models.PlaybackSequencing.Sweeping : Models.PlaybackSequencing.SweepingStop;
                break;

            case lt.Controls.Medical.PlayingDirection.backward:
                playback = loop ? Models.PlaybackSequencing.Backward : Models.PlaybackSequencing.BackwardStop;
                break;

            case lt.Controls.Medical.PlayingDirection.shuffle:
                playback = loop ? Models.PlaybackSequencing.Shuffle : Models.PlaybackSequencing.ShuffleStop;
                break;
        }
        return playback;
    }

    public static ConvertToCellCinePlayer(cell: lt.Controls.Medical.Cell, displaySet: Models.DisplaySet) {
        if (displaySet == null || displaySet.Boxes == null || displaySet.Boxes.length == 0)
            return;

        var box: Models.ImageBox = displaySet.Boxes[0];

        if (box.PreferredPlaybackSequencing == null || box.RecommendedDisplayFrameRate == null)
            return null;

        var cinePlayer : lt.Controls.Medical.CinePlayer = cell.get_cinePlayer();
        if (cinePlayer == null)
            return;

        // RecommendedDisplayFrameRate
        cinePlayer.set_FPS(box.RecommendedDisplayFrameRate);

        // PreferredPlaybackSequencing
        switch (box.PreferredPlaybackSequencing) {
            case Models.PlaybackSequencing.Looping: // 0 Looping (1,2,...,n,1,2,...,n,1,2,...,n,...)
                cinePlayer.set_loop(true);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.forward);
                break;

            case Models.PlaybackSequencing.Sweeping: // 1 Sweeping (1,2,...n,n-1,...2,1,2,...n,...)
                cinePlayer.set_loop(true);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.sweep);
                break;

            case Models.PlaybackSequencing.Stop:// 2 Stop (1,2,...,n)
                cinePlayer.set_loop(false);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.forward);
                break;

            // Non-hanging Protocol Defined
            case Models.PlaybackSequencing.SweepingStop: // 3 (1,2,...n,n-1,...2,1)
                cinePlayer.set_loop(false);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.sweep);
                break;


            case Models.PlaybackSequencing.Backward: // 4 (n, n-1, ..., 2, 1, n, n-1, ..., 2, 1)
                cinePlayer.set_loop(true);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.backward);
                break;

            case Models.PlaybackSequencing.BackwardStop: // 5 (n, n-1, ..., 2, 1)
                cinePlayer.set_loop(false);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.backward);
                break;

            case Models.PlaybackSequencing.Shuffle:   // 6 Random Continuous
                cinePlayer.set_loop(true);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.shuffle);
                break;

            case Models.PlaybackSequencing.ShuffleStop: // 7 Random one time 
                cinePlayer.set_loop(false);
                cinePlayer.set_direction(lt.Controls.Medical.PlayingDirection.shuffle);
                break;
        }
    }
     

    public static get_CineOptions(cell: lt.Controls.Medical.Cell, box: Models.ImageBox) {
        if (cell.cinePlayer != null) {
            // Preferred Playback Sequencing (Conditional)
            box.PreferredPlaybackSequencing = this.ConvertToHangingProtocolCineOptions(cell.cinePlayer);
         
            // Recommended Display Frame Rate (Conditional) 
            box.RecommendedDisplayFrameRate = cell.cinePlayer.FPS;

            // Cine Relative to Real-Time (Conditional)
            // XX
        }
    }

    public static ConvertToScrollType(displaySet: Models.DisplaySet): lt.Controls.Medical.ScrollType {
        var scrollType: lt.Controls.Medical.ScrollType = lt.Controls.Medical.ScrollType.normal;

        if (displaySet == null || displaySet.Boxes == null || displaySet.Boxes.length == 0) {
            return scrollType;
        }

        var box: Models.ImageBox = displaySet.Boxes[0];

        switch (box.ImageBoxSmallScrollType) {
            case Models.ScrollType.None:
                scrollType = lt.Controls.Medical.ScrollType.none;
                break;

            case Models.ScrollType.Image:
                scrollType = lt.Controls.Medical.ScrollType.normal;
                break;

            case Models.ScrollType.RowColumn:
                if (box.ImageBoxScrollDirection == Models.ScrollDirection.Vertical) {
                    scrollType = lt.Controls.Medical.ScrollType.row;
                }
                else {
                    scrollType = lt.Controls.Medical.ScrollType.column;
                }
                break;

            case Models.ScrollType.Page:
                scrollType = lt.Controls.Medical.ScrollType.page;
                break;
        }

        return scrollType;
    }

    public static get_cellImageBox(cell: lt.Controls.Medical.Cell, boxNumber: number): Models.ImageBox {
        var box: Models.ImageBox = new Models.ImageBox()
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var seriesManagerService: SeriesManagerService = injector.get('seriesManagerService');
        var instances: Array<any> = seriesManagerService.get_instances(cell.seriesInstanceUID, cell.divID);
        var subCell: lt.Controls.Medical.SubCell = cell.selectedItem;

        if (!subCell)
            subCell = <lt.Controls.Medical.SubCell>(cell.imageViewer.items.item(0));

        box.Position = HangingProtocolHelper.get_position(cell.bounds);

        // Image Box Number (Mandatory)
        box.ImageBoxNumber = boxNumber;
        if (cell.viewer.cellsArrangement == lt.Controls.Medical.CellsArrangement.grid) {
            box.RowPosition = cell.rowPosition;
            box.ColumnPosition = cell.columnsPosition;
            box.NumberOfRows = cell.numberOfRows;
            box.NumberOfColumns = cell.numberOfColumns;
        }

        for (var index = 0; index < cell.frames.count; index++) {
            var frame: any = cell.frames.item(index);

            if (angular.isDefined((<any>frame).Instance)) {
                var sopInstanceUID: string = (frame).Instance.SOPInstanceUID;

                box.referencedSOPInstanceUID.push(sopInstanceUID);
            }
        }

        if (cell.arrangement == lt.Controls.Medical.FrameArrangement.grid && (cell.gridLayout.columns > 1 || cell.gridLayout.rows > 1)) {

            // Image Box Tile Horizontal Dimension (Conditional)
            box.ImageBoxTileHorizontalDimension = cell.gridLayout.columns;

            // Image Box Tile Vertical Dimension (Conditional)
            box.ImageBoxTileVerticalDimension = cell.gridLayout.rows;

            // Image Box Scroll Direction (Conditional)
            // Image Box Small Scroll Type (Conditional)
            // Image Box Small Scroll Amount (Conditional)
            // Image Box Large Scroll Type (Conditional)
            // Image Box Large Scroll Amount (Conditional)
            this.get_cellScrollType(cell, box);
        }

        if (angular.isDefined(subCell["horizontalAlignment"]))
            box.HorizontalJustification = subCell["horizontalAlignment"];

        if (angular.isDefined(subCell["verticalAlignment"]))
            box.VerticalJustification = subCell["verticalAlignment"];

        if ( /*cell.currentOffset != 0 &&*/  angular.isDefined(cell.frames.item(cell.currentOffset).Instance)) {
            box.FirstFrame = new Models.FirstFrame();
            box.FirstFrame.SOPClassUID = cell.frames.item(cell.currentOffset).Instance.SOPClassUID;
            box.FirstFrame.SOPInstanceUID = cell.frames.item(cell.currentOffset).Instance.SOPInstanceUID;
            box.FirstFrame.FrameNumber = cell.currentOffset + 1;
        }

        if (subCell && subCell.attachedFrame) {
            var renderer = subCell.attachedFrame.get_wlRenderer();

            if (renderer) {
                var owlc = renderer.originalWindowLevelCenter;
                var owlw = renderer.originalWindowLevelWidth;

                if (subCell.attachedFrame.windowCenter != owlc || subCell.attachedFrame.windowWidth != owlw) {
                    box.WindowWidth = subCell.attachedFrame.windowWidth;
                    box.WindowCenter = subCell.attachedFrame.windowCenter;
                }
            }
        }

        // Image Box Layout Type (Mandatory)
        if (cell.arrangement == lt.Controls.Medical.FrameArrangement.grid && (box.ImageBoxTileHorizontalDimension > 1 || box.ImageBoxTileVerticalDimension > 1)) 
        {
            box.ImageBoxLayoutType = Models.ImageBoxLayoutType.Tiled;
        }
        else if (instances.length == 1 && instances[0].NumberOfFrames > 1) {
            box.ImageBoxLayoutType = Models.ImageBoxLayoutType.Cine;
        }
        else if (instances.length == 1) {
            box.ImageBoxLayoutType = Models.ImageBoxLayoutType.Single;
        }
        else if (instances.length > 1) {
            box.ImageBoxLayoutType = Models.ImageBoxLayoutType.Stack;
        } 
        
        // Image Box Overlap Priority (Optional)  
        
        // Preferred Playback Sequencing (Conditional)
        // Recommended Display Frame Rate (Conditional) 
        // Cine Relative to Real-Time (Conditional)
        this.get_CineOptions(cell, box);

        return box;
    }

    private static split_cells(viewer: lt.Controls.Medical.MedicalViewer) {
        var cells: Array<lt.Controls.Medical.Cell> = viewer.layout.items.toArray();
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var seriesManagerService: SeriesManagerService = injector.get('seriesManagerService');
        var modalitySplit: any = {};

        if (cells.length > 1) {
            modalitySplit = cells.reduce(function (buckets, item: lt.Controls.Medical.Cell) {
                var seriesInfo = seriesManagerService.get_seriesInfo(item.seriesInstanceUID);

                if (seriesInfo) {
                    var modality = seriesInfo.Modality;
                    var key: string = '';

                    if (item.frames.count > 0) {
                        var metadata = item.frames.item(0)["metadata"];

                        if (!metadata) {
                            metadata = (<lt.Controls.Medical.MPRCell>item).generator.frames.item(0)["metadata"];
                        }

                        if (metadata) {
                            key = DicomHelper.getDicomTagValue(metadata, DicomTag.BodyPartExamined);
                            if (!key)
                                key = '';
                        }

                        if (key.length == 0) {
                            var studyDescription: string = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyDescription);

                            if (!studyDescription)
                                studyDescription = "";

                            key += studyDescription;
                        }
                    }

                    if (!buckets[modality + key])
                        buckets[modality + key] = [];
                    buckets[modality + key].push(item);
                }

                return buckets;
            }, {});

            for (var name in modalitySplit) {
                if (modalitySplit.hasOwnProperty(name)) {
                    HangingProtocolHelper.sort_cells(modalitySplit[name]);
                }
            }
        }
        return modalitySplit;
    }

    private static sort_cells(cells: Array<lt.Controls.Medical.Cell>) {
        cells.sort(function (a: lt.Controls.Medical.Cell, b: lt.Controls.Medical.Cell) {
            if (a.frames.count > 0 && b.frames.count > 0) {
                var aMetadata = a.frames.item(0)['metadata'];
                var bMetadata = b.frames.item(0)['metadata'];

                if (aMetadata && bMetadata) {
                    var aDate = DicomHelper.getDicomTagValue(aMetadata, DicomTag.StudyDate);
                    var bDate = DicomHelper.getDicomTagValue(bMetadata, DicomTag.StudyDate);
                    var aTime = DicomHelper.getDicomTagValue(aMetadata, DicomTag.StudyTime);
                    var bTime = DicomHelper.getDicomTagValue(bMetadata, DicomTag.StudyTime);
                    var acompare = HangingProtocolHelper.combine_datetime(aDate, aTime);
                    var bcompare = HangingProtocolHelper.combine_datetime(bDate, bTime);

                    a['studyDate'] = acompare;
                    b['studyDate'] = bcompare;

                    return (<IDateJS>bcompare).compareTo(<IDateJS>acompare);
                }
            }
            else if (a.frames.count == 0 && b.frames.count > 0) {
                return -1;
            }
            else if (a.frames.count > 0 && b.frames.count == 0) {
                return 1;
            }
            return 0;
        });
    }

    private static sort_series(series: Array<any>) {
        series.sort(function (a: any, b: any) {
            if (a.frames.count > 0 && b.frames.count > 0) {
                var aMetadata = a.frames.item(0)['metadata'];
                var bMetadata = b.frames.item(0)['metadata'];

                if (aMetadata && bMetadata) {
                    var aDate = DicomHelper.getDicomTagValue(aMetadata, DicomTag.StudyDate);
                    var bDate = DicomHelper.getDicomTagValue(bMetadata, DicomTag.StudyDate);
                    var aTime = DicomHelper.getDicomTagValue(aMetadata, DicomTag.StudyTime);
                    var bTime = DicomHelper.getDicomTagValue(bMetadata, DicomTag.StudyTime);
                    var acompare = HangingProtocolHelper.combine_datetime(aDate, aTime);
                    var bcompare = HangingProtocolHelper.combine_datetime(bDate, bTime);

                    a['studyDate'] = acompare;
                    b['studyDate'] = bcompare;

                    return (<IDateJS>bcompare).compareTo(<IDateJS>acompare);
                }
            }
            else if (a.frames.count == 0 && b.frames.count > 0) {
                return -1;
            }
            else if (a.frames.count > 0 && b.frames.count == 0) {
                return 1;
            }
            return 0;
        });
    }

    private static combine_datetime(date, time) {
        if (date && time) {
            var datetime: Date = new Date(
                date.getUTCFullYear(),
                date.getUTCMonth(),
                date.getUTCDate(),
                time.getUTCHours(),
                time.getUTCMinutes(),
                time.getUTCSeconds()
            );
            return datetime;
        }

        if (date && !time)
            return date;

        return time;
    }

    public static get_position(rect: lt.LeadRectD): Models.FramePosition {
        var position: Models.FramePosition = new Models.FramePosition();

        position.leftTop = new lt.LeadPointD();
        position.leftTop.x = rect.topLeft.x;
        position.leftTop.y = Math.abs(rect.topLeft.y - 1);

        position.rightBottom = new lt.LeadPointD();
        position.rightBottom.x = position.leftTop.x + rect.width;
        position.rightBottom.y = position.leftTop.y - rect.height;


        return position;
    }

    public static get_PrimaryCell(viewer: lt.Controls.Medical.MedicalViewer, seriesManagerService: SeriesManagerService): lt.Controls.Medical.Cell {
        var cells: Array<lt.Controls.Medical.Cell> = viewer.layout.items.toArray();

        if (cells.length > 1) {
            HangingProtocolHelper.sort_cells(cells);
        }

        return cells[0];
    }

    private static setReferenceLine(viewer: lt.Controls.Medical.MedicalViewer, hp: Models.HangingProtocol) {
        if (viewer.showReferenceLine || viewer.showFirstAndLastReferenceLine) {
            var displaySets: Array<Models.DisplaySet> = hp.DisplaySets;
            var matchedCells = viewer.matchedCells;

            var navigationIndicatorSequence = new Array<Models.NavigationIndicator>();

            angular.forEach(matchedCells, function (matchedCell: lt.Controls.Medical.Cell[]) {

                var navigationIndicator: Models.NavigationIndicator = new Models.NavigationIndicator();
                navigationIndicator.NavigationDisplaySet = null; // Required if there is a one-way interaction.  Our reference line interaction is always two-way. 
                navigationIndicator.ReferenceDisplaySets = new Array<number>();

                angular.forEach(matchedCell, function (oneCell: lt.Controls.Medical.Cell) {
                    var col = oneCell.columnsPosition;
                    var row = oneCell.rowPosition;

                    var d: Models.DisplaySet = Utils.findFirst(displaySets, function (item: Models.DisplaySet) {
                        return oneCell == item['cell'];
                    });

                    if (d) {
                        navigationIndicator.ReferenceDisplaySets.push(d.DisplaySetNumber);
                    }
                });

                if (navigationIndicator.ReferenceDisplaySets.length > 0) {
                    navigationIndicatorSequence.push(navigationIndicator);
                }
                    
            });

            if (navigationIndicatorSequence.length > 0) {
                hp.NavigationIndicatorSequence = navigationIndicatorSequence;
            }
        }
    }

    private static setSynchronizedScrolling(viewer: lt.Controls.Medical.MedicalViewer, hp: Models.HangingProtocol) {
        if (viewer.enableSynchronization) {
            var displaySets: Array<Models.DisplaySet> = hp.DisplaySets;
            var matchedCells = viewer.matchedCells;

            var synchronizedScrollingSequence = new Array<Models.SynchronizedScrolling>();

            angular.forEach(matchedCells, function (matchedCell: lt.Controls.Medical.Cell[]) {

                var synchronizedScrolling: Models.SynchronizedScrolling = new Models.SynchronizedScrolling();
                synchronizedScrolling.DisplaySetScrollingGroup = new Array<number>();

                angular.forEach(matchedCell, function (oneCell: lt.Controls.Medical.Cell) {
                    var col = oneCell.columnsPosition;
                    var row = oneCell.rowPosition;

                    var d: Models.DisplaySet = Utils.findFirst(displaySets, function (item: Models.DisplaySet) {
                        return oneCell == item['cell'];
                    });

                    if (d) {
                        synchronizedScrolling.DisplaySetScrollingGroup.push(d.DisplaySetNumber);
                    }
                });

                if (synchronizedScrolling.DisplaySetScrollingGroup.length > 0) {
                    synchronizedScrollingSequence.push(synchronizedScrolling);
                }

            });

            if (synchronizedScrollingSequence.length > 0) {
                hp.SynchronizedScrollingSequence = synchronizedScrollingSequence;
            }
        }
    }

    private static GetCellDisplaySet(cell: lt.Controls.Medical.Cell, hp: Models.HangingProtocol): Models.DisplaySet {
        var d: Models.DisplaySet = Utils.findFirst(hp.DisplaySets, function (item: Models.DisplaySet) {
            return cell == item['cell'];
        });
        return d;
    }


    private static setSynchronizedScrollingMprDerived(viewer: lt.Controls.Medical.MedicalViewer, hp: Models.HangingProtocol) {
        var count: number = viewer.layout.items.count;

        for (var i = 0; i < count; i++) {
            var cell: lt.Controls.Medical.Cell = viewer.layout.items.item(i);

            if (cell.frames.count > 0) {
                if (cell.derivatives.count > 0) { 
                    // MPR derived

                    // Create new synchronized scrolling entry
                    if (hp.SynchronizedScrollingSequence == null) {
                        hp.SynchronizedScrollingSequence = new Array<Models.SynchronizedScrolling>();
                    }

                    var synchronizedScrolling: Models.SynchronizedScrolling = new Models.SynchronizedScrolling();
                    synchronizedScrolling.DisplaySetScrollingGroup = new Array<number>();
                    hp.SynchronizedScrollingSequence.push(synchronizedScrolling);

                    // Add the parent of the MPR group (the cell that is not derived)
                    var displaySetParent = this.GetCellDisplaySet(cell, hp);
                    if (displaySetParent != null) {
                        synchronizedScrolling.DisplaySetScrollingGroup.push(displaySetParent.DisplaySetNumber);
                    }
                              
                    // Add the children of the MPR group (the derived cells)
                    for (var d = 0; d < cell.derivatives.count; d++) {
                        var displaySet = this.GetCellDisplaySet(cell.derivatives.get_item(d), hp);
                        if (displaySet != null) {
                            synchronizedScrolling.DisplaySetScrollingGroup.push(displaySet.DisplaySetNumber);                                
                        }
                    }


                }
            }
        }
    }

}

class SeriesLayout {
    public Boxes: Array<Models.ImageBox>;
    public TemplateId: string;

    constructor() {
        this.Boxes = new Array<Models.ImageBox>();
        this.TemplateId = "";
    }
}

class StructuredDisplayHelper {

    private static getPosition(rect: lt.LeadRectD): Models.FramePosition {
        var position: Models.FramePosition = new Models.FramePosition();

        position.leftTop = new lt.LeadPointD();
        position.leftTop.x = rect.topLeft.x;
        position.leftTop.y = Math.abs(rect.topLeft.y - 1);

        position.rightBottom = new lt.LeadPointD();
        position.rightBottom.x = position.leftTop.x + rect.width;
        position.rightBottom.y = position.leftTop.y - rect.height;

        return position;
    }

    public static getSeriesLayout(cell: lt.Controls.Medical.Cell): SeriesLayout {

        var items: lt.Controls.ImageViewerItems = cell.imageViewer.items;
        var seriesLayout: SeriesLayout = new SeriesLayout();
        // var boxes: Array<Models.ImageBox> = new Array<Models.ImageBox>();

        for (var i = 0; i < items.count; i++) {
            var subcell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(items.item(i));
            var box: Models.ImageBox = new Models.ImageBox();
            var viewBounds: lt.LeadRectD = cell.imageViewer.convertBoundsToView(subcell.bounds, false);

            box.Position = this.getPosition(subcell.bounds);
            if (subcell.attachedFrame != null) {
                if (angular.isDefined((<any>subcell.attachedFrame).Instance)) {
                    var sopInstanceUID: string = (<any>subcell.attachedFrame).Instance.SOPInstanceUID;

                    box.referencedSOPInstanceUID.push(sopInstanceUID);
                }
            }
            seriesLayout.Boxes.push(box);
        }

        if (seriesLayout.Boxes.length > 0) {
            seriesLayout.TemplateId = "";

            if (angular.isDefined((<any>cell).templateId)) {
                seriesLayout.TemplateId = (<any>cell).templateId;
            }
            return seriesLayout;
        }
    }
}